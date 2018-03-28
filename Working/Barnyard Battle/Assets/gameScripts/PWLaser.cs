using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWLaser : MonoBehaviour
{
    LineRenderer line;

    void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        line.enabled = false;
    }
	
	void Update () {
        StopCoroutine("FireLaser");
        StartCoroutine("FireLaser");
        /*RaycastHit hitinfo;
        Debug.Log("raycast out");
        if (Physics.Raycast(barrelEnd.position, barrelEnd.forward, out hitinfo, 100))
        {
            Debug.Log("Raycast Hit " + hitinfo.collider.name);

        }*/
    }
    IEnumerator FireLaser()
    {
        line.enabled = true;

        while (Input.GetButton("Fire1"))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            line.SetPosition(0, ray.origin);
            line.SetPosition(1, ray.GetPoint(100));
            yield return null;
        }

        line.enabled = false;
    }
}
