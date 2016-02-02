using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private StatusManager status;
	public int Level = 1;
	public int TotalLevels = 10;

	public float MinigameWaitMinimum = 30;
	public float MinigameWaitMaximum = 120;

	public List<GameObject> minigames; //list of minigame prefabs
	public RectTransform monitor;

	// Use this for initialization
	void Start () {
		status = GetComponent<StatusManager>();

		StartCoroutine(MinigameCoroutine());
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Level >= TotalLevels)
		{
			//TODO end game
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
