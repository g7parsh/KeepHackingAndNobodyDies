using UnityEngine;

public class Firewall : MonoBehaviour {
	public bool dragging = false;
	private Vector3 startingpos;
	private RectTransform rt;

	public GameObject failbox;

	public float failtime = 3f; //the time in seconds before failure
	private float starttime;
	private bool failed = false;

	// Use this for initialization
	void Start () {
		starttime = Time.time;
		rt = GetComponent<RectTransform>();
		startingpos = rt.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (!failed) {
			if (Time.time - starttime > failtime * GameManager.timescale) {
				failbox.SetActive(true);
				failed = true;
				GameObject.FindGameObjectWithTag("GameManager").GetComponent<HealthControl>().loseHealth();

			}

			//wobble while its not beeing dragged upwards
			if (dragging == false) {
				rt.localPosition = new Vector3(rt.localPosition.x, startingpos.y + Mathf.PingPong(Time.time * 60, 20), rt.localPosition.z);
			}
			else {
				//player clicked on the object and is dragging upwards
			}

		}



		
	}
	public void OnDrag()
	{
		dragging = true;
		if (rt.localPosition.y < 140) {
			Vector3 tmp = rt.position;
			tmp.y = Input.mousePosition.y;
			rt.position = tmp;

			//clamp thing
			tmp = rt.localPosition;
			tmp.y = Mathf.Min(tmp.y, 140);
			rt.localPosition = tmp;
		}
		
	}
	public void OnDrop()
	{
		//brought it high enough you win destroy gameobject
		if(rt.localPosition.y >= 140)
		{
			//destroy the game object the minigame has been won
			Destroy(transform.parent.parent.gameObject);
			GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().addScore();
		}


		rt.localPosition = startingpos;
		dragging = false;
	}
}
