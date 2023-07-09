using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Sprite eggYolk;
    private GameManager GM;
    private Color OGcolor;
    public float Lives;
    private float currentLife;
    public Score UIscore;
    public GameObject GameOverMenu;
    private AudioSource audioSource;
    public List<AudioClip> CluckSFX;
    public GameObject Egg1, Egg2, Egg3;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
        OGcolor = sprite.color;
        currentLife = Lives;
    }
    private void Update()
    {
        if (Lives <= 0)
        {

            /*SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);*/
            GM.score = -2;
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
        audioSource.PlayOneShot(CluckSFX[Random.Range(0, 3)], 0.9f);
        Lives--;
        if (Lives == 2)
        {
            Egg1.GetComponent<SpriteRenderer>().sprite = eggYolk;
        }
        else if(Lives== 1)
        {
            Egg2.GetComponent<SpriteRenderer>().sprite = eggYolk;
        }
        else if (Lives == 0)
        {
            Egg3.GetComponent<SpriteRenderer>().sprite = eggYolk;
        }
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
