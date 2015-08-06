using System.Collections.Generic;
using UnityEngine;

namespace me.mholub.u4.core.evaluator {
	internal class PatchEvaluator {
		Patch patch;

		Dictionary<INode, NodeEvaluator> nodeEvaluators = new Dictionary<INode, NodeEvaluator>();
		Dictionary<IConnection, ConnectionEvaluator> connectionEvaluators = new Dictionary<IConnection, ConnectionEvaluator>();

		public PatchEvaluator(Patch p) {
			patch = p;
			createEvaluators();
		}

		public void Evaluate() {
			setDirty();

			foreach (var ne in nodeEvaluators.Values) {
				ne.Evaluate();
			}
		}

		private void createEvaluators() {
			nodeEvaluators.Clear();
			connectionEvaluators.Clear();

			foreach (var n in patch.Nodes) {
				n.init();
				nodeEvaluators[n] = new NodeEvaluator(n);
			}

			foreach (var c in patch.Connections) {
				Debug.LogFormat("connection: {0} | {1} -> {2}", c, c.From, c.To);
				Debug.LogFormat("connection: {0} | {1} -> {2}", c, c.From.Node, c.To.Node);

				connectionEvaluators[c] = new ConnectionEvaluator(c, nodeEvaluators[c.From.Node]);

				nodeEvaluators[c.From.Node].AddOutputEvaluator(connectionEvaluators[c]);
				nodeEvaluators[c.To.Node].AddInputEvaluator(connectionEvaluators[c]);
			}
		}

		void setDirty() {
			foreach (var ne in nodeEvaluators.Values) {
				ne.Dirty = true;
			}

			foreach (var ce in connectionEvaluators.Values) {
				ce.Dirty = true;
			}
		}
	}
}