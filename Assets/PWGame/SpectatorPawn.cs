using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpectatorPawn : PWPawn {

    Canvas Selection1;
    Canvas Selection2;
    SwitchCameras SC;
    int DelayCounter = 0;
    int DelayMax = 10;
    bool DelayOn = false;

    // public GameObject switcher;


    void Start()
    {
        SC = GameObject.Find("InputPoller").GetComponent<SwitchCameras>(); 
        //SC.StartG();
    }
    /* void Update()
     {
         CP = canvas.GetComponent<CreaturePicker>();

         if (!CP)
         { 
             Debug.Log("didnt get script");
             return;
         }
         index = CP.GetIndex();

         HUD = GameObject.Find("HUDCanvas").GetComponent<Canvas>();

         if (HUD.enabled)
         {
             GetPawn();
         }
     }*/

    //private void GetPawn()
    void Update()
    {
        if (DelayOn == true)
        {
            DelayCounter++;
            if (DelayCounter >= DelayMax)
            {
                DelayCounter = 0;
                DelayOn = false;
            }
        }

        Selection1 = GameObject.Find("selection1").GetComponent<Canvas>();
        Selection2 = GameObject.Find("selection2").GetComponent<Canvas>();

        if (Selection1.enabled == false && Selection2.enabled == false)
        {
            PWPlayerController PWC = (PWPlayerController)controller;
            //CameraController CC = (CameraController)Pawn;
            
            if (!PWC)
            {
                return;
            }
            SC.Switch(); //changes cameras
           // CC.StartG();
            PWC.ChangeSpawnPrefab();
            controller.RequestSpawn();
            //PWC.CamOn();//calls Camera controller to make the cameras look at players
        }
    }

    public override void Vertical(float value)
    {
        if (value > 0)
        {
            if (DelayOn == false)
            {
                if (controller.PlayerNumber == 0)
                {
                    DelayOn = true;
                    Selection1.GetComponent<CreaturePicker>().ToggleWhichCreature();
                }
                if (controller.PlayerNumber == 1)
                {
                    DelayOn = true;
                    Selection2.GetComponent<CreaturePicker>().ToggleWhichCreature();
                }
            }
        }
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            if (value)
            {
                if (controller.PlayerNumber == 0)
                {
                    Selection1.GetComponent<CreaturePicker>().Ready();
                }
                if (controller.PlayerNumber == 1)
                {
                    Selection2.GetComponent<CreaturePicker>().Ready();
                }
                
            }
        }
    }

     public override void Fire2(bool value)
     {
         
            if (value)
            {
            
            }
     }
}
