using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
    public int lives = 3;
    public GameObject start;
    public TextMesh txtLives;
    private EnemyGenerator eg;

    void Start()
    {
        txtLives.text = "Lives: " + lives;
        eg = GameObject.Find("EnemySpawner").GetComponent<EnemyGenerator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("enemy"))
        {
            hit();
        }
    }

    void hit()
    {
        lives--;
        txtLives.text = "Lives: " + lives;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        for (int k = 0; k < enemies.Length; k++)
        {
            Destroy(enemies[k]);
        }
        eg.enemies = 0;
        if (start != null) 
        { 
            transform.position = start.transform.position;
            Camera.main.transform.position = new Vector3(0.0f, 0.0f, Camera.main.transform.position.z);
        }
    }
}
