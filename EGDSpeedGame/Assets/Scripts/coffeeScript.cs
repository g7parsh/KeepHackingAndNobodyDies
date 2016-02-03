using UnityEngine;
using UnityEngine.UI;

public class coffeeScript : MonoBehaviour {

	public float duration = 10f;
	private bool drank = false;

	private float drinktime;

	private bool done = false;

	private float originaltimescale;

	public Image cupimg;
	public Sprite emptyimg;

	public Text caffeinelevel;


	public void drink() {
		if (!drank) {
			
			drank = true;
			drinktime = Time.time;
			originaltimescale = GameManager.timescale;
			GameManager.timescale += 1;
			cupimg.sprite = emptyimg;
		}
	}

	void Update() {
		if (!done && drank) {
			float percent = Mathf.Max(((drinktime + duration - Time.time) / duration), 0);
			caffeinelevel.text = percent + "%";
			
			if (Time.time - drinktime > duration) {
				GameManager.timescale = originaltimescale;
				done = true;
			}
		}
	}
}
