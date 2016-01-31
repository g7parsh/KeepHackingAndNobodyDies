using UnityEngine;
using System.Collections;

public class Firewall : MonoBehaviour {
	public bool dragging = false;
	private Vector3 startingpos;
	// Use this for initialization
	void Start () {
		startingpos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//wobble while its not beeing dragged upwards
		if(dragging == false)
		{
			gameObject.transform.position = new Vector3(transform.position.x, Mathf.PingPong(Time.time *60, 20), transform.position.z);
		}
		else
		{
			//player clicked on the object and is dragging upwards
		}
	}
	public void OnDrag()
	{
		dragging = true;
		transform.position = Input.mousePosition;
	}
	public void OnDrop()
	{
		//brought it high enough you win destroy gameobject
		if(transform.position.y > startingpos.y + 230)
		{
			Debug.Log("hit top limit");
			//destroy the game object the minigame has been won
			Destroy(transform.parent.gameObject);
		}


		transform.position = startingpos;
		dragging = false;
	}
}
