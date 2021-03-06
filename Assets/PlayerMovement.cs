﻿using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController Controller;
	public float Speed = 10f;
	public float Gravity = -10f;
	public float JumpHeight = 1f;

	public Transform GroundCheck;
	public float GroundDistance = 0.4f;
	public LayerMask GroundMask;
	public Transform CentreOfGravity;

	private Vector3 Velocity;
	private bool IsGrounded;

	// Update is called once per frame
	void Update()
	{
		// movement
		var x = Input.GetAxis("Horizontal");
		var z = Input.GetAxis("Vertical");
		var move = transform.right * x + transform.forward * z;
		// falling
		IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);
		if (IsGrounded && Velocity.y < 0)
		{
			Velocity.y = -2f;
		}
		else
		{
			Velocity.y += Gravity * Time.deltaTime;
		}
		// jumping
		if (Input.GetButtonDown("Jump") && IsGrounded)
		{
			Velocity.y = Mathf.Sqrt(JumpHeight * -2f * Gravity);
		}
		Controller.Move((Velocity + move * Speed)* Time.deltaTime);
		// orientation
		var dx = transform.position.x - CentreOfGravity.transform.position.x;
		var dy = transform.position.y - CentreOfGravity.transform.position.y;
		var dz = transform.position.z - CentreOfGravity.transform.position.z;
		transform.rotation = Quaternion.Euler(
			(float)(Math.Tanh(dz / dy) * 180 / Math.PI),
			transform.rotation.eulerAngles.y,
			-(float)(Math.Tanh(dx / dy) * 180 / Math.PI));
	}
}
