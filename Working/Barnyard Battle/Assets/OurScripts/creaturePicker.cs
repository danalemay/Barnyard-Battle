using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creaturePicker : MonoBehaviour {

    static int whichCreatureP1 = 0;
    static int whichCreatureP2 = 0;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scripty");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
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
        if(whichCreatureP2 == 3)
        {
            whichCreatureP2 = 1;
        }
        else
        {
            whichCreatureP2 += 1;
        }
    }

    private void Update()
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
    }
}
