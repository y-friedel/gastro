using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public int value;
    public int damageValue;

    public GameObject hero;

    private bool damageMode;

    public void AddPV()
    {
        hero.GetComponent<PV>().AddPV(value);
    }

    public void EnableDamage()
    {
        damageMode = true;
    }

    public void DisableDamage()
    {
        damageMode = false;
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
