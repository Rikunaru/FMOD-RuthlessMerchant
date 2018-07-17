using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    public RaycastHit hit;

    // Use this for initialization
    void Start () {
        //Hide cursor
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
        //RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100))
        {
            Debug.Log(hit.transform.name);
        }
	}
}
