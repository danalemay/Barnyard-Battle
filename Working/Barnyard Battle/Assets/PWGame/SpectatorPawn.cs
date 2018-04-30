using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

   public override void Fire1(bool value)
    {
        if (value)
        {
            
        }
    }

     /*public override void Fire2(bool value)
     {
         
            if (value)
            {
            Selection = GameObject.Find("selection").GetComponent<Canvas>();

            if (Selection.enabled == false)
            {
                controller.RequestSpawn();
                }
            }
     }*/
     

}
