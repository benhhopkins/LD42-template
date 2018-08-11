using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager I = null;

	public AudioSource sfxSource;
	public AudioSource musicSource;

	void Awake() {
		// singleton
		if (I == null)
			I = this;
		else if (I != this)
			Destroy (gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlaySingle(AudioClip clip)
	{
		sfxSource.clip = clip;
		sfxSource.Play ();
	}

	//RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
	public void RandomizeSfx (params AudioClip[] clips)
	{
		//Generate a random number between 0 and the length of our array of clips passed in.
		int randomIndex = Random.Range(0, clips.Length);
		
		//Choose a random pitch to play back our clip at between our high and low pitch ranges.
		//float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		
		//Set the pitch of the audio source to the randomly chosen pitch.
		//sfxSource.pitch = randomPitch;
		
		//Set the clip to the clip at our randomly chosen index.
		sfxSource.clip = clips[randomIndex];
		
		//Play the clip.
		sfxSource.Play();
	}
}
