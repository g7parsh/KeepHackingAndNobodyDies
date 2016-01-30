using UnityEngine;
using UnityEngine.UI;

public class terminalScript : MonoBehaviour {

	public int numlines = 10;
	public Text txt;
	public InputField inputfield;

	private string[] inputs;
	private int count = 0;

	void Awake() {
		inputs = new string[numlines];
		txt.text = "";
	}

	public void addLine(string line) {
		string tmp = "";
		

		if (count < numlines) {//add to bottom
			inputs[count] = line;
			count++;
		}
		else {//shift everything then add to bottom
			
			for (int i = 0; i < numlines-1; i++) {
				inputs[i] = inputs[i + 1];
			}
			inputs[numlines - 1] = line;


		}

		for (int i = 0; i < numlines; i++) {
			tmp += inputs[i] + "\n";
		}
		


		txt.text = tmp;

		inputfield.text = "";
		//reactivate input to type again
		inputfield.ActivateInputField();
	}
}
