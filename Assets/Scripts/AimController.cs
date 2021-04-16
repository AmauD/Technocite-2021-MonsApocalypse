using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public Camera myCamera;
    public Transform aim;
    private Transform myTransform;

    private void Start()
    {
        myTransform = transform;
    }
    private void Update()
    {
        Vector3 targetPosition = Vector3.zero;
        Plane plane = new Plane(Vector3.up, aim.position);
        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            targetPosition = ray.GetPoint(distance);
        }
        transform.LookAt(new Vector3(targetPosition.x, myTransform.position.y, targetPosition.z));
    }
}
