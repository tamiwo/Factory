using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

    public float speed = 0.01f;
    Vector3 dir;

	// Use this for initialization
	void Start () {
        Vector3 vec = new Vector3( speed, 0.0f, 0.0f );
        dir = Quaternion.Euler(transform.localRotation.eulerAngles) * vec;
        Debug.Log(name + "'s dir:" + dir);
	}
	
	// Update is called once per frame
    void Update () {
		
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
