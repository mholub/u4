using UnityEngine;
using System.Collections;

namespace me.mholub.u4.core.nodes {
	public class ValueNode<T> : Node {
		public OutputPin<T> Output;

		public override void Evaluate() {
		}
	}
}
