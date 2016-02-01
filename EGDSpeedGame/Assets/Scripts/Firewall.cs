using UnityEngine;
using System.Collections;

public class Firewall : MonoBehaviour {
	public bool dragging = false;
	private Vector3 startingpos;
	private RectTransform rt;
	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform>();
		startingpos = rt.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		//wobble while its not beeing dragged upwards
		if(dragging == false)
		{
			rt.localPosition = new Vector3(rt.localPosition.x, startingpos.y + Mathf.PingPong(Time.time *60, 20), rt.localPosition.z);
		}
		else
		{
			//player clicked on the object and is dragging upwards
		}
	}
	public void OnDrag()
	{
		dragging = true;
		if (rt.localPosition.y < 140) {
			Vector3 tmp = rt.position;
			tmp.y = Input.mousePosition.y;
			rt.position = tmp;
		}
		
	}
	public void OnDrop()
	{
		//brought it high enough you win destroy gameobject
		if(rt.localPosition.y > 140)
		{
			Debug.Log("hit top limit");
			//destroy the game object the minigame has been won
			Destroy(transform.parent.parent.gameObject);
		}


		rt.localPosition = startingpos;
		dragging = false;
	}
}
