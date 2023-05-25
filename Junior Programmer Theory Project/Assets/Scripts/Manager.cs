using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance { get; private set; } // ENCAPSULATION

    [SerializeField] GameObject aluminumBall;
    [SerializeField] GameObject rubberBall;
    [SerializeField] GameObject magneticBall;

    static Vector3 rubberSpawnPosition = new Vector3(0.0f, 4.0f, 0.0f);
    static Vector3 aluminumSpawnPosition = new Vector3(-1.0f, 4.0f, 0.0f);
    static Vector3 firstMagneticSpawnPosition = new Vector3(1.0f, 4.0f, 0.0f);
    static Vector3 secondMagneticSpawnPosition = new Vector3(4.0f, 4.0f, -4.0f);

    public void Start()
    {
        if (Instance == null)
        {
            Instance = this;

            SpawnBall(rubberBall);
            SpawnBall(aluminumBall);
            SpawnBall(magneticBall);
        }
        else
            Destroy(gameObject);
    }

    public void SpawnBall(GameObject ballObj)
    {
        if (ballObj.tag == "Rubber")
        {
            Instantiate(rubberBall, rubberSpawnPosition, transform.rotation);
        }
        else if (ballObj.tag == "Aluminum")
        {
            Instantiate(aluminumBall, aluminumSpawnPosition, transform.rotation);
        }
        else if (ballObj.tag == "Magnetic")
        {
            if (GameObject.FindGameObjectsWithTag("Magnetic").Length < 2)
            {
                Instantiate(magneticBall, firstMagneticSpawnPosition, transform.rotation);
                Instantiate(magneticBall, secondMagneticSpawnPosition, transform.rotation);
            }
        }
        else
        {
            Debug.Log("Invalid GameObject passed to SpawnBall");
        }
    }
}
