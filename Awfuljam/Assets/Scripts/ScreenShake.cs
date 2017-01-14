using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    public float shakeRatio = 0.01f;
    private SimpleTimer timer;
    private float initialy;
    private float initialz;
    private Controller player;
    // Use this for initialization
    void Start () {
        timer = GetComponent<SimpleTimer>();
        initialy = transform.position.y;
        initialz = transform.position.z;
        timer.timerStart(0.01f);
        player = (Controller)FindObjectOfType(typeof(Controller));
    }
	
	// Update is called once per frame
	void Update () {
        if (!timer.isCounting)
        {
            Shake();
        }
    }
    private void Shake()
    {
        if(player.sanity < 50)
        {
            if (player.sanity > 33)
            {
                shakeRatio = 0.005f;
            }
            else if (player.sanity > 18)
            {
                shakeRatio = 0.01f;
            }
            else
            {
                shakeRatio = 0.02f;
            }
            transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(-shakeRatio, shakeRatio), transform.position.z + Random.Range(-shakeRatio, shakeRatio));
            timer.timerStart(0.01f);
        }
        
    }
}
