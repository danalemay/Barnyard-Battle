using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loserMenus : MonoBehaviour {

    int whichButton = 0;
    int DelayCounter = 0;
    int DelayMax = 10;
    bool DelayOn = false;

    void Update()
    {
        if(DelayOn == true)
        {
            DelayCounter++;
            if(DelayCounter >= DelayMax)
            {
                DelayCounter = 0;
                DelayOn = false;
            }
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("P2Fire1"))
        {
            if(whichButton == 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
            if (whichButton == 1)
            {
                SceneManager.LoadScene("game");
            }
        }

        if(Input.GetButtonDown("Vertical") || Input.GetButtonDown("P2Vertical"))
        {
            if(DelayOn == false)
            {
                ToggleWhichButton();
            } 
        }
        Debug.Log(whichButton);
    }

    public void ToggleWhichButton()
    {
        DelayOn = true;
        if (whichButton == 1)
        {
            whichButton = 0;
        }
        else
        {
            whichButton++;
        }
    }
}
