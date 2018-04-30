using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaturePicker : PWPawn {

    public int index1 = 0;
    public int index2 = 0;
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
        index1 = 0;
    }

    public void Cow()
    {
        index1 = 1;
    }

    public void Pig()
    {
        index1 = 2;
    }

    public void Chicken2()
    {
        index2 = 0;
    }

    public void Cow2()
    {
        index2 = 1;
    }

    public void Pig2()
    {
        index2 = 2;
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

    public int GetIndex1()
    {
        return index1;//sends picked animal to PWC
    }

    public int GetIndex2()
    {
        return index2;//sends picked animal to PWC
    }
}
