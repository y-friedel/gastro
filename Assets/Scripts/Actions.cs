﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public int potion;
    // public int damage;

    public GameObject hero;
    public GameObject ennemy;

    public void AddPV()
    {
        hero.GetComponent<PV>().AddPV(potion);
    }

    public void SubPV()
    {
        ennemy.GetComponent<PV>().RemovePV(hero.GetComponent<Weapons>().damage);
    }

    /*
    // Use this for initialization
    void Start()
    {
        addPVText.text = "Add";
        subPVText.text = "Sub";
    }
    */

    /*
    public void SetAdd()
    {
        addPVText.text = "Add";
    }

    public void SetSub()
    {
        subPVText.text = "Add";
    }
    */


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
