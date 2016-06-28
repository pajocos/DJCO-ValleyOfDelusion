// MoveTo.cs
using UnityEngine;
using System.Collections;

public class MovingEnemyScript : MonoBehaviour
{

    public PlayerBehaviour Player;
    public Transform[] PatrolPoints;

    public float SensePlayer = 15f;

    private NavMeshAgent agent;
    private int destPoint;

    public MusicScript music;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destPoint = 0;
        GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        if (PatrolPoints.Length == 0)
            return;

        destPoint = (destPoint + 1) % PatrolPoints.Length;

        agent.destination = PatrolPoints[destPoint].position;
    }


    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, agent.destination) < 1f)
        {
            GoToNextPoint();
        } 
        if (Vector3.Distance(transform.position, Player.transform.position) < SensePlayer)
        {
            agent.destination = Player.transform.position;

        }
    }

    void StepSound(string str) {
        music.StepSound(str);
    }
}