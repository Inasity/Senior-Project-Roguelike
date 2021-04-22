using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class backpackUI : MonoBehaviour
{
    // Images for the UI
    [SerializeField] Image current;
    [SerializeField] Image next;
    [SerializeField] Image previous;

    // Sprites for items
    [SerializeField] Sprite grenade;
    [SerializeField] Sprite gas;
    [SerializeField] Sprite trap;
    [SerializeField] Sprite none;

    private int nextCycle, prevCycle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Update current slot 
        if(player_inventory.itemBackpack[Weapon.cycle].itemName == "grenade(Clone)" || player_inventory.itemBackpack[Weapon.cycle].itemName == "grenade"){
            current.sprite = grenade;
        } else if (player_inventory.itemBackpack[Weapon.cycle].itemName == "trap(Clone)" || player_inventory.itemBackpack[Weapon.cycle].itemName == "trap"){
            current.sprite = trap;
        } else if (player_inventory.itemBackpack[Weapon.cycle].itemName == "gas(Clone)" || player_inventory.itemBackpack[Weapon.cycle].itemName == "gas"){
            current.sprite = gas;
        } else {
            current.sprite = none;
        }

        // Check nextCycle index
        if(Weapon.cycle == 0) nextCycle = 1;
        else if(Weapon.cycle == 1) nextCycle = 2;
        else if(Weapon.cycle == 2) nextCycle = 0;

        // Update next slot
        if(player_inventory.itemBackpack[nextCycle].itemName == "grenade(Clone)" || player_inventory.itemBackpack[nextCycle].itemName == "grenade"){
            next.sprite = grenade;
        } else if (player_inventory.itemBackpack[nextCycle].itemName == "trap(Clone)" || player_inventory.itemBackpack[nextCycle].itemName == "trap"){
            next.sprite = trap;
        } else if (player_inventory.itemBackpack[nextCycle].itemName == "gas(Clone)" || player_inventory.itemBackpack[nextCycle].itemName == "gas"){
            next.sprite = gas;
        } else {
            next.sprite = none;
        }

        // Check prevCycle index
        if(Weapon.cycle == 0) prevCycle = 2;
        else if(Weapon.cycle == 1) prevCycle = 0;
        else if(Weapon.cycle == 2) prevCycle = 1;

        // Update next slot
        if(player_inventory.itemBackpack[prevCycle].itemName == "grenade(Clone)" || player_inventory.itemBackpack[prevCycle].itemName == "grenade"){
            previous.sprite = grenade;
        } else if (player_inventory.itemBackpack[prevCycle].itemName == "trap(Clone)" || player_inventory.itemBackpack[prevCycle].itemName == "trap"){
            previous.sprite = trap;
        } else if (player_inventory.itemBackpack[prevCycle].itemName == "gas(Clone)" || player_inventory.itemBackpack[prevCycle].itemName == "gas"){
            previous.sprite = gas;
        } else {
            previous.sprite = none;
        }

    }
}
