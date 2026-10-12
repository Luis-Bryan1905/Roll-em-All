using System.Data;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private GameObject score;
    public int Value = 100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            score.GetComponent<ScoreText>().IncreaseScore(Value);
            Destroy(gameObject);
        }
        
        
    }


}
