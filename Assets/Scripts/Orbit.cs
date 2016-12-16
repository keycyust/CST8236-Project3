using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour
{
    public static float orbitSpeed = 21.0f;

    public float siderealPeriod;
    
    public bool directionInverted;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //input to rotate fast(F) or rotate slow(S)
        if (Input.GetKeyDown(KeyCode.F))
        {
            orbitSpeed += 2.0f;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (orbitSpeed > 3.0f)
            {
                orbitSpeed -= 3.0f;
            }

        }

        float rotateDirection;
        if (directionInverted)
        {
            rotateDirection = -1.0f;
        }
        else
        {
            rotateDirection = 1.0f;
        }

        if (transform.parent != null)
        {
            //orbit around sun
            transform.RotateAround(transform.parent.position, Vector3.up, Time.deltaTime / siderealPeriod * orbitSpeed);
        }

        //rotate on axis
        transform.Rotate(new Vector3(10, 20, 5), Time.deltaTime * rotateDirection * 10.0f);

    }
}
