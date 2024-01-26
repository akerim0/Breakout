using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerLoose : MonoBehaviour
{
 
    public void ReturnMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void TryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 2);
    }
}
