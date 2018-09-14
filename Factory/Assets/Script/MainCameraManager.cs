using System;
using System.Text;
using TouchScript.Gestures.TransformGestures;
using UnityEngine;

public class MainCameraManager : MonoBehaviour
{
    private ScreenTransformGesture PanGesture;
    private Camera myCamera;

    private void OnEnable()
    {
        myCamera = GetComponent<Camera>();
        PanGesture = GetComponent<ScreenTransformGesture>();
        PanGesture.Transformed += Pan;
    }

    private void OnDisable()
    {
        PanGesture.Transformed -= Pan;
    }

    private void Pan(object sender, System.EventArgs e)
    {
        // Convert touch and camera positions to a common coordinate system.
        var deltaScreenPosition = PanGesture.DeltaPosition;
        var cameraScreenPosition = myCamera.WorldToScreenPoint(myCamera.transform.position);
        var newCameraScreenPosition = cameraScreenPosition - deltaScreenPosition;
        myCamera.transform.position = myCamera.ScreenToWorldPoint(newCameraScreenPosition);

        SetCamaraZoom(1/PanGesture.DeltaScale);

    }

    void SetCamaraZoom(float scale){

        float max = 2.0f;
        float min = 1 / 4;

        if ( scale > max ) {
            scale = max;
        }
        else if ( scale < min ) {
            scale = min;
        }
        myCamera.orthographicSize *= scale;

    }
}