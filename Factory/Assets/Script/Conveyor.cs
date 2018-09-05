using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour {

    public float speed = 0.01f;
    Vector3 dir;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update () {
	}

    void OnTriggerEnter ( Collider col ) {
        Debug.Log("Collision: " + col.gameObject.name);
    }

    void OnTriggerStay ( Collider col ) {
        // 運び先までの長さ
        // colliderの外に出すために1.01かけて少し前にしておく
        Vector3 length = transform.forward * transform.localScale.x / 2 * 1.01f;
        // 運びたい先の座標
        Vector3 target = transform.position + length;
        // 運ぶモノの位置
        Transform t = col.transform;
        // 差分
        Vector3 diff = target - t.position;
        // 高さの違いは無視する
        diff = new Vector3(diff.x, 0.0f, diff.z);
        // 一定速度で移動する
        t.position += diff.normalized * speed;
    }
}
