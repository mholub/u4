using System;
namespace me.mholub.u4.core
{
	public class Connection<T> : IConnection {
		public OutputPin<T> From {
			get;
			private set;
		}

		IOutputPin IConnection.From {
			get { return From; }
		}
		
		public InputPin<T> To {
			get;
			private set;
		}

		IInputPin IConnection.To {
			get { return To; }
		}

		public Connection(OutputPin<T> f, InputPin<T> t) {
			From = f;
			To = t;
		}
	}
}