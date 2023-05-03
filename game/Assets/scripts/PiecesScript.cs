using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PiecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightposition;
    public bool selected;
   
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(3.15f, 9f),Random.Range(-4.5f,3.5f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,RightPosition) < 0.5f)
        {  if (!selected)
            {
                if (InRightposition == false)
                {
                    transform.position = RightPosition;
                    InRightposition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
            }
        }
    }
}
