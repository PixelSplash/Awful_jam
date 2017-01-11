using UnityEngine;
using System.Collections;

public class SimpleTimer : MonoBehaviour
{

    public float targetTime = 60.0f;
    private float timeRemaining;
    public bool isCounting;

    void Start()
    {
        isCounting = false;
    
    }
    void Update()
    {

        if (isCounting)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0.0f)
            {
                isCounting = false;
            }
        }
      

    }

    public void timerStart( float time)
    {
        targetTime = time;
        isCounting = true;
        timeRemaining = targetTime;
    }


}