using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class spin : MonoBehaviour
{
   
    int randVal;
    
    private bool isCoroutine1;
    private int finalAngle;

    public Text winText;
    public int section;
    float totalAngle;
    public string[] Prizename;

    //use this for initialization
    private void Start()
    {
        isCoroutine1 = true;
        totalAngle = 360 / section;

    }
    //update is called once per frame
    public void Buttonclicked()
    {
        if (isCoroutine1)
        {
            StartCoroutine(Spin());
        }
    }

    private IEnumerator Spin()
    {
        isCoroutine1 = false;
        randVal = Random.Range(150, 250);
        float timeInterval = 0.0001f * Time.deltaTime * 2;
        for (int i = 0; i < randVal; i++)
        {
            //start rotate
            transform.Rotate(0, 0, (totalAngle / 2));
            //to slow down the wheel
            if (i > Mathf.RoundToInt(randVal * 0.0002f))
                timeInterval = 0.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.0005f))
                timeInterval = 1f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.0007f))
                timeInterval = 1.5f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.0008f))
                timeInterval = 2f * Time.deltaTime;
            if (i > Mathf.RoundToInt(randVal * 0.0009f))
                timeInterval = 2.5f * Time.deltaTime;

            yield return new WaitForSeconds(timeInterval);

        }
        if (Mathf.RoundToInt(transform.eulerAngles.z) % totalAngle != 0) //when  the indicator stop between 2numbers , it will add aditional step
            transform.Rotate(0, 0, totalAngle / 2);
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);//round off  euler angle of wheel value
        print(finalAngle);
        //prize check
        for (int i = 0; i < section; i++)
        {
            if (finalAngle == i * totalAngle)
                winText.text = Prizename[i];
        }

        isCoroutine1 = true;

    }
    

}
