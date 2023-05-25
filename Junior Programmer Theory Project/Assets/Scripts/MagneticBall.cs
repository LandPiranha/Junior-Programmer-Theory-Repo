using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticBall : Ball
{
    GameObject otherMagneticBall;
    float magneticForce = -400.0f;
    protected override void Move() // POLYMORPHISM
    {
        if (otherMagneticBall == null)
        {
            FindOtherMagneticBall();
        }

        if (otherMagneticBall != null)
        {
            Vector3 vectorToOtherBall = transform.position - otherMagneticBall.transform.position;

            ballRigidBody.AddForce(vectorToOtherBall * Time.deltaTime * magneticForce, ForceMode.Impulse);
        }
    }

    private void FindOtherMagneticBall()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Magnetic");

        foreach (GameObject magnetic in balls)
        {
            if (magnetic.GetInstanceID() != gameObject.GetInstanceID())
            {
                otherMagneticBall = magnetic;
            }
        }
    }
}
