using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public TextMeshProUGUI countdownDisplay;

    public void Start()
    {
        StartCoroutine(CountdownToStart());
    }
    IEnumerator CountdownToStart()
    {
        while(countdownTime>0)
        {
            countdownDisplay.text = countdownTime.ToString();
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "FLY!";
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().wave1 = true;
        
    }
}
