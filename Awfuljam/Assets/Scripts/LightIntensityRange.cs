using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityRange : MonoBehaviour {

    public const float TIME = 120;
    public const float TIME_RATE = 0.05f;
    public const float MAX_LIGHT_INTENSITY = 15;
    public const float MIN_LIGHT_INTENSITY = 0;

    public const float MAX_LIGHT_RANGE = 20;
    public const float MIN_LIGHT_RANGE = 1.5f;

    public const float DISCOUNT_INTENSITY = MAX_LIGHT_INTENSITY / (TIME / TIME_RATE);
    public const float DISCONUT_RANGE = (((MAX_LIGHT_RANGE - MIN_LIGHT_RANGE) * DISCOUNT_INTENSITY) / MAX_LIGHT_INTENSITY);

    [Range(MIN_LIGHT_INTENSITY, MAX_LIGHT_INTENSITY)]
    public float lightIntensity = MAX_LIGHT_INTENSITY;
    [Range(MIN_LIGHT_RANGE, MAX_LIGHT_RANGE)]
    public float lightRange = MAX_LIGHT_RANGE;
    public int seconds;
    public GameObject lightObj;
    public Transform candle;

    private Light light;

    // Use this for initialization
    void Start () {
        light = lightObj.GetComponent<Light>();
        InvokeRepeating("updateIntensity_Range", 1.0f, TIME_RATE);
        InvokeRepeating("timer", 1.0f, 1.0f);
        //InvokeRepeating("UpdateCandle", 1.0f, 1.0f);
        candle = transform.Find("body");
        lightIntensity = MAX_LIGHT_INTENSITY;

    }
	
	// Update is called once per frame
	void Update () {
        light.intensity = lightIntensity;
        UpdateCandle();
    }

    public void updateIntensity_Range()
    {
        lightIntensity -= DISCOUNT_INTENSITY;
        if (lightIntensity >= MAX_LIGHT_INTENSITY) lightIntensity = MAX_LIGHT_INTENSITY;
        else if (lightIntensity <= MIN_LIGHT_INTENSITY) lightIntensity = MIN_LIGHT_INTENSITY;

        lightRange -= DISCONUT_RANGE;
        if (lightRange >= MAX_LIGHT_RANGE) lightRange = MAX_LIGHT_RANGE;
        else if (lightRange <= MIN_LIGHT_RANGE) lightRange = MIN_LIGHT_RANGE;
    }

    public void setMaxIntensity_Range()
    {
        lightIntensity = MAX_LIGHT_INTENSITY;
        lightRange = MAX_LIGHT_RANGE;
    }
    
    public void timer()
    {
        seconds++;
    }

    public void UpdateCandle()
    {
        candle.localScale = new Vector3(candle.localScale.x, candle.localScale.y, (lightIntensity / MAX_LIGHT_INTENSITY) * 100);
    }
}
