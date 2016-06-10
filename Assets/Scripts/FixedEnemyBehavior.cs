using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts;


public class FixedEnemyBehavior : EnemyWithAttackCollider{
    
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

   

}
