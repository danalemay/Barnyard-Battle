using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameras : MonoBehaviour {

   public Camera cam1;
   public Camera cam2;
    public Camera main;
    public bool camSwitch = false;

    public void Start()
    {
        //cam1 = GameObject.FindGameObjectWithTag("Cam1").GetComponent<Camera>(); //Camera cam = GameObject.Find("myObject").GetComponent<Camera>();
        //cam2 = GameObject.FindGameObjectWithTag("Cam2").GetComponent<Camera>();

        //main.GetComponent<Camera>().enabled = true;
        main.gameObject.SetActive(true);
        //cam1.GetComponent<Camera>().enabled = false;//SetActive(false);
        //cam2.GetComponent<Camera>().enabled = false;
//cam1.gameObject.SetActive(false);
       // cam2.gameObject.SetActive(false);
    }

    public void Switch()
    {
        //cam1.GetComponent<Camera>().enabled = camSwitch;//gameObject.SetActive(camSwitch);
        //cam2.GetComponent<Camera>().enabled = camSwitch;//gameObject.SetActive(camSwitch);
        //main.GetComponent<Camera>().enabled = !camSwitch;
        //cam2.gameObject.SetActive(true);
        //cam1.gameObject.SetActive(true);
        main.gameObject.SetActive(false);

    }
}
