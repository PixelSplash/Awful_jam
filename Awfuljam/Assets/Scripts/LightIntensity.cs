using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour {

    public const int MAX_LIGHT_INTENSITY = 3;
    public const int MID_LIGHT_INTENSITY = 1;
    public const int MIN_LIGHT_INTENSITY = 0;

    public const int MAX_LIGHT_RANGE = 3;
    public const int MID_LIGHT_RANGE = 1;
    public const int MIN_LIGHT_RANGE = 0;


    [Range(0, MAX_LIGHT_INTENSITY)]
    public float lightIntensity = MAX_LIGHT_INTENSITY;
    public int seconds;
    public GameObject lightObj;

    private Light light;

    // Use this for initialization
    void Start () {
        light = lightObj.GetComponent<Light>();
        InvokeRepeating("updateIntensity", 1.0f, 0.05f);
        InvokeRepeating("timer", 1.0f, 1.0f);

    }
	
	// Update is called once per frame
	void Update () {
        light.intensity = lightIntensity;
	}

    public void updateIntensity()
    {
        lightIntensity -= 0.005f;
        if (lightIntensity >= MAX_LIGHT_INTENSITY) lightIntensity = MAX_LIGHT_INTENSITY;
        else if (lightIntensity <= MIN_LIGHT_INTENSITY) lightIntensity = MIN_LIGHT_INTENSITY;
    }

    public void setMaxIntensity()
    {
        lightIntensity = MAX_LIGHT_INTENSITY;
    }
    
    public void timer()
    {
        seconds++;
    }
}
