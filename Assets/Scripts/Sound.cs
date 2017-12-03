using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour {

    public BoolValue sound;
    public AudioSource audioSource;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!sound.Value && audioSource.isPlaying)
            audioSource.Stop();
        if (sound.Value && !audioSource.isPlaying)
            audioSource.Play();
	}
}
