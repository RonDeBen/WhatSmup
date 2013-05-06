using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

    [HideInInspector]
    public int enemies = 0;
    [HideInInspector]
    public float maxEnemies = 1;
    public GameObject enemy;
    public Camera cam;
    public float spawnTime;
    private Vector3 spawnHere;
    Plane playerPlane;
    Ray ray;
    float hit;

	void Start () {
	}
	
	void Update () {
        //print("Enemies: " + enemies + " maxEnemies: " + maxEnemies);
        if (enemies < maxEnemies)
        {
            enemies++;
            Spawn();
        }
        //maxEnemies = (int)(Mathf.Sqrt(s.score / 100));
	}

    void Spawn()
    {
        enemy.GetComponent<Square>().UpdateMesh();

        playerPlane = new Plane(Vector3.forward, transform.position);
        ray = cam.ViewportPointToRay(new Vector3(Random.Range(1.0f, 0.0f), Random.Range(1.0f, 0.0f), 0.0f));
        
        if (playerPlane.Raycast(ray, out hit))
        {
            spawnHere = ray.GetPoint(hit);
            GameObject enemyClone = Instantiate(enemy, spawnHere, transform.rotation) as GameObject;
            StartCoroutine(spawning(spawnTime, enemyClone));
        }
    }

    IEnumerator spawning(float spawnTime, GameObject clone)
    {
        MoveTowards mt = clone.GetComponent<MoveTowards>();
        mt.shouldFollow = false;
        clone.tag = "Untagged";
        clone.particleSystem.Play();
        yield return new WaitForSeconds(spawnTime);
        if (clone != null)
        {
            mt.shouldFollow = true;
            clone.tag = "enemy";
        }
    }
}
