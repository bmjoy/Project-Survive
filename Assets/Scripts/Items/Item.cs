﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public string itemName;
    public ItemAbility itemAbility;

	// Use this for initialization
	void Start ()
    {
        itemAbility = GetComponent<ItemAbility>();
	}

    public void useItem()
    {
        itemAbility.useItem();
    }

    public void instantiate(Vector3 spawnPos)
    {
        Item item = Instantiate(this, spawnPos, Quaternion.identity);
        item.gameObject.name = itemName;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            Player.instance.itemEnterProximity(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Player.instance.itemLeaveProximity(this);
        }
    }

}
