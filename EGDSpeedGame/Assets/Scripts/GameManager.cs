using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	private StatusManager status;
	public int Level = 1;
	public int TotalLevels = 10;

	public float MinigameWaitMinimum = 30;
	public float MinigameWaitMaximum = 120;

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
	}
}
