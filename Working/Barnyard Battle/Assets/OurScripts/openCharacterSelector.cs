﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class openCharacterSelector : PWPawn {

    public void ChangeScene(int changeTheScene)
    {
        SceneManager.LoadScene(changeTheScene);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("P2Fire1"))
        {
            SceneManager.LoadScene("CharacterSelection2");
        }
    }
}