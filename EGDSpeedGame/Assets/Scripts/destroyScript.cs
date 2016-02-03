using UnityEngine;

public class destroyScript : MonoBehaviour {

	public void Kill() {
		Destroy(gameObject);
		GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthControl>().loseHealth();
	}
}
