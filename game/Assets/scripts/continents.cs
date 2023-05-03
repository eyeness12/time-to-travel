using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class continents : MonoBehaviour
{
    public void goafrica()
    {
        SceneManager.LoadScene("africa");

    }
    public void goasia()
    {
        SceneManager.LoadScene("asia");

    }
    public void goaustarlia()
    {
        SceneManager.LoadScene("australia");

    }
    public void gonorth()
    {
        SceneManager.LoadScene("north");

    }
    public void gosouth()
    {
        SceneManager.LoadScene("south");

    }
    public void goeurope()
    {
        SceneManager.LoadScene("europe");

    }
    public void play()
    {
        SceneManager.LoadScene("MainGame");

    }

}
