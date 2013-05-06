using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class BulletExplode : MonoBehaviour {

    Camera cam = Camera.main;
    public float size = 3.5f;
    public float cooldown = 0.5f;
    private ParticleSystem ps;
	void Update () {
        if (cam.WorldToViewportPoint(transform.position).x < 0
            || cam.WorldToViewportPoint(transform.position).x > 1
            || cam.WorldToViewportPoint(transform.position).y < 0
            || cam.WorldToViewportPoint(transform.position).y > 1)
        {
            StartCoroutine(explode(cooldown));
        }
    }
        IEnumerator explode(float cooldown){
            gameObject.particleSystem.startSize = size;
            yield return new WaitForSeconds(cooldown);
            Destroy(gameObject);
        }

}
