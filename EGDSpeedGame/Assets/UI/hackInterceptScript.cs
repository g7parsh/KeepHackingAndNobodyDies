using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;


public class anomalyData{
	public readonly string text;
	public readonly bool anomaly;
	public int counter;

	public anomalyData(string text, bool anomaly, int counter) {
		this.text = text;
		this.anomaly = anomaly;
		this.counter = counter;
	}

}

public class hackInterceptScript : MonoBehaviour { 

	public int textwidth = 31;
	public LinkedList<anomalyData> checkQueue = new LinkedList<anomalyData>();
	public float speed = .25f;
	public float anomalychance = 0.1f;

	public terminalScript outputTerminal;


	public string textString = "";

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
		if(textString.Length > textwidth * 24) {//24 is size with tag

			//loop over each thing, if the counter is less than zero, take damage
			bool tookdamage = false;
			bool broke = false;
			string damagestr = "";
			var node = checkQueue.First;
			while (node != null) {
				node.Value.counter -= 24;
				var next = node.Next;
				if (!tookdamage) {//if not taken damage, do check
					if (node.Value.anomaly && node.Value.counter <= 0) {
						tookdamage = true;
						damagestr += node.Value.text;
						checkQueue.Remove(node);
					}
				}
				else {//if took damage, iterate until no more anomaly
					if (!node.Value.anomaly) {
						broke = true;
					}
					else {
						if (!broke) {
							damagestr += node.Value.text;
							checkQueue.Remove(node);
						}
					}
				}
				node = next;
			}


			if (tookdamage) {
				string qstr = "";
				string newstr = "";
				for (int i = 0; i < damagestr.Length; i++) {
					qstr += "<color=#ffff00>" + damagestr[i] + "</color>";
					newstr += "<color=#ff0000>" + damagestr[i] + "</color>";
				}
				var regex = new Regex(qstr);
				textString = regex.Replace(textString, newstr, 1);
				GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthControl>().loseHealth();
				outputTerminal.writeMessage("<color=red>HACK HAS PENETRATED SYSTEM</color>");
			}

			textString = textString.Substring(24);

		}

		//add new data
		bool anomaly = false;
		string newdata = "";
		if (Random.value <= anomalychance) {
			anomaly = true;
		}
		int index = textString.Length;
		if(textString.Length < textwidth * 48) {
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
			checkQueue.AddLast(new anomalyData(checkString.ToString(), anomaly, index));
			
		}
		
		textString += newdata;

		txt.text = textString;
		
	}
}
