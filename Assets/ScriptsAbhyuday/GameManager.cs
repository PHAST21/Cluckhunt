using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<DangerZone> dangerZones;
    public List<GameObject> reticles;
    public GameObject white, black;
    public bool active,wave1,wave2,wave3;
    public int currentPos,score;
    private MouseFollow PlayerMovement;
    private Health playerHealth;

    private void Start()
    {
        wave1 = true;
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<MouseFollow>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
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
                reticles[currentPos].SetActive(true);
                reticles[currentPos + 5].SetActive(true);
                reticles[currentPos - 1].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos == 4)
            {
                int i = currentPos;
                reticles[currentPos].SetActive(true);
                reticles[currentPos + 5].SetActive(true);
                reticles[currentPos + 4].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos > 4 && currentPos < 9) 
            {
                int i = currentPos;
                reticles[currentPos].SetActive(true);
                reticles[currentPos - 5].SetActive(true);
                reticles[currentPos + 1].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos == 9)
            {
                int i = currentPos;
                reticles[currentPos].SetActive(true);
                reticles[currentPos + 5].SetActive(true);
                reticles[currentPos - 5].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }
            else if (currentPos > 9 && currentPos < 14)
            {
                int i = currentPos;
                reticles[currentPos].SetActive(true);
                reticles[currentPos + 1].SetActive(true);
                reticles[currentPos - 5].SetActive(true);
                active = false;
                StartCoroutine(Preshoot(i));
            }

            else if (currentPos == 0)
            {
                int i = currentPos;
                reticles[currentPos].SetActive(true);
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
                reticles[currentPos].SetActive(true);
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
                reticles[j].SetActive(true);
            }
            active = false;
            StartCoroutine(Preshoot(i));
        }
    }
    void Shoot(int i)
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
            if (currentPos>0&&currentPos<4)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 5].gameObject.SetActive(true);
                dangerZones[currentPos + 5].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos - 1].gameObject.SetActive(true);
                dangerZones[currentPos - 1].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (currentPos == 4)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 5].gameObject.SetActive(true);
                dangerZones[currentPos + 5].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 4].gameObject.SetActive(true);
                dangerZones[currentPos + 4].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (currentPos > 4 && currentPos < 9)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos - 5].gameObject.SetActive(true);
                dangerZones[currentPos - 5].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 1].gameObject.SetActive(true);
                dangerZones[currentPos + 1].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if(currentPos == 9)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 5].gameObject.SetActive(true);
                dangerZones[currentPos + 5].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos - 5].gameObject.SetActive(true);
                dangerZones[currentPos - 5].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if (currentPos > 9 && currentPos < 14)
            {
                dangerZones[i].gameObject.SetActive(true);
                dangerZones[i].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos + 1].gameObject.SetActive(true);
                dangerZones[currentPos + 1].GetComponent<DangerZone>().active = true;
                dangerZones[currentPos - 5].gameObject.SetActive(true);
                dangerZones[currentPos - 5].GetComponent<DangerZone>().active = true;
                StartCoroutine(Cooldown(i));
                score++;
            }
            else if( currentPos ==0) {
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
            else if (currentPos == 14)
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
                dangerZones[j].gameObject.SetActive(true);
                dangerZones[j].GetComponent<DangerZone>().active = true;
            }
            StartCoroutine(Cooldown(i));
            score++;
        }
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
    IEnumerator Preshoot(int i)
    {
        yield return new WaitForSeconds(0.5f);
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
