using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private Vector3 touchPos;
    private bool isTouching;      // タッチ中かな？
    public Camera cam;              // カメラ(外から入れる)

	// Use this for initialization
	void Start () {
        isTouching = false;
        touchPos = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update() {
        Scroll();
    }

    // スクロール処理
    private void Scroll() {
        Vector3 newTouchPos;
        
        // タッチ中
        if(isTouching) {
            // 今回の座標を取得
            newTouchPos = cam.ScreenToWorldPoint(Input.mousePosition);

            // 前回の座標と違ったら
            if (touchPos != newTouchPos) {
                // カメラをその分動かす
                cam.transform.position -= newTouchPos - touchPos;
            }

            // 今回の座標を保存
            touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // タッチ開始
        if (Input.GetMouseButtonDown(0)) {
            isTouching = true;
            // 今回の座標を保存
            touchPos = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        // タッチ終了
        if (Input.GetMouseButtonUp(0)) {
            isTouching = false;
            touchPos = new Vector3(0, 0, 0);
        }
    }

}