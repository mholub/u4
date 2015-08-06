using UnityEngine;
using me.mholub.u4.core;
using me.mholub.u4.core.nodes;
using me.mholub.u4.core.evaluator;

public class U4Test : MonoBehaviour {
	PatchEvaluator patchEvaluator;
	ValueNode<float> v2;


	// Use this for initialization
	void Start () {
		Patch p = new Patch();
		ValueNode<float> v1 = new ValueNode<float>();
		p.AddNode(v1);
		v1.Output.Value = 15;

		v2 = new ValueNode<float>();
		p.AddNode(v2);

		AddNode sum = new AddNode();
		p.AddNode(sum);

		p.Connect(v1.Output, sum.A);
		p.Connect(v2.Output, sum.B);

		patchEvaluator = new PatchEvaluator(p);
		patchEvaluator.Evaluate();
	}

	void Update() {
		v2.Output.Value = Mathf.Sin(Time.time);
		patchEvaluator.Evaluate();
	}
}
