using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class persistenceTest : MonoBehaviour {

    static int numberOfClicks = 69;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("scripty");
        if(objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        Debug.Log(numberOfClicks);
    }

    public void teesting()
    {
        numberOfClicks += 1;
    }
}
