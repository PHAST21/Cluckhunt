using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<DangerZone> dangerZones;
    public List<GameObject> reticles;
    public GameObject white, black;
    public bool active,wave1,wave2,wave3;
    public int currentPos,score;
    private MouseFollow PlayerMovement;
    private Health playerHealth;
    public PickupSpawn pickupSpawn;
    private bool spawnStart=false;
    private AudioSource audioSource;
    public Animator catAnim;
    public AudioClip GunshotSFX;

    private void Start()
    {
        /*StartCoroutine(CountDown());*/
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseFollow>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (active)
        {
            Aiming();
        }
        if (score > 4)
        {
            wave1 = false;
            PlayerMovement.moveSpeed = 5;
            wave2 = true;
        }
        if (score > 9)
        {
            wave2 = false;
            wave3 = true;
            PlayerMovement.moveSpeed = 7;
        }
        if (score < -1)
        {
            wave1 = false;
            wave2 = false;
            wave3 = false;
            active = false;
        }
        if (!spawnStart)
        {
            if (score > 5)
            {
                InvokeRepeating("SpawnPickup", 1f, 8f);
                spawnStart = true;
            }
        }
    }

    void SpawnPickup()
    {
        pickupSpawn.SpawnPickup();
    }
    public void Aiming()
    {
        if (wave1)
        {
            int i = currentPos;
            reticles[currentPos].SetActive(true);
            active = false;
            StartCoroutine(Preshoot(i));
        }
        else if (wave2)
        {
            if (currentPos > 0 && currentPos < 4)
            {
                int i = currentPos;
                reticles[i].SetActive(true);
                reticles[i + 5].SetActive(true);
                reticles[i - 1].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos == 4)
            {
                int i = currentPos;
                reticles[i].SetActive(true);
                reticles[i + 5].SetActive(true);
                reticles[i + 4].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos > 4 && currentPos < 9) 
            {
                int i = currentPos;
                reticles[i].SetActive(true);
                reticles[i - 5].SetActive(true);
                reticles[i + 1].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos == 9)
            {
                int i = currentPos;
                reticles[i].SetActive(true);
                reticles[i + 5].SetActive(true);
                reticles[i - 5].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos > 9 && currentPos < 14)
            {
                int i = currentPos;
                reticles[i].SetActive(true);
                reticles[i + 1].SetActive(true);
                reticles[i - 5].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }

            else if (currentPos == 0)
            {
                int i = currentPos;
                reticles[0].SetActive(true);
                reticles[1].SetActive(true);
                reticles[5].SetActive(true);
                reticles[6].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos == 14)
            {
                int i = currentPos;
                reticles[8].SetActive(true);
                reticles[9].SetActive(true);
                reticles[13].SetActive(true);
                reticles[14].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
        }
        if (wave3)
        {
            int i = Random.Range(0, 15);

            for (int j = 0; j < 15; j++)
            {
                if (j == i)
                {
                    continue;
                }
                else if (j == (i + 7))
                {
                    continue;
                }
                reticles[j].SetActive(true);
            }
            active = false;
            StartCoroutine(Preshoot(i));
        }
    }
    public void Shoot(int i)
    {
        StartCoroutine(Flash());
        if (wave1)
        {
            dangerZones[i].gameObject.SetActive(true);
            dangerZones[i].GetComponent<DangerZone>().active = true;
            StartCoroutine(Cooldown(i));
            score++;
        }
        else if (wave2)
        {
            if (i>0&&i<4)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[i + 5].gameObject.SetActive(true);
                dangerZones[i + 5].GetComponent<DangerZone>().active = true;
                dangerZones[i - 1].gameObject.SetActive(true);
                dangerZones[i - 1].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (i == 4)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[i + 5].gameObject.SetActive(true);
                dangerZones[i + 5].GetComponent<DangerZone>().active = true;
                dangerZones[i + 4].gameObject.SetActive(true);
                dangerZones[i + 4].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (i > 4 && i < 9)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[i - 5].gameObject.SetActive(true);
                dangerZones[i - 5].GetComponent<DangerZone>().active = true;
                dangerZones[i + 1].gameObject.SetActive(true);
                dangerZones[i + 1].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if(i == 9)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[i + 5].gameObject.SetActive(true);
                dangerZones[i + 5].GetComponent<DangerZone>().active = true;
                dangerZones[i - 5].gameObject.SetActive(true);
                dangerZones[i - 5].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (i > 9 && i < 14)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[i + 1].gameObject.SetActive(true);
                dangerZones[i + 1].GetComponent<DangerZone>().active = true;
                dangerZones[i - 5].gameObject.SetActive(true);
                dangerZones[i - 5].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if(i ==0) {
                dangerZones[0].gameObject.SetActive(true);
                dangerZones[0].GetComponent<DangerZone>().active = true;
                dangerZones[1].gameObject.SetActive(true);
                dangerZones[1].GetComponent<DangerZone>().active = true;
                dangerZones[5].gameObject.SetActive(true);
                dangerZones[5].GetComponent<DangerZone>().active = true;
                dangerZones[6].gameObject.SetActive(true);
                dangerZones[6].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (i == 14)
            {
                dangerZones[8].gameObject.SetActive(true);
                dangerZones[8].GetComponent<DangerZone>().active = true;
                dangerZones[9].gameObject.SetActive(true);
                dangerZones[9].GetComponent<DangerZone>().active = true;
                dangerZones[13].gameObject.SetActive(true);
                dangerZones[13].GetComponent<DangerZone>().active = true;
                dangerZones[14].gameObject.SetActive(true);
                dangerZones[14].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
        }
        if (wave3)
        {
            for (int j = 0; j < 15; j++)
            {
                if (j == i)
                {
                    
                    continue;
                    
                }
                else if (j == (i+3))
                {
                    continue;
                }
                dangerZones[j].gameObject.SetActive(true);
                dangerZones[j].GetComponent<DangerZone>().active = true;
            }
            StartCoroutine(Cooldown(i));
            score++;
        }
        audioSource.PlayOneShot(GunshotSFX, 0.9f);
        catAnim.SetBool("Shooting", true);
    }
    IEnumerator Cooldown(int i)
    {
        yield return new WaitForSeconds(0.5f);
        for (int j = 0;j<15 ;j++)
        {
            dangerZones[j].GetComponent<DangerZone>().active = false;
            dangerZones[j].gameObject.SetActive(false);
            reticles[j].SetActive(false);
        }
        playerHealth.IncrementScore();
        yield return new WaitForSeconds(2f);
        active = true;
    }
/*    IEnumerator Countdown()
    {

    }*/
    IEnumerator Preshoot(int i)
    {
        if (wave1)
            yield return new WaitForSeconds(0.5f);
        else if (wave2)
            yield return new WaitForSeconds(0.6f);
        else if (wave3)
            yield return new WaitForSeconds(0.8f);
        Shoot(i);
    }
    IEnumerator Flash()
    {
        white.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        white.SetActive(false);
        black.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        black.SetActive(false);
    }
}
