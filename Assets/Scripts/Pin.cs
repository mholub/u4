using System;
namespace me.mholub.u4.core
{
	public class Connection<T> {
		public InputPin<T> input {
			get { return _input; }
			set {
				_input = value;
				_input.Connection = this;
			}
		}

		OutputPin<T> output {
			get;
			set;
    	}

		InputPin<T> _input;
	}

	public class Pin<T> : IPin<T>
	{
		public T Value {
			get {
				if (_hasValue) {
					return _value;  
				} else {
					throw new Exception("No value calculated");
				}
			}

			set {
				_value = value;
				_hasValue = true;
			}
		}

		public bool HasValue {
			get {
				return _hasValue;
			}
		}

		public INode Node {
			get {
				return _node;
			}
			internal set {
				_node = value;
      		}
		}

		T _value;
		bool _hasValue;
		INode _node;
	}

	public class InputPin<T> : Pin<T> {
		internal Connection<T> Connection {
			get; set;
		}
	}

	public class OutputPin<T> : Pin<T> {
		
  	}
}