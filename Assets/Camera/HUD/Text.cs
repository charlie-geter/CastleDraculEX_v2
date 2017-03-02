using UnityEngine;
using System.Collections;

public class Text : MonoBehaviour {
	
	public string displaytext = " ";
	Rect myBackground = new Rect (25, 500, 100, 30);
	public GUISkin style;
	//GUIStyle style = new GUIStyle();
	//todo: button for continue
	//public  cont_button = new
	
	void Start () { 
		/*style.wordWrap = true;
		style.normal.textColor = Color.white;
		style.fontSize = 20;
		style.font = Font.*/
	}
	
	void Update() {
		//myBackground.width = displaytext.Length * 10;
	}
	
	void OnGUI() {
		GUI.skin = style;
		GUILayout.BeginVertical();
			GUILayout.Space(550);
			GUILayout.Label(displaytext, GUILayout.ExpandWidth(true));
		GUILayout.EndVertical();
		
	}
}
