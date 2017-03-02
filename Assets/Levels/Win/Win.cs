using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {
	
	public GUISkin skin;
	public Texture draculex;
	
	void OnGUI() {
		string mytext = "By Khalid Aziz, Charlie Geter and Rebecca Hartley";
		GUI.skin = skin;
		
		
		GUILayout.BeginArea(new Rect (Screen.width/2-250, Screen.height/2 - 300, 500, 500));
		
			GUILayout.Box(draculex);
		
			GUILayout.Label (mytext, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));	
			//myLabel(mytext);
		
			if (GUILayout.Button ("MainMenu", GUILayout.ExpandWidth(true))) {
				Application.LoadLevel("mainMenu");	
			}
		
		
		GUILayout.EndVertical();
	}
	
	void myLabel(string s) {
		GUILayout.Label (s, GUILayout.ExpandWidth(true), GUILayout.ExpandHeight(false));	
	}
}
