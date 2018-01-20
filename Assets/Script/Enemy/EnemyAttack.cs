using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public GameObject player;
    public Animator animator;
    PlayerHealth playerHealth;
    PlayerTracking playerTracking;
 
    //public bool playertInRange;
    public float timer;

    [Header("攻擊間距時間")]
    public float timeBetweenAttack = 1f;
    [Header("攻擊傷害")]
    public int attackDamage = 10;

    public bool isAttack;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerTracking = this.GetComponent<PlayerTracking>();
	}
	
	// Update is called once per frame
	void Update () {
        if(playerTracking.attackRange.playertInRange)
        {
            //isAttack = true;
            animator.SetBool("attack", true);
            timer += Time.deltaTime;
            if (timer >= timeBetweenAttack )
            {
                Attack();
            }
            else
            {
                //isAttack = false;
                animator.SetBool("attack", false);
            }
        }
        //animator.SetBool("attack", isAttack);
        //if(timer < timeBetweenAttack)
        //{
        //    animator.SetBool("attack", false);
        //}

        //if (timer > timeBetweenAttack && playerTracking.attackRange.playertInRange)
        //{
        //    Attack();
        //}
        //else
        //{
        //    animator.SetBool("attack", false);
        //}
    }

    void Attack()
    {
        timer = 0.0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
