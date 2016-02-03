using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour {

	public RectTransform healthobject;

	private Image[] healthnodes;

	private int health = 100;
	private float maxHealth = 100;

	// Use this for initialization
	void Start () {
		
		healthnodes = healthobject.GetComponentsInChildren<Image>();
		health = healthnodes.Length;
		maxHealth = healthnodes.Length;
	}
	
	public void loseHealth() {
		if(health > 0) { 
			health--;
			int loopsize = (int)((1-(health / maxHealth)) * healthnodes.Length);
			//loop through 
			for(int i=0; i < loopsize; i++) {
				healthnodes[i].color = Color.red;
			}

		}
		else {
			//LOSE
		}

	}
}
