using me.mholub.u4.core;

namespace me.mholub.u4.core.evaluator {
	internal class ConnectionEvaluator {
		IConnection connection;

		NodeEvaluator outputPinNodeEvaluator;

		public bool Dirty {
			get;
			set;
		}

		public ConnectionEvaluator(IConnection c, NodeEvaluator opne) {
			connection = c;
			outputPinNodeEvaluator = opne;

			Dirty = true;
		}

		public void Evaluate() {
			if (Dirty) {
				outputPinNodeEvaluator.Evaluate();

				connection.To.Value = connection.From.Value;

				Dirty = false;
			}
		}
	}
}