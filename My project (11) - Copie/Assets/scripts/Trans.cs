using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trans : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 0.05f;

    // Update is called once per frame
    void Update()
    {  if(Input.GetMouseButtonDown(0))
        {
            LoadNextScene();
        }
        
    }
    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }
    IEnumerator LoadLevel(int levelIndex)
    {   //play animation
        transition.SetTrigger("Start");
        //wait
        yield return new WaitForSeconds(transitionTime);
        //load scene
        SceneManager.LoadScene(levelIndex);
    }
}
