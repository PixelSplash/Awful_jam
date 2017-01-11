using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanicController : MonoBehaviour {
    private AudioSource ambient;
    private AudioSource breath;
    private Controller player;
    private SimpleTimer timer;
    // Use this for initialization
    void Start () {
        timer = GetComponent<SimpleTimer>();
        AudioSource[] audios = GetComponents<AudioSource>();
        ambient = audios[0];
        breath = audios[1];
        player = (Controller)FindObjectOfType(typeof(Controller));
        timer.timerStart(1);
    }
	
	// Update is called once per frame
	void Update () {
        if (!timer.isCounting)
        {
            Breath();
        }
        ambient.volume = (100 - player.sanity) / 100;
	}
    void Breath()
    {
        breath.Play();
        float tmp = (player.sanity * 8 / 100);
        if(tmp < 1.8f)
        {
            tmp = 1.8f;
        }
        timer.timerStart(tmp);
    }
}
