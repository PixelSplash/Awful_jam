using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    
    [Range(0, 2)]
    public float lightIntensity = 0f;
    public GameObject lightObj;

    private Light light;

    // Use this for initialization
    void Start () {
        light = lightObj.GetComponent<Light>();
        InvokeRepeating("updateIntensity", 0.25f, 1.0f);

    }
	
	// Update is called once per frame
	void Update () {
        light.intensity = lightIntensity;
	}

    public void updateIntensity()
    {
        if (lightIntensity >= 2) lightIntensity = 2;
        else if (lightIntensity <= 0) lightIntensity = 0;
        lightIntensity -= 0.05f;
    }
}
