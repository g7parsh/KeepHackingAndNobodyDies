using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GenerateNodes : MonoBehaviour {
	public float min_dist = 1f; //minimum spacing for nodes
	private int totalnodes;
	private int rednodes;
	public int changenodes;
	public List<GameObject> nodes = new List<GameObject>();
	// Use this for initialization
	void Start () {
		//random choose between 4 or 5 nodes
		totalnodes = Random.Range(5, 7);
		//randomly choose how many are green and red
		rednodes = Random.Range(1, 4);
		changenodes = 0;
		//randomly place them within the set area

		float maxwidth = gameObject.GetComponent<RectTransform>().rect.width /2;
		float minwidth = -1 * (gameObject.GetComponent<RectTransform>().rect.width /2);
		Debug.Log(maxwidth + "sad");
		float maxheight = gameObject.GetComponent<RectTransform>().rect.height /2;
		float minheight = -1 * (gameObject.GetComponent<RectTransform>().rect.width /2);
		for(int i  =0; i < rednodes ; i ++ )
		{
			GameObject temp = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/wrongnode"));

			Vector3 tempos = new Vector3(Random.Range(minwidth, maxwidth), Random.Range(0f, maxheight), 10f);
			while(Spacing(tempos) == false)
			{
				tempos = new Vector3(Random.Range(minheight, maxwidth), Random.Range(0f, maxheight), 10f);
			}
			temp.transform.localPosition = tempos;
			temp.transform.SetParent(gameObject.transform, false);

			nodes.Add(temp);
		}
		//make the green nodes
		for(int i  =0; i < (totalnodes - rednodes) ; i ++ )
		{
			GameObject temp = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/workingnode"));
			Vector3 tempos = new Vector3(Random.Range(0f, maxwidth), Random.Range(0f, maxheight), 10f);
			while(Spacing(tempos) == false)
			{
				tempos = new Vector3(Random.Range(0f, maxwidth), Random.Range(0f, maxheight), 10f);
			}
			temp.transform.localPosition = tempos;
			temp.transform.SetParent(gameObject.transform, false);

			nodes.Add(temp);
		}
		//shuffle the order of the list of  nodes
		for(int i = 0; i < nodes.Count;  i++)
		{
			GameObject temp = nodes[i];
			int r = Random.Range(i, nodes.Count);
			nodes[i] = nodes[r];
			nodes[r] = temp;
		}

		//draw the lines between the nodes
		for (int i = 0 ; i < nodes.Count -1 ; i++)
		{
			LineRenderer line = nodes[i].GetComponent<LineRenderer>();
			//Vector3 oripos = new Vector3(((nodes[i].transform.localPosition.x -305 )), (nodes[i].transform.localPosition.y - 140),10f);
			Vector3 oripos = new Vector3((nodes[i].transform.position.x), (nodes[i].transform.position.y),0f);
			//Debug.Log("obj " + nodes[i].transform.localPosition  + " startnig line" + oripos);
			line.SetPosition(0, oripos);

			//Vector3 neworipos = new Vector3(((nodes[i +1].transform.localPosition.x -305 )), (nodes[i +1].transform.localPosition.y - 140),10f);
			Vector3 neworipos = new Vector3((nodes[i +1].transform.position.x ), (nodes[i +1].transform.position.y),1f);
			line.SetPosition(1, neworipos);
			line.SetWidth(.5f,.5f);
		}
		nodes[nodes.Count - 1].GetComponent<LineRenderer>().enabled = false;
	}
	bool Spacing(Vector3 pos)
	{
		//determine/ make sure all the nodes are away from each other
		foreach(GameObject g in nodes)
		{
			float dist = Vector3.Distance(g.transform.position, pos);
			if(dist < min_dist)
			{
				return false;
			}

		}
		return true;
	}
	// Update is called once per frame
	void Update () {
		//Debug.Log(gameObject.GetComponent<RectTransform>().rect.width);
		if(changenodes >= rednodes)
		{
			Destroy(transform.parent.gameObject);
		}
	}
}
