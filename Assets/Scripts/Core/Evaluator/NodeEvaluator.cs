using System.Collections.Generic;

namespace me.mholub.u4.core.evaluator {
	internal class NodeEvaluator {
		INode node;

		List<ConnectionEvaluator> inputEvaluators;
		List<ConnectionEvaluator> outputEvaluators;

		public bool Dirty {
			get;
			set;
		}

		public NodeEvaluator(Node n) {
			node = n;
			Dirty = true;

			inputEvaluators = new List<ConnectionEvaluator>();
			outputEvaluators = new List<ConnectionEvaluator>();
		}

		public void AddInputEvaluator(ConnectionEvaluator c) {
			inputEvaluators.Add(c);
		}

		public void AddOutputEvaluator(ConnectionEvaluator c) {
			outputEvaluators.Add(c);
		}

		public bool Evaluate() {
			if (Dirty) {
				foreach(var ie in inputEvaluators) {
					ie.Evaluate();
				}

				node.Evaluate();

				Dirty = false;

				foreach(var oe in outputEvaluators) {
					oe.Evaluate();
				}
			}
			return !Dirty;
		}

	}
}
