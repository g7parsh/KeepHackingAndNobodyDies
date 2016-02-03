using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public float speedchangeinterval = 10;//the amount of seconds between speedups
	public static float timescale = 1f;

	private StatusManager status;
	public int Level = 1;
	public int TotalLevels = 10;

	public float MinigameWaitMinimum = 30;
	public float MinigameWaitMaximum = 120;

	public List<GameObject> minigames; //list of minigame prefabs
	public RectTransform monitor;

	private int score = 0;
	public Text scorebox;

	private float lasttime = 0;

	public void addScore() {
		score++;
		scorebox.text = score.ToString();
	}



	// Use this for initialization
	void Start () {
		status = GetComponent<StatusManager>();

		StartCoroutine(MinigameCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Time.time - lasttime > speedchangeinterval) {
			lasttime = Time.time;
			if (timescale > 0) {
				timescale -= 0.05f;
				print("new timescale: " + timescale);
			}
		}
	}

	public void CompleteMinigame(bool won)
	{
		if (!won)
			status.Damage();
		else
			status.CompleteMinigame();
	}

	private IEnumerator MinigameCoroutine()
	{
		while (Level < TotalLevels)
		{
			yield return new WaitForSeconds((Random.value * (MinigameWaitMaximum - MinigameWaitMinimum)) + MinigameWaitMinimum);

			LaunchMinigame();
			
			//TODO wait for minigame to be completed.
		}
	}

	private void LaunchMinigame()
	{
		//TODO randomly select and display a minigame
		int rindex = Random.Range(0, minigames.Count);
		Vector3 newpos = monitor.position + (Vector3)(Random.insideUnitCircle * monitor.rect.height/4);
		GameObject newminigame =  Instantiate(minigames[rindex],newpos, Quaternion.identity) as GameObject;

		//have to manually set scale because it's scaling for no reason
		Vector3 prevscale = newminigame.transform.lossyScale;
		newminigame.transform.SetParent(monitor);
		newminigame.transform.localScale = prevscale;

	}
}
