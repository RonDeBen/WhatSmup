using UnityEngine;
using System.Collections;

public class BoundedCam : MonoBehaviour {
    public GameObject focus, topLeft, topRight, bottomLeft, bottomRight;
    private Rect playerBound, cameraBound;
    private Vector3 bl;
    private float playerX, playerY, camX, camY;
	// Use this for initialization
	void Start () {
        float frustumHeight = 2.0f * camera.farClipPlane * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        float frustumWidth = frustumHeight * camera.aspect;

        playerBound = new Rect(topLeft.transform.position.x, topLeft.transform.position.y, topRight.transform.position.x - topLeft.transform.position.x, topLeft.transform.position.y - bottomLeft.transform.position.y);

        float x = -22f + frustumWidth / 2.0f;
        float y = 24.5f - frustumHeight / 2.0f;

        bl = new Vector3(x, -y, transform.position.z);
        
        cameraBound = new Rect(x, y, Mathf.Abs(x * 2), Mathf.Abs(y*2));
	}
	
	// Update is called once per frame
	void Update () {
        if (focus.rigidbody.velocity != Vector3.zero)
        {
            playerX = bottomLeft.transform.position.x - focus.transform.position.x;
            playerY = bottomLeft.transform.position.y - focus.transform.position.y;
            camX = (playerX * cameraBound.width) / playerBound.width;
            camY = (playerY * cameraBound.height) / playerBound.height;

            transform.position = new Vector3(bl.x - camX, bl.y - camY, transform.position.z);
        }
	}
}
