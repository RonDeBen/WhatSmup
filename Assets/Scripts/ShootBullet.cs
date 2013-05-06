using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour
{
    public GameObject bullet, player;
    public float bulletSpeed = 1;
    public float fireRate = 0.5f;
    private float nextFire = 0.0f;

    void shoot()
    {
        Vector3 myPos = transform.position;

        Vector3 targetPos = new Vector3();
        Plane playerPlane = new Plane(Vector3.forward, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist= 0.0f;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            targetPos = ray.GetPoint(hitdist);
        }
        Vector3 dir = targetPos - myPos;
        GameObject bulletClone = Instantiate(bullet, myPos, Quaternion.LookRotation(dir)) as GameObject;
        Physics.IgnoreCollision(bulletClone.collider, player.collider);
        bulletClone.rigidbody.velocity = dir.normalized * bulletSpeed;

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            shoot();
        }
    }
}
