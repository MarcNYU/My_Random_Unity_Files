﻿using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	
	// 2 - Store the movement and the component
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;
	
	void Update()
	{
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");

		// 5 - Shooting
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		
		if (shoot)
		{
			weapon w = GetComponent<weapon>();
			if (w != null)
			{
				// false because the player is not an enemy
				w.Attack(false);
			}
		}

		
		// 4 - Movement per direction
		movement = new Vector2(speed.x * inputX, speed.y * inputY);
		
	}
	
	void FixedUpdate()
	{
		// 5 - Get the component and store the reference
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();
		
		// 6 - Move the game object
		rigidbodyComponent.velocity = movement;
	}
}