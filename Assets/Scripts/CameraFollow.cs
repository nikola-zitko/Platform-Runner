using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{


    public float FollowSpeed = 100f;
    public Transform Target;

    private void Update()
    {
        Vector3 newPosition = Target.position;
        newPosition.z = -10;
        newPosition.y += 0.8f;
        transform.position = Vector3.Slerp(transform.position, newPosition, FollowSpeed * Time.deltaTime);
    }
}
