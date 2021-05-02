using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    // Trap does not disappear, it stops enemy movements
    // and does 1 damage per 3 seconds
    public int trapDamage = 1;
    public float damageTimer = 3f;

    // Update is called once per frame
    void Update()
    {
        // Count down timer
        damageTimer -= Time.deltaTime;
    }

    void OnTriggerStay(Collider enemy){
        if(enemy != null){
            // Do damage and stop movement when enemy in the gas
            if(enemy.tag == "Enemy"){
                // Reduce the enemy speed to zero after 1 second inside trap
                enemy.GetComponent<EnemyController>().speed = 0;

                // Deal 1 damage every 3 seconds when inside trap
                if(damageTimer <= 0){
                    Debug.Log("trapped enemy " + enemy.name);
                    enemy.GetComponent<EnemyController>().DamageEnemy(trapDamage);
                    damageTimer = 3;
                }
            }
        }
    }

}
