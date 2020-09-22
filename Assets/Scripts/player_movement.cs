﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class player_movement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 200f;
    public float sidewaysForce = 500f;

    public bool bIsReplaying = false;



    /// <summary>
    /// Allow subscribers to hear about player speed updates
    /// </summary>
    /// <param name="float"></param>
    public delegate void PlayerSpeed(float speed);
    public static event PlayerSpeed OnPlayerSpeedUpdate;




    // Update is called per tick
    void FixedUpdate()
    {

        rb.AddForce(0, -9.8f * Time.deltaTime, 0);

        if (rb.position.y < -2f)
        {//Reset if off the map
            FindObjectOfType<game_manager>().GameEnd();
        }

        if (OnPlayerSpeedUpdate != null)//Prevent an empty list from causing errors
        {
            OnPlayerSpeedUpdate(rb.velocity.z);
        }

        if (bIsReplaying)
        {
            return; //Running a replay, ignore active inputs
        }


        if (Input.GetKey("d")) //Move Right 
        {
            //rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveRight = new MoveRight(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveRight);
            invoker.ExecuteCommand();
        }


        if (Input.GetKey("a")) //Move Left
        {
            //rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveLeft = new MoveLeft(rb, sidewaysForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveLeft);
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("w")) //Move Forward
        {
            //rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            Command moveForward = new MoveForward(rb, forwardForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveForward);
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("s")) //Move Backwards
        {
            //rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
            Command moveBack = new MoveBack(rb, forwardForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveBack);
            invoker.ExecuteCommand();

        }


    }
    //Wander: Simplify to rand inside min max angle
}

