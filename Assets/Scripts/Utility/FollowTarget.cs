using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Transform _drawCam;

    private void Update()
    {
        //var temp = target.position - _drawCam.position;
        //temp.z = 0;
        transform.position = target.position;
        //transform.eulerAngles = target.eulerAngles;
    }
}
