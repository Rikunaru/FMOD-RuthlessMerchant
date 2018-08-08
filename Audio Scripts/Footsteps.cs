using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string Steps;
    public float stepSpeed;
    public float stepsoundValue;
    public float stepsoundFinalValue;
    public float testgeding;

    private string soundToPlay;
    private bool playerismoving;
    private FMOD.Studio.EventInstance stepSound;
    private FMOD.Studio.ParameterInstance floorMaterial;
 
    void Update()
    {
        if (Input.GetAxis("Vertical") >= 0.01f || Input.GetAxis("Horizontal") >= 0.01f || Input.GetAxis("Vertical") <= -0.01f || Input.GetAxis("Horizontal") <= -0.01f)
        {
            //Debug.Log("Character is moving");
            playerismoving = true;
        }
        else if (Input.GetAxis("Vertical") == 0 || Input.GetAxis("Horizontal") == 0)
        {
            //Debug.Log("Character is not moving");
            playerismoving = false;
        }
    }

    void CheckTerrain()
    {
        //floorMaterial.setValue(0.8f);
    }

    void CallFootsteps()
    {
        if (playerismoving == true)
        {
            //Debug.Log("Stepsound playing");
            FMODUnity.RuntimeManager.PlayOneShot(Steps, GetComponent<Transform>().position);
            stepSound.getParameterValue("FloorMaterial", out stepsoundValue, out stepsoundFinalValue);
            //Debug.Log("Floorvalue: " + stepsoundValue + "Final Value" + stepsoundFinalValue);
            floorMaterial.setValue(testgeding);
        }
    }

    private void Awake()
    {
        CheckTerrain();
        
    }

    void Start()
    {
        InvokeRepeating("CallFootsteps", 0, stepSpeed);
        stepSound = FMODUnity.RuntimeManager.CreateInstance(Steps);
        ///This one works!!
        stepSound.getParameter("FloorMaterial", out floorMaterial);
        ///
        //stepSound.getParameter("FloorMaterial", out floorMaterial);
        //stepSound.getParameterValue("FloorMaterial", out stepsoundValue, out stepsoundFinalValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other);
    }

    void OnDisable()
    {
        playerismoving = false;
    }
}