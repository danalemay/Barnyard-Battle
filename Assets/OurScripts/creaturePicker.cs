using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePicker : PWPawn {

    public int whichCreature = 0;
    public Canvas CanvasObject;
    public GameObject chickenPos;
    public GameObject cowPos;
    public GameObject pigPos;

    /*void Awake()
    { 
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scripty");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }*/

    public void Chicken()
    {
        whichCreature = 0;
    }

    public void Cow()
    {
        whichCreature = 1;
    }

    public void Pig()
    {
        whichCreature = 2;
    }

    public void Ready() //hides canvas
    {
        //CanvasObject.GetComponent<Canvas>().enabled = true;
        // canvas.SetActive(false);
        //if (this.enabled == true)
        //{
        if(CanvasObject.name == "selection1")
        { 
            CanvasObject.GetComponent<Canvas>().enabled = false;
        }
        if (CanvasObject.name == "selection2")
        {
            CanvasObject.GetComponent<Canvas>().enabled = false;
        }
    }

    public void ToggleWhichCreature()
    {
        if(whichCreature == 2)
        {
            whichCreature = 0;
        }
        else
        {
            whichCreature++;
        }
    }

    void Update()
    {
        UpdateSelectorSpinner();
    }

    public void UpdateSelectorSpinner()
    {
        if (whichCreature == 0)
        {
            chickenPos.SetActive(true);
            cowPos.SetActive(false);
            pigPos.SetActive(false);
        }
        if (whichCreature == 1)
        {
            chickenPos.SetActive(false);
            cowPos.SetActive(true);
            pigPos.SetActive(false);
        }
        if (whichCreature == 2)
        {
            chickenPos.SetActive(false);
            cowPos.SetActive(false);
            pigPos.SetActive(true);
        }
    }

    public int GetIndex()
    {
        //Debug.Log(whichCreature);

        return whichCreature;//sends picked animal to PWC
    }
}
