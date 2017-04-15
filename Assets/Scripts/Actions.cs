using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public int damageValue;
    public int potion;

    public GameObject hero;
    public GameObject ennemy;

    private bool damageMode;

    public void AddPV()
    {
        hero.GetComponent<PV>().AddPV(potion);
    }

    public void EnableDamage()
    {
        damageMode = true;
    }

    public void DisableDamage()
    {
        damageMode = false;
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
        damageMode = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(damageMode)
        {
            hero.GetComponent<PV>().RemovePV(damageValue);
        }
	}
    
}
