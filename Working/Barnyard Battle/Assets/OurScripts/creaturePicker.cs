using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaturePicker : PWPawn {

    static int whichCreatureP1 = 0;
    static int whichCreatureP2 = 0;

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

    public void toggleP1()
    {
        if (whichCreatureP1 == 3)
        {
            whichCreatureP1 = 1;
        }
        else
        {
            whichCreatureP1 += 1;
        }
    }

    public void toggleP2()
    {
        if (whichCreatureP2 == 3)
        {
            whichCreatureP2 = 1;
        }
        else
        {
            whichCreatureP2 += 1;
        }
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
        if (Input.GetButtonDown("Fire1"))
        {
            toggleP1();
        }

        if (Input.GetButtonDown("P2Fire1"))
        {
            toggleP2();
        }

        Debug.Log(whichCreatureP1);
        Debug.Log(whichCreatureP2);
        //Debug.Log(whichCreature);

        return whichCreature;//sends picked animal to PWC
    }
}
