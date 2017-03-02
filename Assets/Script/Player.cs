using UnityEngine;
using System.Collections;

// This script is part of the tutorial series "Making a 2D game with Unity3D using only free tools"
// http://www.rocket5studios.com/tutorials/make-a-2d-game-in-unity3d-using-only-free-tools-part-1

public class Player : MonoBehaviour {

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 12.0F;

	// shoot objects
	private Transform shootParent;
	private Renderer shootRenderer;
	private OTAnimatingSprite shootSprite;

	// movement
	private float moveSpeed = 5;
	private int moveDirX;
	private int moveDirY;
	private Vector3 movement;
	private Transform thisTransform;
			
	// raycasts
	private float rayBlockedDistX = 0.6f;
	private RaycastHit hit;
	
	// layer masks	
	private int groundMask = 1 << 8; // layer = Ground
	private int shootMask = 1 << 8 | 1 << 9; // layers = Ground, Ladder
		
	private bool dropFromRope = false;
	private bool shotBlockedLeft;
	private bool shotBlockedRight;
	
	private Vector3 spawnPoint;
	private Vector3 ladderHitbox;
	
	public int Health = 100;
	public int healthPackCount = 0;
	public bool hasKey1 = false;
	
	void Awake() 
	{
		thisTransform = transform;
	}
	
	void Start()
    {
		xa.alive = true;
		spawnPoint = thisTransform.position; // player will respawn at initial starting point
		
		// connect external objects
		//shootParent = transform.Find("shoot parent");
		//shootRenderer = GameObject.Find("shoot").renderer;
		//shootSprite = GameObject.Find("shoot").GetComponent<OTAnimatingSprite>();
    }
	
	/* ============================== CONTROLS ============================== */
	
	public void Update ()
	{		
		if (Health <= 0)
		{
            Application.LoadLevel("Death");
		}
		//UpdateRaycasts();
		xa.blockedRight = false;
		xa.blockedLeft = false;
		moveDirX = 0;
		moveDirY = 0;
		
		// move left
		if(xa.isLeft /*&& !xa.shooting*/) 
		{
			moveDirX = -2;
			xa.facingDir = 1;
		}
		
		// move right
		if(xa.isRight /*&& !xa.shooting*/) 
		{
			moveDirX = 2;
			xa.facingDir = 2;
		}
		
		// move up on ladder
		if(xa.isUp)
		{
			moveDirY = 2;
			xa.facingDir = 3;
		}
		
		// move down on ladder
		if(xa.isDown) 
		{
			moveDirY = -2;
			xa.facingDir = 4;
		}
		
		// drop from rope
		if(xa.isDown && xa.onRope) 
		{
			xa.onRope = false;
			dropFromRope = true;
		}
	
		//xa.onLadder = true;
		//xa.blockedUp = false;
		//xa.blockedDown = false;
		
		UpdateMovement();
		
		if (Input.GetKeyDown(KeyCode.H)) {
			increaseHealth(40);
		}
	}
	
	void UpdateMovement() 
	{
		/*// player is not falling so move normally
		//if(!xa.falling || xa.onLadder) 
		//{
			movement = new Vector3(moveDirX, moveDirY,0f);
			movement *= Time.deltaTime*moveSpeed;
			thisTransform.Translate(movement.x,movement.y, 0f);
			
		//}
		
		// player is falling so apply gravity*/


        CharacterController controller = GetComponent<CharacterController>();

	            moveDirection = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"), 0);

		if (Input.GetKeyUp(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.RightArrow) && 
			Input.GetKeyUp(KeyCode.UpArrow) && Input.GetKeyUp(KeyCode.DownArrow))
			{
	            moveDirection = Vector3.zero;
		}
		else 
		{
			moveDirection = transform.TransformDirection(moveDirection);
	        moveDirection *= speed;
		}

			controller.Move(moveDirection * Time.deltaTime);
	 }
	
	
	
	/* ============================== RAYCASTS ============================== */
	
	void UpdateRaycasts() 
	{
		// set these to false unless a condition below is met
		xa.blockedRight = false;
		xa.blockedLeft = false;
		shotBlockedLeft = false;
		shotBlockedRight = false;
		
		// is the player is standing on the ground?
		// cast 2 rays, one on each side of the character
		if (Physics.Raycast(new Vector3(thisTransform.position.x-0.3f,thisTransform.position.y,thisTransform.position.z+1f), -Vector3.up, out hit, 0.7f, groundMask) || Physics.Raycast(new Vector3(thisTransform.position.x+0.3f,thisTransform.position.y,thisTransform.position.z+1f), -Vector3.up, out hit, 0.7f, groundMask))
		{	
			xa.falling = false;
			
			// snap the player to the top of a ground tile if she's not on a ladder
			if(!xa.onLadder)
			{
				thisTransform.position = new Vector3(thisTransform.position.x, hit.point.y + xa.playerHitboxY, 0f);
			}
		}
		
		// then maybe she's falling
		else
		{
			if(!xa.onRope && !xa.falling && !xa.onLadder) {
				xa.falling = true;
			}
		}
		
		// player is blocked by something on the right
		// cast out 2 rays, one from the head and one from the feet
		if (Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y+0.3f,thisTransform.position.z+1f), Vector3.right, rayBlockedDistX, groundMask) || Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y-0.4f,thisTransform.position.z+1f), Vector3.right, rayBlockedDistX, groundMask))
		{
			xa.blockedRight = true;
		}
		
		// player is blocked by something on the left
		// cast out 2 rays, one from the head and one from the feet
		if (Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y+0.3f,thisTransform.position.z+1f), -Vector3.right, rayBlockedDistX, groundMask) || Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y-0.4f,thisTransform.position.z+1f), -Vector3.right, rayBlockedDistX, groundMask))
		{
			xa.blockedLeft = true;
		}
		
		// is there something blocking our shot to the right?
		if (Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y,thisTransform.position.z+1f), Vector3.right, 1f, shootMask))
		{
			shotBlockedRight = true;
		}
		
		// is there something blocking our shot to the left?
		if (Physics.Raycast(new Vector3(thisTransform.position.x,thisTransform.position.y,thisTransform.position.z+1f), -Vector3.right, 1f, shootMask))
		{
			shotBlockedLeft = true;
		}
		
		// did the shot hit a brick tile to the left?
		if (Physics.Raycast(new Vector3(thisTransform.position.x-1f,thisTransform.position.y,thisTransform.position.z+1f), -Vector3.up, out hit, 0.6f, groundMask))
		{
			if(!shotBlockedLeft && xa.isShoot && xa.facingDir == 1) {
				// breaking bricks will be added in an upcomming tutorial
				/*if (hit.transform.GetComponent<Brick>())
				{
					StartCoroutine(hit.transform.GetComponent<Brick>().PlayBreakAnim());
				}*/
			}
		}
		
		// did the shot hit a brick tile to the right?
		if(Physics.Raycast(new Vector3(thisTransform.position.x+1f,thisTransform.position.y,thisTransform.position.z+1f), -Vector3.up, out hit, 0.6f, groundMask))
		{
			if(!shotBlockedRight && xa.isShoot && xa.facingDir == 2) {
				// breaking bricks will be added in an upcomming tutorial
				/*if (hit.transform.GetComponent<Brick>())
				{
					StartCoroutine(hit.transform.GetComponent<Brick>().PlayBreakAnim());
				}*/
			}
		}
		
		// is the player on the far right edge of the screen?
		if (thisTransform.position.x + xa.playerHitboxX > (Camera.mainCamera.transform.position.x + xa.orthSizeX)) 
		{
			xa.blockedRight = true;
		}
		
		// is the player on the far left edge of the screen?
		if (thisTransform.position.x - xa.playerHitboxX < (Camera.mainCamera.transform.position.x - xa.orthSizeX)) 
		{
			xa.blockedLeft = true;
		}
	}	
	
	/* ============================== SHOOT ====================================================================== */

	
	/* ============================== DEATH AND RESPAWN ====================================================================== */
	
	void RespawnPlayer()
	{
		// respawn the player at her initial start point
		thisTransform.position = spawnPoint;
		xa.alive = true;
	}
	
	/* ============================== TRIGGER EVENTS ====================================================================== */
	
	void OnTriggerEnter(Collider other)
	{
		// did the player collide with a pickup?
		// pickups and scoring will be added in an upcomming tutorial
		/*if (other.gameObject.CompareTag("Pickup"))
		{
			if (other.GetComponent<Pickup>())
			{
				other.GetComponent<Pickup>().PickMeUp();
				xa.sc.Pickup();
			}
		}*/
	}
	
	/*void OnTriggerStay(Collider other)
	{
		
		// is the player overlapping a rope?
		if(other.gameObject.CompareTag("Rope"))
		{
			xa.onRope = false;
			
			if(!xa.onRope && !dropFromRope) 
			{
				// snap player to center of the rope
				if (thisTransform.position.y < (other.transform.position.y + 0.2f) && thisTransform.position.y > (other.transform.position.y - 0.2f))
                {
					xa.onRope = true;
					xa.falling = false;
					xa.glx = thisTransform.position;
                    xa.glx.y = other.transform.position.y;
                    thisTransform.position = xa.glx;
                }
			}
		}
	}*/
	

    public bool increaseHealth(int h)
    {
        if (Health == 100)
        {
            return false;
        }
        else if (healthPackCount > 0)
        {
            Health = Health + h;
            if (Health > 100)
                Health = 100;
			
			healthPackCount -= 1;
            
			return true;
        }
		else {return false;}
    }
	
	public void receiveHealthPack()
    {
        healthPackCount += 1;
	}
	
	public float pushPower = 2.0F;
	void OnControllerColliderHit(ControllerColliderHit hit) {
        Rigidbody body = hit.collider.attachedRigidbody;
        //Debug.Log("HIT");
		if (body == null || body.isKinematic)
            return;
        
        Vector3 pushDir = new Vector3(0, hit.moveDirection.y, hit.moveDirection.z);
        body.velocity = pushDir * pushPower;
		
    }
}