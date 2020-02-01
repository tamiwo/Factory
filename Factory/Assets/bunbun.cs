using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bunbun : MonoBehaviour
{

    public float max;
    public float min;

    public Vector3 speedABS;
    private Vector3 speed;
    public Vector3 angle;

    private void Start()
    {
        speed = speedABS;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(speed*Time.deltaTime);

        angle= transform.localEulerAngles;
        if( angle.z > 180 ) angle.z-=360;
        if (angle.z > max)
        {
            speed = -speedABS;
        }
        else if (angle.z < min)
        {
            speed = speedABS;
        }

    }
}
