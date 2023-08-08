using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class FortuneWheelScript : MonoBehaviour
{
    public bool spinningAllowed;
    public float timeInterval;
    public int randomwheelSpins, finalAngle;
    float rotationIncrement = 45f;
    public TMP_Text spinOutput;
    public Button SpinButton;
    void Start()
    {
        spinningAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  spiningButton()
    {
        if (spinningAllowed==true)
        {
           StartCoroutine(Spin());
            //spin();
        }
    }

    IEnumerator Spin()
    {
        spinningAllowed = false;
        Debug.Log($"Called button Click");
        randomwheelSpins = Random.Range(10, 25);
        timeInterval = 0.1f;

        for (int i = 0; i < randomwheelSpins; i++)
        {
            float newAngle = transform.eulerAngles.z + rotationIncrement;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, newAngle));

            if (i>Mathf.RoundToInt(randomwheelSpins*0.5f))
            {
                timeInterval = 0.2f;
            }
            if (i > Mathf.RoundToInt(randomwheelSpins * 0.8f))
            {
                timeInterval = 0.4f;
            }


            yield return new WaitForSeconds(timeInterval);
        }


        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);


        AngleRotateValues();
    }



    public void AngleRotateValues()
    {
        switch (finalAngle)
        {
            case 0:
                spinOutput.text = $"You Won 5 coins";
                break;
            case 45:
                spinOutput.text = $"You Won 0 coins";
                break;
            case 90:
                spinOutput.text = $"You Won 20 coins";
                break;
            case 135:
                spinOutput.text = $"You Won 25 coins";
                break;
            case 180:
                spinOutput.text = $"You Won 30 coins";
                break;
            case 225:
                spinOutput.text = $"You Won 35 coins";
                break;
            case 270:
                spinOutput.text = $"You Won 40 coins";
                break;
            case 315:
                spinOutput.text = $"You Won 50 coins";
                break;
        }

        spinningAllowed = true;
    }






}
