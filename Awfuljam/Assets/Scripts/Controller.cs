using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {
    public float light_ration = 0.05f;
    public float sanity = 100f;
    public int lights = 0;
    CharacterController cc;
    public float speed = 5;
    public float rotation_speed = 90;
    private float rotationHor;
    private float rotationVer;
    private float sensivilityHor = 3;
    private float sensivilityVer = 3;
    private GameObject mycam;
    private AudioSource steps;
    private LightIntensityRange lightIntController;
    private float lightValue;
    // Use this for initialization
    void Start () {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
        cc = GetComponent<CharacterController>();
        mycam = GameObject.Find("Camera");
        steps = GetComponent<AudioSource>();
        lightIntController = (LightIntensityRange)FindObjectOfType(typeof(LightIntensityRange));
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
        lightValue = lights + (lightIntController.lightIntensity / LightIntensityRange.MAX_LIGHT_INTENSITY);
        //Debug.Log(lightValue);
        if (lightValue < 0.26f)
        {
            sanity -= 2 * light_ration;
        }
        else if (lightValue < 1.01f)
        {
            sanity -= 1 * light_ration;
        }
        else if (lightValue < 1.26f)
        {
            //sanity += (lights - 2) * light_ration;
        }
        else if (lightValue < 1.76f)
        {
            sanity += 1 * light_ration;
        }
        else
        {
            sanity += 2 * light_ration;
        }
        

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
        Debug.Log(sanity);
    }
}
