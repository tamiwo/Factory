using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

    public float speed = 0.01f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter ( Collider col ) {
        Debug.Log("Collision: " + col.gameObject.tag);
    }

    void OnTriggerStay ( Collider col ) {
        Transform t = col.gameObject.transform;
        float diffZ = t.localPosition.z - transform.localPosition.z;
        float newZ = 0.0f;
        if( diffZ > 0 ){
            newZ = -speed;
        }
        else if( diffZ < 0 ){
            newZ = speed;
        }
        t.localPosition += new Vector3( speed, 0, newZ );
    }
}
