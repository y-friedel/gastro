using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public uint value;

    public GameObject hero;

    public void AddPV()
    {
        hero.GetComponent<PV>().AddPV(value);
    }

    public void SubPV()
    {
        hero.GetComponent<PV>().RemovePV(value);
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
