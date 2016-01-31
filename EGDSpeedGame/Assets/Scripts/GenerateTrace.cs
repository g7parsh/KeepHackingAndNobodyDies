using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class GenerateTrace : MonoBehaviour
{
    public List<GameObject> tracingnumbers = new List<GameObject>();
    private int totaltraces = 2;
    private int currenttraces = 0;
    // Use this for initialization
    void Start()
    {
        //RectTransform panel = GetComponent<RectTransform>();
        int height = 0;
        int width = 2;
        int num = 2;
        for (int i = 0; i < num; i++)
        {
            GameObject temp = (GameObject)GameObject.Instantiate(Resources.Load("Prefabs/TraceGo"));
            //temp.transform.parent = gameObject.transform;
            Button b = temp.GetComponentInChildren<Button>();
            float posy = b.transform.position.y + height;
            Debug.Log(posy);
            b.GetComponent<RectTransform>().localPosition = new Vector3(width, posy, -1);
            b.onClick.AddListener(() => Increase(b));
            //b.transform.localPosition = 
            //b.transform.position = new Vector3(width, posy ,-1);
            //temp.transform.position = ;
            height += 30;

			Text[] tex = temp.GetComponentsInChildren<Text>();
			foreach(Text t in tex)
			{
				if(t.name == "IPAddr")
				{
					t.GetComponent<RectTransform>().localPosition = new Vector3(width - 70 , posy , -1);
				}
			}
            tracingnumbers.Add(temp);

        }
        //tracingnumbers.Add(temp);

    }
    void Increase(Button b)
    {
        b.interactable = false;
        currenttraces += 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (currenttraces >= totaltraces)
        {
            foreach (GameObject obj in tracingnumbers)
            {
                Destroy(obj);
            }
            tracingnumbers.Clear();
            Destroy(gameObject);
        }
    }
}
