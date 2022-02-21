using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngle : MonoBehaviour
{
    public Transform Target;

    public Vector3 Offset;

    public float smoothness;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 delayedPos = Vector3.Lerp(transform.position, Target.position, smoothness);
        transform.position = delayedPos + Offset;
    }
}
