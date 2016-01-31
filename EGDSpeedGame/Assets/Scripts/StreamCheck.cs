using UnityEngine;
using System.Collections;

public class StreamCheck : MonoBehaviour {
   // public string testString;
    public hackInterceptScript stream;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    
	
	}
    public void changeColor() {
    
        

    }
    public void CheckString(string input) {
        string finalString = "";
        if (!(stream.checkQueue.Count == 0))
        {

            while (!stream.checkQueue.Peek().Value)
            {
                stream.checkQueue.Dequeue();
            }

            while (stream.checkQueue.Peek().Value)
            {
                finalString += stream.checkQueue.Dequeue().Key;
            }
            if (input == finalString)
            {

                print("Yay, you did it :^)");
            }
            else
            {

                print("you dun goofed");
            }
        }
        
    }
}
