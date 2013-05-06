using UnityEngine;
using System.Collections;
[RequireComponent(typeof(TextMesh))]
public class Score : MonoBehaviour {


    private int _score;
    [HideInInspector]
    public float startPos;
    [HideInInspector]
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }

    void Start()
    {
        startPos = transform.position.x;
    }

    public void add(int points)
    {
        score += points;
        gameObject.GetComponent<TextMesh>().text = "Score: " + score.ToString();
        transform.position = new Vector3(startPos - (score.ToString().Length-2) * 4, transform.position.y, transform.position.z);
    }
}
