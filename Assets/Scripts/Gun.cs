using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Gun : MonoBehaviour {
    
    private Handedness handedness;
    private Grabber myGrabber;

    public GameObject bullet;

    public GameObject robot;

    private void Start() {
        myGrabber = GetComponent<Grabber>();
        handedness = myGrabber.handedness;
    }

    
    void Update() {
        if (VRInput.GetDown(GenericVRButton.Index, handedness)) 
            Shoot();
        
    }

    private void Shoot() {
        RaycastHit hit;
        Destroy(Instantiate(bullet, transform.position, transform.rotation), 2f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 1))
        {
            GameObject target = hit.collider.gameObject;
            if(target.tag == "Enemy"){
                robot.target = target;
            }
        }
        
    }
    
    
}
