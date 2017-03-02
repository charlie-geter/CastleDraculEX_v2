using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {

	public float barDisplay; //current progress
    public Vector2 pos = new Vector2(5,5);
    public Vector2 size = new Vector2(1,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;
    public Texture2D healthPackTex;
	public bool hasHealthPack = false;
	
	void Start() {
		
		emptyTex.wrapMode = TextureWrapMode.Repeat;
		fullTex.wrapMode = TextureWrapMode.Repeat;
		
	}
 
    void OnGUI() {
		Component playerHealthScript = GameObject.FindWithTag("Player").GetComponent("Player");
		Player pc = (Player) playerHealthScript;
		
		GUI.DrawTexture(new Rect(5,5,30,30), healthPackTex, ScaleMode.ScaleToFit, false, 0.0F);
		GUI.Label(new Rect(10, 35, 20, 20), "x "+ pc.healthPackCount.ToString());
		GUI.DrawTexture(new Rect(pos.x, pos.y, pos.x+size.x, pos.y+size.y), emptyTex, ScaleMode.StretchToFill, false, 10.0F);
		GUI.DrawTexture(new Rect(pos.x, pos.y, pos.x+barDisplay, pos.y+size.y), fullTex, ScaleMode.StretchToFill, false, 10.0F);

    }
 
    void Update() {
       //for this example, the bar display is linked to the current time,
       //however you would set this value based on your desired display
       //eg, the loading progress, the player's health, or whatever.
       //barDisplay = 100;
   		
		//Component playerHealthScript = GameObject.FindWithTag("Player").GetComponent("PlayerControl");
		//PlayerControl pc = (PlayerControl) playerHealthScript;
		
		Component playerHealthScript = GameObject.FindWithTag("Player").GetComponent("Player");
		Player pc = (Player) playerHealthScript;
		barDisplay = pc.Health * 3;
    }
}
