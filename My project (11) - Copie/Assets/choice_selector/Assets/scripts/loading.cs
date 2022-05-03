using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{ public Slider loadingslider;
  public string scenename ;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine("loading_d"); 
    }

    // Update is called once per frame
    void Update()
    {
        if (loadingslider.value == 100) {
           LoadScene(scenename );

        }
    }
    IEnumerator loading_d(){
        yield return new WaitForSeconds(1);
        loadingslider.value = 25;
        yield return new WaitForSeconds(3);
        loadingslider.value = 40;
        yield return new WaitForSeconds(1);
        loadingslider.value = 60;
        yield return new WaitForSeconds(2);
        loadingslider.value = 100;


    } 
    public void LoadScene(string scenename){
      SceneManager.LoadScene(scenename);
  }
}