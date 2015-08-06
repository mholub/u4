using System;
namespace me.mholub.u4.core
{
	public class Pin<T> : IPin {
		public T Value {
			get {
				return _value;  
			}
			
			set {
				_value = value;
			}
		}
		
		object IPin.Value {
			get {
				return _value;
			}
			set {
				_value = (T)value;
			}
		}
		
		public INode Node {
			get {
				return _node;
			}
			set {
				_node = value;
			}
		}
		
		T _value;
		INode _node;
	}

	public class InputPin<T> : Pin<T>, IInputPin {

	}

	public class OutputPin<T> : Pin<T>, IOutputPin {	

  	}
}