using UnityEngine;
using System.Collections;

public class EnemyWithAttackCollider : MonoBehaviour {

    public PlayerBehaviour Player;
    public float attackDistance = 10f;
    public float adjustment = 1f;
    public float punchDistance = 3f;
    public float punchSpeed = 1f;
    public float knockBack = 10f;
    public BoxCollider attackCollider;


    public void PushEnemy()
    {
        attackCollider.enabled = true;
        attackCollider.transform.position = transform.position;
    }

    public void UpdateAttackCollider()
    {
        if (attackCollider.enabled)
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


    void OnTriggerEnter(Collider col)
    {
        if (col.tag == ("Player"))
        {
            Player.movement.PushBack(10f, transform.forward);
            attackCollider.enabled = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == ("Player"))
        {
            Player.movement.PushBack(10f, transform.forward);
            attackCollider.enabled = false;
        }
    }

}
