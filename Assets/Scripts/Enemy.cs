using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    private bool isDead = false;

    public void TakeDamage(float damage)
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetBool("ÝsDeath", true);
            Destroy(gameObject, 2f); // 3 saniye sonra düþmaný yok et
        }
    }
}
