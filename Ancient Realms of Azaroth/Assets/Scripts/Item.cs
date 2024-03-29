﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    [Header("Item Type")]
    public bool isItem;
    public bool isWeapon;
    public bool isArmor;

    [Header("Item Details")]
    public string itemName;
    public string desc;
    public int value;
    public Sprite itemSprite;

    [Header("Items Details")]
    public int amountToChange;
    public bool affectHP, affectMP, affectStr;

    [Header("Weapon/Armor Details")]
    public int weaponStr;

    public int armorStr;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Use(int charToUseOn)
    {
        CharStats selectedChar = GameManager.instance.playerStats[charToUseOn];

        if (isItem)
        {
            if (affectHP)
            {
                selectedChar.currentHP += amountToChange;

                if(selectedChar.currentHP > selectedChar.maxHP)
                {
                    selectedChar.currentHP = selectedChar.maxHP;
                }
            }

            if (affectMP)
            {
                selectedChar.currentMP += amountToChange;

                if (selectedChar.currentMP > selectedChar.maxMP)
                {
                    selectedChar.currentMP = selectedChar.maxMP;
                }
            }

            if (affectStr)
            {
                selectedChar.strength = amountToChange;
            }
        }

        if (isWeapon)
        {
            if(selectedChar.equippedWpn != "") //check if weapon is already equipped and if it is add it to inv or if not equip it
            {
                GameManager.instance.AddItem(selectedChar.equippedWpn);
            }

            selectedChar.equippedWpn = itemName;
            selectedChar.wpnPwr = weaponStr;
        }

        if (isArmor)
        {
            if (selectedChar.equippedAmr != "") //check if armor is already equipped and if it is add it to inv or if not equip it
            {
                GameManager.instance.AddItem(selectedChar.equippedAmr);
            }

            selectedChar.equippedAmr = itemName;
            selectedChar.armrPwr = armorStr;
        }

        GameManager.instance.RemoveItem(itemName);
    }
}
