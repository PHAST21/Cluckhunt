using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float Lives;
    private float currentLife;
    public Score UIscore;

    private void Start()
    {
        currentLife = Lives;
    }
    private void Update()
    {
        if (Lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void IncrementScore()
    {
        if (Lives < currentLife)
        {
            currentLife = Lives;
        }
        else
        {
            UIscore.AddPoint();
        }
    }
   public void TakeDamage()
    {
        Lives--;
    }
    
}
