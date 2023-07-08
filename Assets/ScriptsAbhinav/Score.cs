using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance;
    public TextMeshProUGUI scoreText;
    public PickupSpawn pickupSpawn;

    int score = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    public void AddPoint()
    {
        score += 10;
        scoreText.text = score.ToString() + " POINTS";
    }

    public void bigPoint()
    {
        score+=50;
        scoreText.text = score.ToString() + " POINTS";
    }
}
