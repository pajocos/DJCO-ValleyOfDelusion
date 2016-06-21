using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Utils;
using Assets.Scripts;
using System;

public class FixedEnemyBehavior : EnemyWithAttackCollider{
    
    public float attackDistance = 10f;
    public float adjustment = 1f;


    void Start() {
       

        this.animator = GetComponent<Animator>();
    }

    
}
