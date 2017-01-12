using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float sanity = 100f;
    public int lights = 1;
    CharacterController cc;
    public float speed = 5;
    public float rotation_speed = 90;
    private float rotationHor;
    private float rotationVer;
    private float sensivilityHor = 3;
    private float sensivilityVer = 3;
    private GameObject mycam;
    private AudioSource steps;
    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
        mycam = GameObject.Find("Camera");
        steps = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //input
        float forward = Input.GetAxis("Vertical");
        float right = Input.GetAxis("Horizontal");

        //step sound
        if(forward != 0 || right != 0)
        {
            if (!steps.isPlaying)
            {
                steps.Play();
            }
        } else
        {
            if (steps.isPlaying)
            {
                steps.Pause();
            }
            
        }

        //Sanity
        sanity += (lights - 2)* 0.05f;

        if(sanity < 0)
        {
            sanity = 0;
        }else if(sanity > 100)
        {
            sanity = 100;
        }

        //Move
        cc.SimpleMove(transform.forward * forward * speed);
        cc.SimpleMove(transform.right * right * speed);

        rotationHor = sensivilityHor * Input.GetAxis("Mouse X");
        rotationVer = sensivilityVer * Input.GetAxis("Mouse Y");
        transform.Rotate(0, rotationHor, 0);
        mycam.transform.Rotate(-rotationVer, 0 , 0);
        //Debug.Log(sanity);
    }
}
