using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public float explosionGrowth = 1.5f;
    public int grenadeDmg = 4;

    // Update is called once per frame
    void Update()
    {
        // Grow explosion over time
        gameObject.transform.localScale += new Vector3(explosionGrowth,explosionGrowth,explosionGrowth);
    }

    void OnTriggerEnter(Collider enemy)
    {
        // Do damage to enemies
        if(enemy.tag == "Enemy"){
            Debug.Log("Exploded enemy " + enemy.name);
            // Explosion force on enemy transform
                // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                // if(rb != null){ 
                //     rb.AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
                // }

            enemy.GetComponent<EnemyController>().DamageEnemy(grenadeDmg);
        }
    }
}
