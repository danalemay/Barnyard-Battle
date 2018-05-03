using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DomsMenuScript : MonoBehaviour {

    int whichButton = 0;
    int DelayCounter = 0;
    int DelayMax = 10;
    bool DelayOn = false;
    public GameObject BackToGamePos;
    public GameObject QuitPos;

    void Update()
    {
        UpdateSelectorSpinner();
        if (DelayOn == true)
        {
            DelayCounter++;
            if (DelayCounter >= DelayMax)
            {
                DelayCounter = 0;
                DelayOn = false;
            }
        }

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("P2Fire1"))
        {
            if (whichButton == 0)
            {
                SceneManager.LoadScene("game");
            }
            if (whichButton == 1)
            {
                Application.Quit();
            }
        }

        if ((Input.GetAxis("Vertical") < 0) || (Input.GetAxis("P2Vertical") < 0))
        {
            if (DelayOn == false)
            {
                ToggleWhichButton();
            }
        }
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

    public void UpdateSelectorSpinner()
    {
        if (whichButton == 0)
        {
            BackToGamePos.SetActive(true);
            QuitPos.SetActive(false);
        }
        if (whichButton == 1)
        {
            BackToGamePos.SetActive(false);
            QuitPos.SetActive(true);
        }
    }
}
