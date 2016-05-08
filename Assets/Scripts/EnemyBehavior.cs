using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts;


public class EnemyBehavior : MonoBehaviour {

    private Rigidbody rgd;
    private int patternIterator = -1;
    private float movementLeft = 0;
    private List<Movement> movementPattern;
    public ThirdPersonCharacter character { get; private set; } // the character we are controlling

    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;





    void Start() {
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;
        character = GetComponent<ThirdPersonCharacter>();
        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.

        agent.destination = points[destPoint].position;


        

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update() {
        // Choose the next destination point when the agent gets
        // close to the current one.
        character.Move(agent.desiredVelocity,  false);

        if (agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}
