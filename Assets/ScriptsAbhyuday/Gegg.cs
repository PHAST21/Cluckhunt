using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gegg : MonoBehaviour
{
    private Score score;
    private Rigidbody2D rb;
    public float speed=10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score = GameObject.FindGameObjectWithTag("UI").GetComponent<Score>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * -1 * speed;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            score.bigPoint();
            Destroy(gameObject);
        }
    }
}
