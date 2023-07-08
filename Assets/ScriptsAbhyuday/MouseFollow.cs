using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseFollow : MonoBehaviour
{
    [SerializeField]private Camera maincamera;
    public float moveSpeed=3;
    private Rigidbody2D rb;
    private Vector2 Position = new Vector2(0, 0);
    private Vector3 screenBounds;
    void Start()
    {
        maincamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        screenBounds = maincamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, maincamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = maincamera.ScreenToWorldPoint(Input.mousePosition);
        //transform.position= Vector2.MoveTowards(transform.position, mousePos, moveSpeed*Time.deltaTime);
        /*Position = Vector2.Lerp(transform.position, mousePos, moveSpeed*Time.deltaTime);*/
        transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
    private void LateUpdate()
    {
        Vector3 viewpos = transform.position;
        viewpos.x = Mathf.Clamp(viewpos.x, screenBounds.x * -1, screenBounds.x);
        viewpos.y = Mathf.Clamp(viewpos.y, screenBounds.y * -1, screenBounds.y);
        transform.position = viewpos;
    }
    /*private void FixedUpdate()
    {
        rb.MovePosition(Position);
    }*/
}
