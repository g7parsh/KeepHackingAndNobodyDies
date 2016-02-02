using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class hackInterceptScript : MonoBehaviour {
 

	public int textwidth = 31;
	public Queue<KeyValuePair<string, bool>> checkQueue = new Queue<KeyValuePair<string, bool>>();
	public float speed = .25f;
	public float anomalychance = 0.1f;


	public string textstring = "";

	private Text txt;

	void Awake() {
		txt = GetComponent<Text>();
	}

	void Start() {
		InvokeRepeating("updateStream", 0, speed);
	}
	
	// Update is called once per frame
	void updateStream () {
		//if longer than textwidth
		//cut off first char and tags
		if(textstring.Length > textwidth * 24) {//24 is size with tag
			textstring = textstring.Substring(24);
		}

		//add new data
		bool anomaly = false;
		string newdata = "";
		if (Random.value <= anomalychance) {
			anomaly = true;
		}

		if(textstring.Length < textwidth * 48) {
			string checkString = "";
			for (int i = 0; i < Random.Range(1, 8); i++) {
				if (anomaly) {
					newdata += "<color=#ffff00>";
				}
				else {
					newdata += "<color=#00ff00>";
				}
				if (Random.value < .5f) {
					checkString += "0";
					newdata += "0";
				}
				else {
					checkString += "1"; 
					newdata += "1";
				}
				newdata += "</color>";
			}
			checkQueue.Enqueue(new KeyValuePair<string, bool>(checkString.ToString(), anomaly));
			
		}
		
		textstring += newdata;

		txt.text = textstring;
		
	}
}
