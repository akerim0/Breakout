using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    string axisname = "Horizontal";
    public float velocity = 550f;
    Rigidbody2D rb;
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float moveaxis = Input.GetAxis(axisname);
        rb.velocity = new Vector2(1, 0) * velocity * moveaxis * Time.deltaTime;       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
            audio.Play();
    }
}
