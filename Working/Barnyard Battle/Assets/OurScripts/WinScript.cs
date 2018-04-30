﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour {

	public void PlayAgain()
    {
        SceneManager.LoadScene("game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
