namespace me.mholub.u4.core {
	public interface IPin {
		INode Node {
			get;
			set;
		}

		object Value {
			get; 
			set;
		}
	}

	public interface IInputPin : IPin {
	}

	public interface IOutputPin : IPin {
	}
}