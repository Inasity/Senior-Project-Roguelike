using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_script : MonoBehaviour
{
    // Poison gas disappears after 5 seconds, and it does
    // 2 damage every second to all enemies inside

    public float poisonTimer = 5;
    public int poisonDPS = 2;
    public float DPSTimer = 1f;

    // Update is called once per frame
    void Update()
    {
        // Count down timers
        poisonTimer -= Time.deltaTime;
        DPSTimer -= Time.deltaTime;

        // When poison timer is up, destroy poison
        if(poisonTimer <= 0){
            Destroy(gameObject);
        }
    }

    void OnTriggerStay(Collider enemy)
    {
        // Do damage when enemy in the gas
        if(enemy.tag == "Enemy"){
            if(DPSTimer <= 0 && enemy != null){
                Debug.Log("poisoned enemy " + enemy.name);
                enemy.GetComponent<EnemyController>().DamageEnemy(poisonDPS);
                DPSTimer = 1;
            }
        }
    }
}
