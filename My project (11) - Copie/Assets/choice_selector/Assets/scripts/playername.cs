using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playername : MonoBehaviour

{
    public string nameplayer;
    public string savename;
    public Text inputtext;
    public Text loadedname;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        nameplayer = PlayerPrefs.GetString("name" , "none");
        loadedname.text=nameplayer;//playerprefs est une classe qui permet de sauvegarder les données de l'utilisateur sur le disque get pour charger la valeur et set pour sauvegarder
    }
    public void setname(){
        savename = inputtext.text ;
        PlayerPrefs.SetString("name",savename);

    }   
}
