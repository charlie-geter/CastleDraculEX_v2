using UnityEngine;
using System.Collections;

public class Tutorial : MonoBehaviour {
	
	public Transform myHUD;
	//public Transform trigger1;
	//public Transform trigger2;

	Text t;
	string[] lines = new string[2];
	public int li = 0;

	// Use this for initialization
	void Start () {
		t = (Text) myHUD.GetComponent("Text");
		//lines = {};
		lines[0] = "Woah...where am I?";
		lines[1] = "How did I get here?";
		setText();
	}
	
	// Update is called once per frame
	void Update () {
		/*if(Input.GetKeyDown(KeyCode.Space)){
			if(li < lines.Length){
				setText();
				li++;
			}
			else {
				t.displaytext = "";
			}
		}*/
		
	}
	
	void setText() {
		t.displaytext = lines[li];
		//if (li <= lines.Length) {
		//	t.displaytext += " (Press space to continue)";
		//}
	}
	
}
