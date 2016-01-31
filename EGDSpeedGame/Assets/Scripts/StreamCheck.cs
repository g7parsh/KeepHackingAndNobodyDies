using UnityEngine;
using System.Collections;

public class StreamCheck : MonoBehaviour {
    public string testString;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void CheckString(string input) {
        print(input);
        if (input == testString){
            Debug.Log("Test");
        }
    }
}
