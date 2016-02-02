using UnityEngine;

public class StreamCheck : MonoBehaviour {
   // public string testString;
	public hackInterceptScript stream;
	
	public void changeColor(string finalstr, string colorhex) {
		string qstr = "";
		string newstr = "";
		for (int i = 0; i < finalstr.Length; i++) {
			qstr += "<color=#ffff00>" + finalstr[i] + "</color>";
			newstr += "<color=#" + colorhex + ">" + finalstr[i] + "</color>";
		}

		stream.textstring = stream.textstring.Replace(qstr, newstr);
	}

	public void CheckString(string input) {
		string finalString = "";

		while (stream.checkQueue.Count != 0 && !stream.checkQueue.Peek().Value) {//loop until first anomaly
			stream.checkQueue.Dequeue();
		}

		//loop until no more consecutive anomalies
		while (stream.checkQueue.Count != 0 && stream.checkQueue.Peek().Value){
			finalString += stream.checkQueue.Dequeue().Key;//append string to final string
		}
		if (!finalString.Equals("")) {
			if (input == finalString) {

				print("Yay, you did it :^)");
				changeColor(finalString, "00ff00");
			}
			else {

				print("you dun goofed");
				changeColor(finalString, "ff0000");
			}
		}	
		
	}
}
