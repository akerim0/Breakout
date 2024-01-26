using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BricksManager : MonoBehaviour
{
    GameObject[] bluebricks, redbricks, purplebricks;
    public static int bluebrickcount, redbrickcount, purplebrickcount;
    int numofbricks;
    public GameObject refr;
    SceneManager gameM;
    // Start is called before the first frame update
    void Start()
    {
        gameM = refr.GetComponent<SceneManager>();
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        bluebricks = GameObject.FindGameObjectsWithTag("blue_brick");
        redbricks = GameObject.FindGameObjectsWithTag("red_brick");
        purplebricks = GameObject.FindGameObjectsWithTag("purple_brick");
        redbrickcount = redbricks.Length;
        purplebrickcount = purplebricks.Length;
        bluebrickcount = bluebricks.Length;
        numofbricks = bluebrickcount + redbrickcount + purplebrickcount;
        if (numofbricks == 0)
            gameM.WinScene();
        
    }
}
