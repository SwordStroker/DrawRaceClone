using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private HingeJoint2D _firstHingeJoint;

    [SerializeField]
    private HingeJoint2D _secondHingeJoint;

    [SerializeField]
    private CheckpointDetector _checkpointDetector;

    private float checkpointThreshold = -40;

    private void Start()
    {
        EventManager.Subscribe(Const.EVENT_ENDGAME, Stop);
    }

    private void Update()
    {
        if (transform.position.y < checkpointThreshold)
            ResetPos();
    }

    public void SetHingePositions(Vector2 firstHingePos, Vector2 secondHingePos)
    {
        ResetHingeJoint(_firstHingeJoint, firstHingePos);
        ResetHingeJoint(_secondHingeJoint, secondHingePos);
        transform.localPosition = new Vector3(transform.localPosition.x, 0, 0);
    }

    private void ResetHingeJoint(HingeJoint2D joint, Vector2 pos)
    {
        ResetVelocity(joint);
        joint.connectedAnchor = new Vector2(pos.x, pos.y);
        joint.useMotor = true;
    }

    private void ResetPos()
    {
        ResetVelocity(_firstHingeJoint);
        ResetVelocity(_secondHingeJoint);
        transform.rotation = Quaternion.identity;
        transform.localPosition = new Vector3(_checkpointDetector.latestCheckpointPos.x, 10, 0);
    }

    private void ResetVelocity(HingeJoint2D joint)
    {
        joint.connectedBody.velocity = Vector2.zero;
        joint.connectedBody.angularVelocity = 0;
    }

    private void Stop()
    {
        _firstHingeJoint.useMotor = false;
        _secondHingeJoint.useMotor = false;
    }
}
