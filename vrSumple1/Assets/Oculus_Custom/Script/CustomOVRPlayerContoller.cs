using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomOVRPlayerContoller : OVRPlayerController
{
    [Header("Custom Property")]
    public float UpDownMoveMultiplier = 0.5f;

    public override void UpdateMovement()
    {
        base.UpdateMovement();

        float moveY = 0;
        if (Input.GetKey(KeyCode.C))
            moveY = -1;
        else if (Input.GetKey(KeyCode.Space))
            moveY = 1;
        else
            return;

        if (Input.GetKey(KeyCode.LeftShift))
            moveY += 1.4f;

        float moveYSpeed = moveY * SimulationRate * Time.deltaTime * UpDownMoveMultiplier;
        MoveThrottle += Vector3.up * moveYSpeed;
    }
}
