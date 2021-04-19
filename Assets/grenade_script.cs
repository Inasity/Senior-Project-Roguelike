using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade_script : MonoBehaviour
{
    public float timeDelay = 2f;
    float startTimer;
    public GameObject explosion;
    public float explosionTime = .13f;

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
        Destroy(gameObject);
    }

    void explosionEffect(){
        // Explosion effect
        GameObject explosionObject = Instantiate(explosion, transform.position, transform.rotation);
        explosionObject.GetComponent<ExplosionScript>().enabled = true;
        Destroy(explosionObject, explosionTime);
    }
}
