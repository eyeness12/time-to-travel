using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addbutton : MonoBehaviour
{
    [SerializeField]
    private Transform panel;
    [SerializeField]
    private GameObject btn;
    [SerializeField]
    public int number ;
    void Awake(){
        for (int i=0 ;i<number ; i++){
            GameObject button= Instantiate(btn);// on cree une instance de button
            button.name=""+i;// son nom va etre un numero 
            button.transform.SetParent(panel, false);


        }

    }
}

