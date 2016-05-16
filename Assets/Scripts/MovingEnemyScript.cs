﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts;


public class MovingEnemyScript : MonoBehaviour
{

    private Rigidbody rgd;
    private int patternIterator = -1;
    private float movementLeft = 0;
    private List<Assets.Scripts.Utils.Movement> movementPattern;
    //public CharacterMovement movement; // the character we are controlling

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private CharacterMovement movement;
    



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();


        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        //character = GetComponent<ThirdPersonCharacter>();
        movement = GetComponent<CharacterMovement>();
        GotoNextPoint();
        movement.Rotation = Vector3.Angle(agent.destination-transform.position, transform.forward);
    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.

        agent.destination = points[destPoint].position;




        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void FixedUpdate()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //character.Move(agent.desiredVelocity,  false);
        // transform.forward;
        float angle = Vector3.Angle(agent.destination-transform.position, transform.forward);
        if (angle > movement.Rotation + 10f)
        {
            movement.Move(-agent.angularSpeed, 0f, false);
        }
        else if (angle < movement.Rotation - 10f)
        {
            movement.Move(agent.angularSpeed, 0f, false);
        }
        else
        {
            movement.Move(0f, agent.desiredVelocity.z, false);
        }
        //movement.Move(Mathf.Atan2(agent.desiredVelocity.x, agent.desiredVelocity.z), agent.desiredVelocity.z, false);




        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }



}