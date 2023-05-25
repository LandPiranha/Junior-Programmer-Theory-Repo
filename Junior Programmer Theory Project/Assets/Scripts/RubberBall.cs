using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubberBall : Ball
{
    float jumpForce = 100.0f;

    protected override void Move()
    {
        base.Move();
        ballRigidBody.AddForce(Vector3.up * Time.deltaTime * jumpForce, ForceMode.Impulse);
    }
}
