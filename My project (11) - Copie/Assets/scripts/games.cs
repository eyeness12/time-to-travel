using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class games : MonoBehaviour
{
    public Text scenemanager;


    // Update is called once per frame
    public void game()
    {
       
        
            SceneManager.LoadScene(scenemanager.text);
        
       

    }
}