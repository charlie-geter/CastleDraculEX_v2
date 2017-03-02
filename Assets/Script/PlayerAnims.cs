using UnityEngine;
using System.Collections;

// This script is part of the tutorial series "Making a 2D game with Unity3D using only free tools"
// http://www.rocket5studios.com/tutorials/make-a-2d-game-in-unity3d-using-only-free-tools-part-1

public class PlayerAnims : MonoBehaviour {

	OTAnimatingSprite mySprite;
	xa.anim currentAnim;
	
	// Use this for initialization
	void Start () 
	{
		mySprite = GetComponent<OTAnimatingSprite>();
	}
	
	void Update() 
	{
        /*
        // Diagonals
        if ((xa.isUp || xa.isDown) && xa.isRight && currentAnim != xa.anim.WalkRight)
        {
            currentAnim = xa.anim.WalkRight;
            mySprite.Play("runRight");
        }
        else if ((xa.isUp || xa.isDown) && xa.isLeft && currentAnim != xa.anim.WalkLeft)
        {
            currentAnim = xa.anim.WalkLeft;
            mySprite.Play("runLeft");
        }*/
        // run left
            if (xa.isLeft && currentAnim != xa.anim.WalkLeft)
            {
                currentAnim = xa.anim.WalkLeft;
                mySprite.Play("runLeft");
            }
            if (!xa.isLeft && currentAnim != xa.anim.StandLeft && xa.facingDir == 1)
            {
                currentAnim = xa.anim.StandLeft;
                mySprite.ShowFrame(12); // stand left
            }

            // run right
            if (xa.isRight && currentAnim != xa.anim.WalkRight)
            {
                currentAnim = xa.anim.WalkRight;
                mySprite.Play("runRight");
            }
            if (!xa.isRight && currentAnim != xa.anim.StandRight && xa.facingDir == 2)
            {
                currentAnim = xa.anim.StandRight;
                mySprite.ShowFrame(12); // stand left
            }

            // climb
            if (xa.isUp && currentAnim != xa.anim.Climb)
            {
                currentAnim = xa.anim.Climb;
                mySprite.Play("climb");
            }
            if (xa.isDown && currentAnim != xa.anim.ClimbDown)
            {
                currentAnim = xa.anim.ClimbDown;
                mySprite.Play("climbDown");
            }

            if (!xa.isUp && currentAnim != xa.anim.ClimbStop && xa.facingDir == 3)
            {
                currentAnim = xa.anim.ClimbStop;
                mySprite.ShowFrame(12); // climb left
            }

            if (!xa.isDown && currentAnim != xa.anim.ClimbStop && xa.facingDir == 4)
            {
                currentAnim = xa.anim.ClimbStop;
                mySprite.ShowFrame(12); // climb left
            }
        



	/*	
		// rope
		if(xa.isLeft && xa.onRope && currentAnim != xa.anim.RopeLeft)
		{
			currentAnim = xa.anim.RopeLeft;
			mySprite.Play("ropeLeft");
		}
		if(!xa.isLeft && xa.onRope && currentAnim != xa.anim.HangLeft && xa.facingDir == 1)
		{
			currentAnim = xa.anim.HangLeft;
			mySprite.ShowFrame(2); // hang left
		}
		
		if(xa.isRight && xa.onRope && currentAnim != xa.anim.RopeRight)
		{
			currentAnim = xa.anim.RopeRight;
			mySprite.Play("ropeRight");
		}
		if(!xa.isRight && xa.onRope && currentAnim != xa.anim.HangRight && xa.facingDir == 2)
		{
			currentAnim = xa.anim.HangRight;
			mySprite.ShowFrame(2); // hang right
		}
		
		// falling
		if(xa.falling && currentAnim != xa.anim.FallLeft && xa.facingDir == 1)
		{
			currentAnim = xa.anim.FallLeft;
			mySprite.ShowFrame(0); // fall left
		}
		if(xa.falling && currentAnim != xa.anim.FallRight && xa.facingDir == 2)
		{
			currentAnim = xa.anim.FallRight;
			mySprite.ShowFrame(0); // fall right
		}
		
		// shooting
		if(xa.shooting && currentAnim != xa.anim.ShootLeft && xa.facingDir == 1)
		{
			currentAnim = xa.anim.ShootLeft;
			mySprite.ShowFrame(0); // shoot left
		}
		if(xa.shooting && currentAnim != xa.anim.ShootRight && xa.facingDir == 2)
		{
			currentAnim = xa.anim.ShootRight;
			mySprite.ShowFrame(0); // shoot right
		}*/
	}
}
