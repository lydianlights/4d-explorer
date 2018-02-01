using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    // Set in Unity
    public float Gravity = 20f;
    
    [NonSerialized]
    public Vector3 Velocity = new Vector3(0, 0, 0);

    private CharacterController control;

    // Run on script load
    public void Awake()
    {
        control = GetComponent<CharacterController>();
    }

    // Run on object load
    public void Start()
    {
		
	}

    // Run every frame
    public void Update()
    {
        
    }

    // Run every physics frame
    public void FixedUpdate()
    {
        Velocity.y -= Time.deltaTime * Gravity;
        if (control.isGrounded)
        {
            Velocity.y = 0;
        }
        control.Move(Time.deltaTime * Velocity);
    }
}
