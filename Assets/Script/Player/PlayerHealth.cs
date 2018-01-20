using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    public int currentHealth;
    public Slider HPSlider;
    public Animator animator;
    public bool damage;
    public bool isDead;


    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if (damage)
        {
            animator.SetBool("damage", true);
        }
        else
        {
            animator.SetBool("damage", false);
        }
        damage = false;
	}

    public void TakeDamage(int amount)
    {
        damage = true;
        //animator.SetBool("damage", true);
        currentHealth -= amount;
        HPSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        animator.SetBool("isDead", true);
    }
}
