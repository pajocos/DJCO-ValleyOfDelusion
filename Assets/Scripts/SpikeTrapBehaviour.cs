using UnityEngine;
using System.Collections;

public class SpikeTrapBehaviour : EnemyWithAttackCollider, ITriggableBehauviour{
    
    void Update()
    {
        UpdateAttackCollider();
    }

    public void Trigger()
    {
        PushEnemy();
    }
}
