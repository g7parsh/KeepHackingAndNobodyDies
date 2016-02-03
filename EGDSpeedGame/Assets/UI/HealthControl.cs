using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour {
	public MusicManager Manager;
	public RectTransform healthobject;

	private Image[] healthnodes;

	private int health = 100;
	private float maxHealth = 100;

	public Text healthynodes;
	public Text corruptnodes;

	// Use this for initialization
	void Start () {
		
		healthnodes = healthobject.GetComponentsInChildren<Image>();
		health = healthnodes.Length;
		maxHealth = healthnodes.Length;
		healthynodes.text = "Healthy nodes: " + maxHealth;
		corruptnodes.text = "Corrupt nodes: " + 0;
	}
	
	public void loseHealth() {
		if(health > 0) { 
			health--;
			int loopsize = (int)((1-(health / maxHealth)) * healthnodes.Length);
			healthynodes.text = "Healthy nodes: " + (maxHealth - loopsize);
			corruptnodes.text = "Corrupt nodes: " + loopsize;
			//loop through 
			for (int i=0; i < loopsize; i++) {
				healthnodes[i].color = Color.red;
				Manager.source.PlayOneShot(Manager.failSound);
			}

		}
		else {
			//LOSE
		}

	}
}
