using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 10;
    public float timeBetweenAttack = 0.5f;
    public GameObject player;
    public Animator animator;
    PlayerHealth PlayerHealth;

    public bool playertInRange;
    public float timer;



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHealth = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		if(timer > timeBetweenAttack && playertInRange)
        {
            Attack();
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== player)
        {
            playertInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playertInRange = false;
        }
    }
    void Attack()
    {
        timer = 0.0f;
        if(PlayerHealth.currentHealth > 0)
        {
            PlayerHealth.TakeDamage(attackDamage);
        }
    }
}
