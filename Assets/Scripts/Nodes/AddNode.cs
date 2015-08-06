using UnityEngine;

namespace me.mholub.u4.core.nodes {
	public class AddNode : Node {
		public InputPin<float> A;
		public InputPin<float> B;

		public OutputPin<float> sum;

		public override void Evaluate() {
			sum.Value = A.Value + B.Value;
			Debug.LogFormat("a = {0} b = {1} sum = {2}", A.Value, B.Value, sum.Value);
		}
	}
}
