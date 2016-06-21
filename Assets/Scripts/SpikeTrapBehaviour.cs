using UnityEngine;
using System.Collections;

public class SpikeTrapBehaviour : EnemyWithAttackCollider, ITriggableBehauviour{
    
    void Update()
    {
        
    }

    public void RemoteTrigger()
    {
        PushEnemy();
    }
}
