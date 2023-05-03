using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class puzzleSelect : MonoBehaviour
{
    public GameObject StartPanel;
    public void SetPuzzlePhoto(Image Photo)
    {
        
        for(int i=0;i<36;i++)
        {
            GameObject.Find("Piece (" + i + ")").transform.Find("puzzle").GetComponent<SpriteRenderer>().sprite=Photo.sprite;
        }
        StartPanel.SetActive(false);
    }





}
