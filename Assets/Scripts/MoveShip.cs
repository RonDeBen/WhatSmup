using UnityEngine;
using System.Collections;

public class MoveShip : MonoBehaviour {
    public float speed = 15;
	void Start () {
	
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, speed, 0);
            renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, -speed, 0);
            renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-speed, rigidbody.velocity.y, 0);
            renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, 0);
            renderer.material.mainTextureOffset = new Vector2(0.0f, 0.0f);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, 0);
            renderer.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0, 0);
            renderer.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            renderer.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(0, rigidbody.velocity.y, 0);
            renderer.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        }


        Vector3 targetPos = new Vector3();
        Plane playerPlane = new Plane(Vector3.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            targetPos = ray.GetPoint(hitdist);
        }

        float diffX = targetPos.x - transform.position.x;
        float diffY = targetPos.y - transform.position.y;


        float angle = Mathf.Atan2(diffY, diffX) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
	    }
}
        

