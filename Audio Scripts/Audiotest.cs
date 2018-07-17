using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiotest : MonoBehaviour {

    [FMODUnity.EventRef]
    public string selectSound;
    FMOD.Studio.EventInstance soundevent;

    public KeyCode presstoplaysound;

    RaycastHit _hit;
    Crosshair _crosshair;


    // Use this for initialization
    void Start () {
        soundevent = FMODUnity.RuntimeManager.CreateInstance(selectSound);
        GameObject mainCamera = GameObject.Find("MainCamera");
        _crosshair = mainCamera.GetComponent<Crosshair>();
	}
	
	// Update is called once per frame
	void Update () {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(soundevent, GetComponent<Transform>(), GetComponent<Rigidbody>());
        Playsound();
	}

    void Playsound()
    {
        if (Input.GetKeyDown(presstoplaysound))
        {
            if(_crosshair.hit.transform.name == "Torch" || _crosshair.hit.transform.name == "Stepper")
            {
                soundevent.start();
                Debug.Log("Aimed Event called");
            }
        }
    }
}
