using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<DangerZone> DangerZones;
    public List<GameObject> Reticles;
    public bool active;
    public int currentPos;

    void Update()
    {
        if (active)
        {
            Aiming();
        }
    }

    public void Aiming()
    {
        int i = currentPos;
        Reticles[currentPos].SetActive(true);
        active = false;
        StartCoroutine(Preshoot(i));
    }
    void Shoot(int i)
    {
        DangerZones[i].gameObject.SetActive(true);
        DangerZones[i].GetComponent<DangerZone>().active = true;
        StartCoroutine(Cooldown(i));
    }
    IEnumerator Cooldown(int i)
    {
        yield return new WaitForSeconds(3f);
        DangerZones[i].gameObject.SetActive(false);
        DangerZones[i].GetComponent<DangerZone>().active = false;
        Reticles[i].SetActive(false);
        active = true;
    }
    IEnumerator Preshoot(int i)
    {
        yield return new WaitForSeconds(0.5f);
        Shoot(i);
    }
}
