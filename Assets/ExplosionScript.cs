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

    void OnTriggerEnter(Collider nearbyObject)
    {
        //Debug.Log(nearbyObject.name);

        // Do damage to enemies
        if(nearbyObject.tag == "Enemy"){
            // Explosion force on enemy transform
                // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                // if(rb != null){ 
                //     rb.AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
                // }

            nearbyObject.GetComponent<EnemyController>().DamageEnemy(grenadeDmg);
        }
    }
}
