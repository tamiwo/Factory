using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

    public float speed = 0.01f;
    Vector3 dir;

	// Use this for initialization
	void Start () {
        float roll = transform.localRotation.y;
        Vector3 vec = new Vector3( speed, 0.0f, 0.0f );
        dir = Quaternion.AngleAxis(roll, Vector3.up) * vec;
        Debug.Log(name + "'s dir:" + dir);
	}
	
	// Update is called once per frame
    void Update () {
        float roll = transform.localRotation.y;
        Vector3 vec = new Vector3(speed, 0.0f, 0.0f);
        dir = Quaternion.AngleAxis(roll, Vector3.up) * vec;
        Debug.Log(name + "'s dir:" + roll + "," + dir);
		
	}

    void OnTriggerEnter ( Collider col ) {
        Debug.Log("Collision: " + col.gameObject.tag);
    }

    void OnTriggerStay ( Collider col ) {
        Transform t = col.gameObject.transform;
        /*
        float diffCentor = t.localPosition.z - transform.localPosition.z;
        float newZ = 0.0f;
        if( diffCentor > 0 ){
            newZ = -speed;
        }
        else if( diffCentor < 0 ){
            newZ = speed;
        }
        */
        t.localPosition += dir;
    }
}
