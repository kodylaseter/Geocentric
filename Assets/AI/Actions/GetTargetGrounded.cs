using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Action;
using RAIN.Core;
using RAIN.Representation;
using RAIN.Motion;
using RAIN.Navigation;
using RAIN.Navigation.Graph;
using RAIN.Navigation.Waypoints;

[RAINAction]
public class GetTargetGrounded : RAINAction
{
	public Expression MoveTarget = new Expression();
    public override void Start(RAIN.Core.AI ai)
    {
        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
		GameObject loc = ai.WorkingMemory.GetItem<GameObject>("varHero");
		MoveLookTarget newTarget = new MoveLookTarget();
		newTarget.VectorTarget = new Vector3(loc.transform.position.x, 0, loc.transform.position.z);
		newTarget.CloseEnoughDistance = ai.Motor.CloseEnoughDistance;
		ai.WorkingMemory.SetItem(MoveTarget.VariableName, newTarget);
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}