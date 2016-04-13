using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	public float minX, maxX;
	
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
		//Debug.Log(ball);
	}
	
	// Update is called once per frame
	void Update () {
		if (!autoPlay){
			MoveWithMouse();
		} else {
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		float ballPos = ball.transform.position.x;		
		paddlePos.x = Mathf.Clamp(ballPos,minX, maxX);
		this.transform.position = paddlePos;	
		//Debug.Log(ball.transform.position.y);
	}
	
	void MoveWithMouse(){
		// variables
		float mousePositionX;
		Vector3 paddlePos = new Vector3 (0.5f,this.transform.position.y,this.transform.position.z);
		// calculate mouse pos in world units
		mousePositionX = Input.mousePosition.x /Screen.width * 16;
		// lock padle to the screen	
		paddlePos.x = Mathf.Clamp(mousePositionX, minX, maxX);
		//Set position
		this.transform.position = paddlePos;	
	}
}
