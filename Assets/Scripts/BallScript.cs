using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject blueBrick;
    public float velocity2 = 550f;
    public GameObject GamePlayScriptObj;

    [Header("Dynamic")]
    private int heartCounter = 3;
    float cameraSize;
    Vector3 brickScale;
    Rigidbody2D rb;
    Vector3 newposition;
    Vector3 boardpos;
    GameObject board;
   // GameObject[] bluebricks, redbricks, purplebricks;
    GamePlayManager gamePlayManager;
    AudioSource audio;
    SceneManager Gmanager;

    // Start is called before the first frame update
    void Start()
    {
        gamePlayManager = GamePlayScriptObj.GetComponent<GamePlayManager>();
        Gmanager = GamePlayScriptObj.GetComponent<SceneManager>();
        audio = GetComponent<AudioSource>(); 
        rb = GetComponent<Rigidbody2D>();
        board = GameObject.Find("board");
        cameraSize = Camera.main.orthographicSize;
        
        boardpos = new Vector3(board.transform.position.x, board.transform.position.y, board.transform.position.z);
        
    }
    //public event Action bottomWallTouch;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            gamePlayManager.HideText();
        }
    }

    private void FixedUpdate()
    {
        if(transform.position.y < -cameraSize)
        {
            if (heartCounter > 0)
            {

                board.transform.position = boardpos;
                rb.bodyType = RigidbodyType2D.Static;
                transform.position = new Vector3(0, -2, 0);
                gamePlayManager.DestroyHeart(heartCounter);
                gamePlayManager.DisplayText();
            }
            else if (heartCounter <= 0)
                Gmanager.LooseScene();
            heartCounter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "board")
        {
            float hit = transform.position.x - collision.transform.position.x;
            float size = collision.gameObject.transform.GetComponent<Renderer>().bounds.size.x / 2;
            float x = hit / size;
            rb.AddForce(new Vector2(x, 1) * velocity2 * Time.deltaTime, ForceMode2D.Impulse);
        }

        else if (collision.gameObject.tag == "blue_brick")
        {
            audio.Play();
            Destroy(collision.gameObject);            
            gamePlayManager.MakeScore();
        }

        else if (collision.gameObject.tag == "red_brick" || collision.gameObject.tag == "purple_brick")
        {
            audio.Play();
            newposition = collision.gameObject.transform.position;
            brickScale = collision.gameObject.transform.lossyScale;
        }

        else if (collision.gameObject.tag == "leftWall")
        {
            float hit = transform.position.y - collision.transform.position.y;
            float size = collision.gameObject.transform.GetComponent<Renderer>().bounds.size.y / 2;
            float y = hit / size;
            rb.AddForce(new Vector2(1,y) * 200f * Time.deltaTime, ForceMode2D.Impulse);
        }

        else if (collision.gameObject.tag == "leftWall")
        {
            float hit = transform.position.y - collision.transform.position.y;
            float size = collision.gameObject.transform.GetComponent<Renderer>().bounds.size.y / 2;
            float y = hit / size;
            rb.AddForce(new Vector2(1, -y) * 200f * Time.deltaTime, ForceMode2D.Impulse);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "red_brick" || collision.gameObject.tag == "purple_brick")
        {
            Destroy(collision.gameObject);
            GameObject blBrick = Instantiate<GameObject>(blueBrick);
            blBrick.transform.localScale = brickScale;
            blBrick.transform.position = newposition;
        }
    }


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(2);
    }
}
    // Update is called once per frame
    

