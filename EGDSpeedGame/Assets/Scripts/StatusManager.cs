using UnityEngine;
using System.Collections.Generic;

public class StatusManager : MonoBehaviour {

	public List<HealthNode> Nodes;
	public int HealthyNodeCount;

	public int Score;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update()
	{
		if (GetLastHealthyNode() == null)
		{
			//TODO end game
		}

		int nodeCount = 0;
		foreach (HealthNode node in Nodes)
		{
			if (node.IsDead)
				break;
			else
				nodeCount++;
		}

		HealthyNodeCount = nodeCount;
	}

	private HealthNode GetLastHealthyNode()
	{
		foreach (HealthNode node in Nodes)
		{
			if (!node.IsDead)
				return node;
		}

		return null;
	}

	public void Damage()
	{
		var node = GetLastHealthyNode();
		if (node)
			node.Damage();
	}

	public void FixCharacter()
	{
		Score += 1;
	}

	public void CompleteMinigame()
	{
		Score += 10;
	}
}
