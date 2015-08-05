namespace me.mholub.u4.core {
	#region Interfaces
	public interface IPin<T> {
		INode Node {
			get;
		}

		T Value {
			get;
		}
	}

	public interface INode {
		void Evaluate();
	}

	public interface IPatch {
		void Evaluate();
	}
	#endregion
}