using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    int score;
    public Text scoretxt;
    public GameObject pressEnterText;
    public GameObject gameObj;
    BallScript ballScript;
    // Start is called before the first frame update
    private void Awake()
    {
        HideText();
    }
    void Start()
    {
        ballScript = gameObj.GetComponent<BallScript>();
        
    }

    public void MakeScore()
    {
        score++;
        scoretxt.text = score.ToString();
    }
    public void DisplayText()
    {
        pressEnterText.SetActive(true);
    }
    public void HideText()
    {
        pressEnterText.SetActive(false);
    }
    public void DestroyHeart(int counter)
    {
        GameObject heart = GameObject.Find("mini-heart_" + counter.ToString());
        Destroy(heart, 0.1f);
    }
}
