using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePicker : PWPawn {

    public int whichCreature = 0;
    public Canvas CanvasObject;
    

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

    public int GetIndex()
    {

        return whichCreature;//sends picked animal to PWC
    }
}
