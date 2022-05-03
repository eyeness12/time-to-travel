using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour
{
    
   public void goplay()
    {
        SceneManager.LoadScene("spin");
    }
    public void gomenu()
    {
        SceneManager.LoadScene("menu");
    }
    public void goname()
    {
        SceneManager.LoadScene("player game 1");
    }
}
