using UnityEngine;
using System.Collections;
using System;

public class TriggerBehauviour : MonoBehaviour {

    public GameObject Target;
    public ITriggableBehauviour ITarget;

    void OnTriggerEnter(Collider col)
    {
        //Type t = typeof(ITriggableBehauviour);
        ITarget = (ITriggableBehauviour) Target.GetComponent(typeof(ITriggableBehauviour));
        ITarget.RemoteTrigger();      
    }

}
