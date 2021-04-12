using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade_script : MonoBehaviour
{
    public float timeDelay = 2f;
    float startTimer;
    public GameObject explosion;
    public int damage = 2;
    public float explosiveForce = 200f;
    public float explosiveRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        startTimer += Time.deltaTime;
        if(startTimer >= timeDelay){
            Explode();
        }
    }

    void Explode(){
        explosionEffect();

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosiveRadius);

        foreach(Collider nearbyObject in colliders){
            // Debug.Log(nearbyObject.name);
            // Explosion force
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null){ 
                rb.AddExplosionForce(explosiveForce, transform.position, explosiveRadius);
            }

            // Do damage to enemies
            if(nearbyObject.tag == "Range Enemy" || nearbyObject.tag == "Melee Enemy"){
                nearbyObject.GetComponent<enemy_health>().DamageEnemy(gameObject.GetComponent<Collider>());
            }
        }

        Destroy(gameObject);
    }

    void explosionEffect(){
        // Explosion effect
        GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);

        // Grow explosion over time
        explosionObject.transform.localScale += new Vector3(5f,5f,5f);

        Destroy(explosionObject, .13f);
    }
}
