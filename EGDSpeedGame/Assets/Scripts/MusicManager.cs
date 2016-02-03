using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip incomingHack;
    public AudioClip failSound;
    public AudioClip gameOver;
	public AudioSource source;
	public hackInterceptScript script;

	void Awake() {
		source.Play();
	}
	// Use this for initialization
	
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {
		source.pitch = Mathf.Clamp(1/script.speed,1,2);
	}
}
