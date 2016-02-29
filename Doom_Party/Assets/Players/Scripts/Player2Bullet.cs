﻿using UnityEngine;
using System.Collections;


public class Player2Bullet : MonoBehaviour {

	public GameObject BulletHit;
	public GameObject Blood;
	private float speedX;
	private float speedY;
	private float speed;
	private int deleteTime;

	void Start() {
		speedX = 0;
		speedY = 0;
		speed = 0.5f; //bullet speed
		deleteTime = 0;

		speedX = Mathf.Sin(MyGlobalAngleController2.SharedInstance.JoyAngle);
		speedY = Mathf.Cos(MyGlobalAngleController2.SharedInstance.JoyAngle);
		transform.localEulerAngles = new Vector3 (0,0,MyGlobalAngleController2.SharedInstance.JoyAngle/Mathf.PI*-180);

		transform.localScale = new Vector3 (1, 3, 1);

		//starting distance/radius from the player
		transform.position = new Vector3 (transform.position.x + speedX*0.8f-5000.5f, transform.position.y + speedY*0.8f, 0);

		// Adjust the speed of the bullets
		speedX = speedX + Random.Range(-0.05f, 0.05f);
		speedY = speedY + Random.Range(-0.05f, 0.05f);
		speedX = speedX * speed;
		speedY = speedY * speed;

	}


	void FixedUpdate() {

		transform.position = new Vector3 (transform.position.x + speedX, transform.position.y + speedY, 0);

		deleteTime++;
		if (deleteTime > 100){
			Destroy(gameObject);
		}

	}


	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Wall") {
			Instantiate (BulletHit, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Player") {
			Instantiate (Blood, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
		if (col.gameObject.tag == "Enemy") {
			Instantiate (Blood, new Vector3 (transform.position.x+speedX/2.0f, transform.position.y+speedY/2.0f,0), Quaternion.identity);
			Destroy(gameObject);
		}
	}


}