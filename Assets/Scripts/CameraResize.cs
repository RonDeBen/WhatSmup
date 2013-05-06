using UnityEngine;
using System.Collections;

public class CameraResize : MonoBehaviour {
    public GameObject topLeft, topRight, bottomLeft, bottomRight;
    public Camera resizeCamera;
	
	Vector3 tl, tr, bl, br;
	
	void Start () {
        tl = topLeft.transform.position;
		tr = topRight.transform.position;
		bl = bottomLeft.transform.position;
		br = bottomRight.transform.position;
		
		float x = gameObject.camera.WorldToViewportPoint(tl).x;
        float y = gameObject.camera.WorldToViewportPoint(bl).y;
        float width = gameObject.camera.WorldToViewportPoint(tr).x - gameObject.camera.WorldToViewportPoint(tl).x;
        float height = gameObject.camera.WorldToViewportPoint(tl).y - gameObject.camera.WorldToViewportPoint(bl).y; 
		
		resizeCamera.rect = new Rect(x, y, width, height);
	}
}
