using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Node : MonoBehaviour {
	public Sprite highlight;
	public Sprite nonhighlight;
	public Sprite Correct;
	private bool clicked = false;

	public void OnClick()
	{
		//change the color
		Image col = gameObject.GetComponent<Image>();
		if(col.color != Color.green)
		{
			col.color = Color.green;
			//Image change = gameObject.transform.GetComponent<Image>();
			col.sprite = Correct;

			GenerateNodes par = gameObject.transform.GetComponentInParent<GenerateNodes>();
			par.changenodes +=1;
			clicked = true;

			//OnExit();
		}
	}
	public void OnEnter()
	{
		if(clicked == false)
		{
			Image change = gameObject.transform.GetComponent<Image>();
			change.sprite = highlight;
		}
	}
	public void OnExit()
	{
		if(clicked == false)
		{
			Image change = gameObject.transform.GetComponent<Image>();
			change.sprite = nonhighlight;
		}
	}
}
