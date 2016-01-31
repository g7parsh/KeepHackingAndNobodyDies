using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Node : MonoBehaviour {

	public void OnClick()
	{
		//change the color
		Image col = gameObject.GetComponent<Image>();
		if( col.color != Color.green)
		{
			col.color = Color.green;


			GenerateNodes par = gameObject.transform.GetComponentInParent<GenerateNodes>();
			par.changenodes +=1;
		}
	}
}
