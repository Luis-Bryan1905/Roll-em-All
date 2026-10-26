using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float time;
    public Text timeText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeText = this.GetComponent<Text>();
        UpdateTimeUI();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DecreaseTime();
    }

    public void DecreaseTime()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
            UpdateTimeUI();
        }
        else 
        {
            
        }

    }

    private void UpdateTimeUI()
    {
        if (timeText != null)
        {
            timeText.text = "Timer: " + time.ToString("0");
        }
    }
}
