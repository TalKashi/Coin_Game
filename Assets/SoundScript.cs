using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	public AudioSource ClickFX;
	public AudioClip audio;
	

	
	void playSound(){
		ClickFX.Play();
	}
	public void playAudioClip(){
		AudioSource.PlayClipAtPoint (audio, transform.position);
	}
}
