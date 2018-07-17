using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickuptest : MonoBehaviour {

    [FMODUnity.EventRef]
    public string itemPickupSound;
    FMOD.Studio.EventInstance soundevent;

    // Use this for initialization
    void Start () {
        soundevent = FMODUnity.RuntimeManager.CreateInstance(itemPickupSound);
    }

    private void Update()
    {
        transform.Rotate(0, 5, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot(itemPickupSound, GetComponent<Transform>().position);
        this.gameObject.SetActive(false);
    }
}
