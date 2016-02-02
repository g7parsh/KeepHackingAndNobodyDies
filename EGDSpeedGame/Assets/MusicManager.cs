using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
    public AudioClip clip;
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
        source.pitch = script.speed;
	}
}
