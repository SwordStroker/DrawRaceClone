using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointDetector : MonoBehaviour
{
    public Vector3 latestCheckpointPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        switch (collision.tag)
        {
            case Const.TAG_CHECKPOINT:
                latestCheckpointPos = collision.transform.position;
                break;
            case Const.TAG_FINISH:
                EventManager.Trigger(Const.EVENT_ENDGAME);
                break;
            default:
                break;
        }
    }
}
