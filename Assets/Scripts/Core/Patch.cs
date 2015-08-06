using System;
using System.Collections.Generic;

namespace me.mholub.u4.core {
	public class Patch : IPatch {
		public List<Node> Nodes {
			get;
			private set;
		}
		public List<IConnection> Connections {
			get;
			private set;
		}

		public Patch() {
			Nodes = new List<Node>();
			Connections = new List<IConnection>();
		}

		public void AddNode(Node node) {
			node.init();
			Nodes.Add(node);
		}

		public void RemoveNode(Node node) {
			Nodes.Remove(node);
		}

		public void Connect<T>(OutputPin<T> o, InputPin<T> i) {
			if (o == null || i == null) {
				throw new ArgumentNullException("Connect pins error. Add node to the patch or call init() before working with it");
			}

			Connections.Add(new Connection<T>(o, i));
		}

		public void Disconnect<T>(OutputPin<T> o, InputPin<T> i) {
			for (int k = 0; k < Connections.Count; k++) {
				var conn = Connections[k] as Connection<T>;

				if (conn.To.Equals(i) && conn.From.Equals(o)) {
					Connections.RemoveAt(k);
					break;
				}
			}
		}
	}
}