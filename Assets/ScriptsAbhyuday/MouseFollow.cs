using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]private Camera maincamera;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 Position = new Vector2(0, 0);
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        //transform.position= Vector2.MoveTowards(transform.position, mousePos, moveSpeed*Time.deltaTime);
        /*Position = Vector2.Lerp(transform.position, mousePos, moveSpeed*Time.deltaTime);*/
        transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
    /*private void FixedUpdate()
    {
        rb.MovePosition(Position);
    }*/
}
