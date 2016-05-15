using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts;


public class FixedEnemyBehavior : MonoBehaviour {

    public PlayerBehaviour Player;
    public float attackDistance = 10f;
    public float adjustment = 1f;
    public float punchDistance = 3f;
    public float punchSpeed = 1f;
    public float knockBack = 10f;


    private Rigidbody rgd;    
    private BoxCollider attackCollider;

    void Start() {
       
        attackCollider = GetComponentInChildren<BoxCollider>();
        attackCollider.enabled = false;
        

    }


    void FixedUpdate() {

        float distance = Vector3.Distance(Player.transform.position, transform.position);
        float internalProduct = Vector3.Dot(transform.forward, Player.transform.position - transform.position);
        
        if (distance <= attackDistance && Mathf.Abs(internalProduct) > adjustment && !attackCollider.enabled)
            PushEnemy();

        UpdateAttackCollider();

    
    }

    private void PushEnemy()
    {
        attackCollider.enabled = true;
        attackCollider.transform.position = transform.position;        
    }

    private void UpdateAttackCollider()
    {
        if(attackCollider.enabled)
        {
            if (Vector3.Distance(attackCollider.transform.position, transform.position) < punchDistance)
            {
                attackCollider.transform.position += transform.forward * punchSpeed * Time.deltaTime;
            }
            else
            {
                attackCollider.enabled = false;
            }
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag ==("Player"))
        {
            Player.movement.PushBack(10, transform.forward);
            attackCollider.enabled = false;
        }
    }


}
