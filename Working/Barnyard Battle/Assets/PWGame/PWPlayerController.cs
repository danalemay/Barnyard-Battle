using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class PWPlayerController : PlayerController {

    public List<GameObject> SpawnPrefabList;
    int SpawnPrefabListindex = 0;

    public bool IgnoreHudError = false; 
    public Canvas ExitPanel;

    public Canvas canvas;
    creaturePicker CP;
    

    protected override void Start () {
        base.Start();
        LogInputStateInfo = false; 
       
	}

    protected override void UpdateHUD()
    {
        if (!HUD && !PossesedPawn)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("No Hud or Pawn!");
            }
            return; 
        }

        PWHUD hud = HUD.GetComponent<PWHUD>(); 
        if (!hud)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("No Hud Class found");
            }
            return;
        }

        PWPawn pawn = (PWPawn)PossesedPawn; 
        if (!pawn)
        {
            if (!IgnoreHudError)
            {
                LOG_ERROR("Controller doesn't have a PWPawn");
            }
            return; 
        }

        if (PossesedPawn.IsSpectator)
        {
            hud.ActivePanel.SetActive(false);
            hud.SpectatePanel.SetActive(true);
            hud.PlayerNumber = (this.InputPlayerNumber + 1);
            hud.SpawnName = SpawnPreFab.name;
            //hud.Score = (int)pawn.Score;
        }
        else
        {
            hud.ActivePanel.SetActive(true);
            hud.SpectatePanel.SetActive(false);
            hud.PlayerNumber = (this.InputPlayerNumber + 1);
            hud.Shields = (int)pawn.Shields;
            hud.Energy = (int)pawn.Energy;
        }
        
    }

    public override void Horizontal(float value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Horizontal(value); 
        }
    }

    public override void Vertical(float value)
    {
        //LOG(GetPossesedPawn().ToString()); 
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Vertical(value);
        }
    }

    public override void Fire1(bool value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire1(value);
        }
    }

    public override void Fire2(bool value)
    {
        PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire2(value);
        }
    }

    public override void Fire3(bool value)
    {
        /*PWPawn CP = (PWPawn)PossesedPawn;
        if (CP)
        {
            CP.Fire3(value);
        }*/
        if (value)
        {
            //ExitPanel.SetActive(!ExitPanel.activeSelf);

            ExitPanel.GetComponent<Canvas>().enabled = true;

            /*if (ExitPanel.enabled == true)
            {
                Debug.Log("turn on panel");
                ExitPanel.GetComponent<Canvas>().enabled = false;
            }
            else
            {
                Debug.Log("turn off panel");
                ExitPanel.GetComponent<Canvas>().enabled = true;
            }*/
        }
    }

    public override void Fire4(bool value)
    {
        if (value)
        {
            //ExitPanel.SetActive(!ExitPanel.activeSelf);
        }   
    }

    public void NextSpawnPrefab()
    {
        SpawnPrefabListindex++;
        if (SpawnPrefabListindex >= SpawnPrefabList.Count)
        {
            SpawnPrefabListindex = 0;
        }

        SpawnPreFab = SpawnPrefabList[SpawnPrefabListindex];
    }

    public void PreviousSpawnPrefab()
    {
        SpawnPrefabListindex--;
        if (SpawnPrefabListindex <= -1)
        {
            SpawnPrefabListindex = SpawnPrefabList.Count - 1;
        }

        SpawnPreFab = SpawnPrefabList[SpawnPrefabListindex];
    }

    public void ChangeSpawnPrefab()
    {
        CP = canvas.GetComponent<creaturePicker>();
        if (!CP)
        {
            Debug.Log("didnt get script");
            return;
        }
        SpawnPreFab = SpawnPrefabList[CP.GetIndex()];
    }

}
