using UnityEngine;
using System.Collections;
using System;

namespace me.mholub.u4.core {
	public class Node : INode {
		bool _init;

		public Node() {
		}

		public virtual void Evaluate() {

		}

		internal void init() {
			if (!_init) {
				createPins();
				_init = true;
			}
		}

		void createPins() {
			var t = GetType();
			foreach (var f in t.GetFields()) {
				var fieldType = f.FieldType;
				if (typeof(IPin).IsAssignableFrom(fieldType)) {
					var newPinValue = Activator.CreateInstance(fieldType);
					IPin p = newPinValue as IPin;
					p.Node = this;

					f.SetValue(this, newPinValue);

//					Debug.LogFormat("Magic for {0} | {1} | {2} | {3} || {4}", t, f, p.Value, this, p.Node);
				}
			}
		}
	}
}
