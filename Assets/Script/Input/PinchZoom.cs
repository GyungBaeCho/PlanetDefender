using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GlobalVar;

public class PinchZoom : MonoBehaviour {
    public float    _orthoZoomSpeed = 0.5f;
    public float    _zoomMin;
    public float    _zoomMax;

    // Use this for initialization
    void Start () {
        GlobalVariable._minZoom = _zoomMin;
        GlobalVariable._maxZoom = _zoomMax;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            //OrthoGraphic VIew
            if (Camera.main.orthographic == true)
            {
                Camera.main.orthographicSize += deltaMagnitudeDiff * _orthoZoomSpeed;

                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, _zoomMax);
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, _zoomMin);

            }
            //Perspective View
            else
            {

            }
        }

        //PC MouseWHeel
        if (Input.touchCount == 0)
        {
            //OrthoGraphic VIew
            if (Camera.main.orthographic == true)
            {
                Camera.main.orthographicSize -= Input.mouseScrollDelta.y;

                Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize, _zoomMax);
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, _zoomMin);

            }
            //Perspective View
            else
            {

            }
        }
    }
}
