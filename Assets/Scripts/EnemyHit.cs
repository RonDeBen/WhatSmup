using UnityEngine;
using System.Collections;

public class EnemyHit : MonoBehaviour {
    public float cooldown, size;
    public int points;
    private EnemyGenerator eg;
    private Score s;
    private bool hit = false;
	// Use this for initialization
	void Start () {
        eg = GameObject.Find("EnemySpawner").GetComponent<EnemyGenerator>();
        s = GameObject.Find("score").GetComponent<Score>();
	}

    void OnTriggerEnter(Collider collider)
    {
        if (!hit && gameObject!=null)
        {
            hit = true;
            eg.enemies--;
            s.add(points);
            eg.maxEnemies = (int)(Mathf.Sqrt(s.score / 100));
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(collider.gameObject);
            StartCoroutine(explode(cooldown));
        }
    }


    IEnumerator explode(float cooldown)
    {
        gameObject.particleSystem.startSize = size;
        if (!gameObject.particleSystem.isPlaying)
        {
            gameObject.particleSystem.Play();
        }
        yield return new WaitForSeconds(cooldown);
        Destroy(gameObject);
    }
}
