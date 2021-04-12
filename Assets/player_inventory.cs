using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_inventory : MonoBehaviour
{
    // Size of backpack for keys and items
    private const int BACKPACK_SIZE = 3;

    // Structure of a key
    public struct Key{
        // Name of what the key unlocks
        /* 
            The unlock name can be grabbed by player controller 
            which decides what to do with the item
        */
        public string keyUnlocks;

        // Color of the key on GUI (red for door, yellow for chest)
        public Color keyColor;
    }

    // Structure of an item
    public struct Item{
        // Name of the item
        /* 
            The name of the item can be grabbed by player controller 
            which decides what to do with the item
        */
        public string itemName;
    }

    // Backpacks for keys and items    
    public Key[] keyBackpack = new Key[BACKPACK_SIZE];
    public Item[] itemBackpack = new Item[BACKPACK_SIZE];

    // DNA is game currency
    public int DNA;
    
    // Start is called before the first frame update
    void Start()
    {
        // Start currency at 0
        DNA = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other)
    {
        // Check if player has collided with an item
        if(other.tag == "Item"){
            // Check what item it was before destroying
            if(other.name == "health_item"){
                Health.health++;
                // Destroy the item
                Destroy(other.gameObject);
            } else if (other.name == "dna"){
                DNA += 1;
                // Destroy the item
                Destroy(other.gameObject);
            } else if (other.name == "Key"){
                // Check if the key backpack has empty spot
                for(int c = 0; c < BACKPACK_SIZE; c++){
                    if(keyBackpack[c].keyUnlocks == null){
                        // Add key to backpack
                        int choose = Random.Range(1,3);
                        if(choose == 1){
                            // Key unlocks a door
                            keyBackpack[c].keyUnlocks = "door";
                            keyBackpack[c].keyColor = Color.red;
                        } else if(choose == 2){
                            // Key unlocks a chest
                            keyBackpack[c].keyUnlocks = "chest";
                            keyBackpack[c].keyColor = Color.yellow;
                        }
                        // If a key was added, destroy it's object and stop loop
                        Destroy(other.gameObject);
                        break;
                    }
                }
            } else if (other.name == "grenade" || other.name == "trap" || other.name == "gas"){
                // *** ^ Add in names of other items in above conditional ^ ***

                // Check if the item backpack has empty spot
                for(int c = 0; c < BACKPACK_SIZE; c++){
                    if(itemBackpack[c].itemName == null){
                        // Add item name to backpack in open slot
                        itemBackpack[c].itemName = other.name;

                        // If an item was added, destroy it's object and stop loop
                        Destroy(other.gameObject);
                        break;
                    }
                }
            }
        }
    }
}