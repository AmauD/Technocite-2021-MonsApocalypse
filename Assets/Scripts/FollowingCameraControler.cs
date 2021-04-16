using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingCameraControler : MonoBehaviour
{
    public Transform player;
    private Transform myTransform;
    private Vector3 offset;
    private void Start()
    {
        myTransform = transform;
        offset = player.position - myTransform.position;
    }

    private void LateUpdate()
    {
        myTransform.position = player.position - offset;
        myTransform.LookAt(player);
    }
}
