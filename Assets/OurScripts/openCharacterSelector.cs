﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class openCharacterSelector : PWPawn {

    int whichButton = 0;
    int DelayCounter = 0;
    int DelayMax = 10;
    bool DelayOn = false;
    public GameObject PlayPos;
    public GameObject InstructPos;
    public GameObject QuitPos;

    public void ChangeScene(int changeTheScene)
    {
        SceneManager.LoadScene("game");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void Controls()
    {
        SceneManager.LoadScene("instructions");
    }

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
                SceneManager.LoadScene("instructions");
            }
            if (whichButton == 2)
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
        if (whichButton == 2)
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
            PlayPos.SetActive(true);
            InstructPos.SetActive(false);
            QuitPos.SetActive(false);
        }
        if (whichButton == 1)
        {
            PlayPos.SetActive(false);
            InstructPos.SetActive(true);
            QuitPos.SetActive(false);
        }
        if(whichButton == 2)
        {
            PlayPos.SetActive(false);
            InstructPos.SetActive(false);
            QuitPos.SetActive(true);
        }
    }
}