using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameManager GM;
    private Color OGcolor;
    public float Lives;
    private float currentLife;
    public Score UIscore;
    public GameObject GameOverMenu;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        OGcolor = sprite.color;
        currentLife = Lives;
    }
    private void Update()
    {
        if (Lives <= 0)
        {

            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
            GM.active = false;
            GM.wave1 = false;
            GM.wave2 = false;
            GM.wave3 = false;
            GameOverMenu.SetActive(true);
            Destroy(gameObject);
            
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
        StartCoroutine(Blink());
        Lives--;
    }
    
    IEnumerator Blink()
    {
        sprite.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        sprite.color = OGcolor;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        sprite.color = OGcolor;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.clear;
        yield return new WaitForSeconds(0.1f);
        sprite.color = OGcolor;
    }
}
