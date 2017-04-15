using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PV : MonoBehaviour {

    public float value;
    public Text linkedText;

	// Use this for initialization
	void Start () {
        ShowPVText();
    }

    public void SetPV(float pv)
    {
        value = pv;
        ShowPVText();
    }

    public void AddPV(float pvToAdd)
    {
        value += pvToAdd;
        ShowPVText();
    }

    public void RemovePV(float pvToRemove)
    {
        value -= pvToRemove;
        ShowPVText();
    }

    public void ShowPVText()
    {
        linkedText.text = Mathf.CeilToInt(value).ToString();
    }

    // Update is called once per frame
    void Update ()
    {

	}
}
