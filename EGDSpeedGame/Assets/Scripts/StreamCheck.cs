using UnityEngine;
using System.Text.RegularExpressions;

public class StreamCheck : MonoBehaviour {
   // public string testString;
	public hackInterceptScript stream;
	public terminalScript outputTerminal;
	
	public void changeColor(string finalstr, string colorhex) {
		string qstr = "";
		string newstr = "";
		for (int i = 0; i < finalstr.Length; i++) {
			qstr += "<color=#ffff00>" + finalstr[i] + "</color>";
			newstr += "<color=#" + colorhex + ">" + finalstr[i] + "</color>";
		}
		var regex = new Regex(qstr);
		stream.textString = regex.Replace(stream.textString, newstr, 1);
	}

	public void CheckString(string input) {
		if (!(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))) return;

		string finalString = "";

		while (stream.checkQueue.Count != 0 && !stream.checkQueue.First.Value.anomaly) {//loop until first anomaly
			stream.checkQueue.RemoveFirst();
		}

		//loop until no more consecutive anomalies
		while (stream.checkQueue.Count != 0 && stream.checkQueue.First.Value.anomaly){
			finalString += stream.checkQueue.First.Value.text;//append string to final string
			stream.checkQueue.RemoveFirst();
		}
		if (!finalString.Equals("")) {
			if (input == finalString) {
				outputTerminal.writeMessage("CODE ANOMALY INTERCEPTED");
				GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addScore();
				changeColor(finalString, "00ff00");
			}
			else {
				outputTerminal.writeMessage("<color=red>HACK HAS PENETRATED SYSTEM</color>");
				GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthControl>().loseHealth();
				changeColor(finalString, "ff0000");
			}
		}	
		
	}
}
