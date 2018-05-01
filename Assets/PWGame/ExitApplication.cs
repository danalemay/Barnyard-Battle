using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApplication : MonoBehaviour {

    public Canvas exit;

    void Start()
    {
        exit.GetComponent<Canvas>().enabled = false;
    }
    public void Exit()
    {
        exit.GetComponent<Canvas>().enabled = false;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
