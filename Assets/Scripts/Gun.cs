using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] float Range = 100f;
    [SerializeField] float Damage = 10f;
    [SerializeField] Camera Cam;
    [SerializeField] GameObject impactEffect;
    [SerializeField] private AudioSource Sound;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, Range))
        {
            if (hit.transform.CompareTag("Enemy"))
            {
                Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.AddForce(-hit.normal * Damage, ForceMode.Impulse);
                }

                // Enemy scriptine sahip olup olmadýðýný kontrol et ve hasar ver
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(Damage);
                }

                Sound.Play();
            }
        }
    }
}
