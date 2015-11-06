using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Motion;
using RAIN.Representation;

[RAINAction]
public class PredictLocation : RAINAction
{
	public Expression MoveTargetVariable = new Expression(); //the variable you want to use for the output move target
	
	private MoveLookTarget moveTarget = new MoveLookTarget();
	
	
	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
	}
	
	public override ActionResult Execute(AI ai) {
		GameObject rex = ai.WorkingMemory.GetItem<GameObject>("Rex");
		Transform transform = rex.transform;
		Vector3 velocity = rex.GetComponent<Rigidbody>().velocity;
		Vector3 result = velocity + transform.position;
		moveTarget.VectorTarget = result;
		ai.WorkingMemory.SetItem<MoveLookTarget>(MoveTargetVariable.VariableName, moveTarget);
		return ActionResult.SUCCESS;
	}

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}