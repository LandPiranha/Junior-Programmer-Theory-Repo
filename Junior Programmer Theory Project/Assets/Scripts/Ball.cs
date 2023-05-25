using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    protected Rigidbody ballRigidBody;
    
    const float baseMovementForce = -80.0f;

    public void Start()
    {
        ballRigidBody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        CheckPosition();
    }

    protected virtual void Move()
    {
        ballRigidBody.AddForce(Vector3.forward * Time.deltaTime * baseMovementForce, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plane")
        {
            Move();
        }
    }

    protected void CheckPosition()
    {
        if (transform.position.y < -2.0f)
        {
            Manager.Instance.SpawnBall(gameObject);
            Destroy(gameObject);
        }

    }
}
