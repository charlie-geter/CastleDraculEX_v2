using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	
	
	public GUISkin skin;
	public Texture draculex;
	string mylevel = "Enter level passcode";
	
	void OnGUI() {
		GUI.skin = skin;
		
		
		GUILayout.BeginArea(new Rect (Screen.width/2-200, Screen.height/2 - 200, 400, 400));
		
		GUILayout.Box(draculex);
		
		if (GUILayout.Button ("Start", GUILayout.ExpandWidth(true))) {
			Application.LoadLevel("start");	
		}
		
			//myLabel("Skip to a level");
			mylevel = GUILayout.TextArea(mylevel);//, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));
		
		if (GUILayout.Button("Go")) { //, GUILayout.ExpandWidth(true))) {
			if (mylevel == "pencil") {
				loadLevel("level3");
			}
			else if (mylevel == "firecracker") {
				loadLevel("level2");
			}
			else if (mylevel == "cheese") {
				loadLevel("main");	
			}
			else if (mylevel == "lightbulb") {
				loadLevel("end");	
			}
			else if (mylevel == "ghosts") {
				loadLevel("start");	
			}
			else {
				mylevel = "Not a valid password!";
			}
		}
		

		
		GUILayout.EndVertical();
	}
	
	void loadLevel(string s) {
		Application.LoadLevel(s);		
	}
	
	void myLabel(string s) {
		GUILayout.Label (s, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));	
	}
}
