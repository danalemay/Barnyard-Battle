using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    //public Transform player;
    //private Vector3 offset;
    //public GameObject controller;
   // PWPlayerController PWC;
    Camera cam;
    //SwitchCameras SC;
   // int offset = 10;

    void Start()
    {
        //PWC = controller.GetComponent<PWPlayerController>();
        //player = PWC.SpectatorPreFab.transform;
        cam.enabled = false;
    }

    public void StartG()
    {
        //player = PWC.SpawnPreFab.transform;
        cam.enabled = true;

        //offset = transform.position - player.transform.position;
    }

    /*void Update()
    {
        Debug.Log("updating");
        //transform.position = m_Player.transform.position;
        player = PWC.SpawnPreFab.transform;

        this.transform.position = new Vector3(player.transform.position.x, offset, player.transform.position.z);
        transform.LookAt(player);
    }

    /*  void LateUpdate()
      {
          Debug.Log("lateupdate");
          transform.position = player.transform.position + offset;
      }*/
    
    
}


