using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class terminalScript : MonoBehaviour {

	public int lineheight = 10;
	public int linewidth = 50;

	public Text txt;
	public InputField inputfield;
	public string prefix = "root:~$";

	private LinkedList<string> lines;
	private int count = 0;

	void Awake() {
		lines = new LinkedList<string>();
		txt.text = "";
	}

	public void addLine(string input) {
		//add a line of command and get the response
		string tmp = "";
		


		string fulltext = prefix + " " + input + "\n" + get_response(input);
		string[] textlines = fulltext.Split(new string[] { "\r\n", "\n" }, System.StringSplitOptions.None);
		foreach (string textline in textlines) {
			//break into multiple lines if necessary
			for (int i = 0; i < Mathf.CeilToInt((float)textline.Length / linewidth); i++) {
				try {
					lines.AddLast(textline.Substring(i * linewidth, linewidth));
				}
				catch {
					lines.AddLast(textline.Substring(i * linewidth));
				}
				count++;
			}
		}

		if (count >= lineheight) {//shift everything then add to bottom
			while(lines.Count > lineheight) {
				lines.RemoveFirst();
			}
		}

		foreach (string s in lines) {
			tmp += s + "\n";
		}
		


		txt.text = tmp;

		inputfield.text = "";
		//reactivate input to type again
		inputfield.ActivateInputField();
	}

	private string get_response(string line) {
		if (line.Equals("ayy")) return "lmao";
		else return "";
	}
}
