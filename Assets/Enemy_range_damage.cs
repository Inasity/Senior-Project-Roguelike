using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_range_damage : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    private float cooldown = .8f;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        // Timer for shooting, could be different for different range types
        timer  = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            timer = cooldown;

            // Depending on type of weapon, call different shoot
            ShootBullet();
        }
    }
    void ShootBullet()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
