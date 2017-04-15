using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV : MonoBehaviour {

    public uint value;
    public Text linkedText;
	// Use this for initialization
	void Start () {
        value = 100;
        linkedText.text = value.ToString();
	}

    public void AddPV(uint pvToAdd)
    {
        value += pvToAdd;
        linkedText.text = value.ToString();
    }

    public void RemovePV(uint pvToRemove)
    {
        value -= pvToRemove;
        linkedText.text = value.ToString();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
