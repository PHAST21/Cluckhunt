using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float Lives;
    // Start is called before the first frame update
    private void Update()
    {
        if (Lives <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
   public void TakeDamage()
    {
        Lives--;
    }
    
}
