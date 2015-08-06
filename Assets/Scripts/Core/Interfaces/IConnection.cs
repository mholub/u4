namespace me.mholub.u4.core {
	public interface IConnection {
		IOutputPin From {
			get;
		}
		IInputPin To {
			get;
		}
	}
}