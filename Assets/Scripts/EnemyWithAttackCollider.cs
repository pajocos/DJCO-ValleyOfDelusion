using UnityEngine;
using System.Collections;

public class EnemyWithAttackCollider : MonoBehaviour {

    public PlayerBehaviour Player;
    public float cooldownTime = 2f;
    public float knockBack = 4f;
    public BoxCollider attackCollider;

    private float currentCooldown = 0f;
    protected Animator animator;
    private bool attacking = false;

    public AudioSource AttackSound;
    public float PitchRange = 0.2f;

    public float pushDelay= 1f;
    private float pushCountDown = 1f;   

    public void PushEnemy()
    {
        if (currentCooldown == 0f) {
            animator.SetTrigger("Attack");
            currentCooldown = cooldownTime;
            attacking = true;
            
            AttackSound.pitch = 1f + Random.Range(-0.2f, 0.2f);
            AttackSound.Play();
        }
    }

    void FixedUpdate() {

        currentCooldown -= Time.fixedDeltaTime;
        if (attacking) {
            pushCountDown -= Time.fixedDeltaTime;
        }
        if (currentCooldown < 0f) {
            currentCooldown = 0f;
        }
        if (pushCountDown < 0f) {
            pushCountDown = 0f;
        }
        if (pushCountDown == 0) { 
            Player.movement.PushBack(knockBack, Player.transform.forward);
            pushCountDown = pushDelay;
            attacking = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == ("Player"))
        {
            Player.movement.PushBack(10f, transform.forward);            
        }
    }

    public void TriggerWithPlayer() {

        PushEnemy();
    }

    public void StopAttack() {
        pushCountDown = pushDelay;
        attacking = false;
    }

}
