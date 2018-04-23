using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaturePicker : MonoBehaviour {

    static int whichCreature = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scripty");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void chicken()
    {
        whichCreature = 1;
    }

    public void cow()
    {
        whichCreature = 2;
    }

    public void pig()
    {
        whichCreature = 3;
    }

    private void Update()
    {
        Debug.Log(whichCreature);
    }
}
