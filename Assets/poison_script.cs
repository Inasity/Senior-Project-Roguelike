using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poison_script : MonoBehaviour
{
    public float poisonTimer = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Count down
        poisonTimer -= Time.deltaTime;

        // When timer is up, destroy poison
        if(poisonTimer <= 0){
            Destroy(gameObject);
        }
    }
}
