using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    public bool active;

    [SerializeField]private Health playerHealth;
     void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (active)
        {
            if(collision.gameObject.CompareTag("Player"))
            {
                Debug.Log("gmaing");
                playerHealth.TakeDamage();
            }
        }
    }
}
