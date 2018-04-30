using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PWHUD : FrameworkHUD
{
    public int PlayerNumber = 0;
    public int Shields = 0;
    public int Energy = 0;
    public string SpawnName = "Bob";
    public int Lives = 0;

    public Text PlayerNumberField;
    public Text ShieldsField;
    public Text EnergyField;
    public Text SpawnPrefab;
    public Text LivesText;

    public GameObject ActivePanel;
    public GameObject SpectatePanel;

    private Canvas HUD;
    private Canvas Selection1;
    private Canvas Selection2;

    void Start()
    {
        HUD = GameObject.Find("HUDCanvas").GetComponent<Canvas>();
        HUD.GetComponent<Canvas>().enabled = false;
    }
    void Update() //this sets the canvas to active when the selection menu is disabled
    {
        Selection1 = GameObject.Find("selection1").GetComponent<Canvas>();
        Selection2 = GameObject.Find("selection2").GetComponent<Canvas>();

        if (Selection1.enabled == false && Selection2.enabled == false)
        {
            HUD = GameObject.Find("HUDCanvas").GetComponent<Canvas>();

            if (HUD.enabled == false)
            {
                HUD.GetComponent<Canvas>().enabled = true;
            }
        }
    }
    // Update is called once per frame
    public override void UpdateHUD()
    {
        if (PlayerNumberField)
        {
            PlayerNumberField.text = "Player " + PlayerNumber;
        }
        if (ShieldsField)
        {
            ShieldsField.text = "Shields: " + Shields;
        }
        if (EnergyField)
        {
            EnergyField.text = "Energy: " + Energy;
        }
        if (SpawnPrefab)
        {
            SpawnPrefab.text = SpawnName;
        }
        if (LivesText)
        {
            LivesText.text = "Lives: " + Lives;
        }
    }
}
