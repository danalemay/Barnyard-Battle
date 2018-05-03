using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlOneButtonPush : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("P2Fire1"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
