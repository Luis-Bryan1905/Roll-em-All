using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text scoreText;
    public int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText = this.GetComponent<Text>();
        UpdateScoreUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text =  "Score: " + score.ToString("0");
        }
    }
}
