﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpectatorPawn : PWPawn {
    Canvas Selection1;
    Canvas Selection2;
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
        Selection1 = GameObject.Find("selection1").GetComponent<Canvas>();
        Selection2 = GameObject.Find("selection2").GetComponent<Canvas>();

        if (Selection1.enabled == false && Selection2.enabled == false)
        {
            PWPlayerController PWC = (PWPlayerController)controller;

            if (!PWC)
            {
                return;
            }

            PWC.ChangeSpawnPrefab();
            controller.RequestSpawn();
        }
    }
    public override void Vertical(float value)
    {
        if (value > 0)
        {
            if (controller.PlayerNumber == 0)
            {
                Selection1.GetComponent<CreaturePicker>().ToggleWhichCreature();
            }
            if (controller.PlayerNumber == 1)
            {
                Selection2.GetComponent<CreaturePicker>().ToggleWhichCreature();
            }
        }
    }

    public override void Fire1(bool value)
    {
        if (value)
        {
            if(controller.PlayerNumber == 0)
            {
                Selection1.GetComponent<CreaturePicker>().Ready();
            }
            if(controller.PlayerNumber == 1)
            {
                Selection2.GetComponent<CreaturePicker>().Ready();
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
