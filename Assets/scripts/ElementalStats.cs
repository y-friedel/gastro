using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalStats : MonoBehaviour {

    public enum Element { Fire = 1, Wind = 2, Ice = 3, Ground = 4 };


    [Header("General Settings")]
    public int initialPower;
    public int standardPower;
    public Element selectedElement;
    public Dictionary<Element, int> stats = new Dictionary<Element, int>();

    public float upgradeRatio;

    public void SetElementPower(Element elem, int power)
    {
        stats[elem] = power;
    }

    public void ResetStats()
    {
        standardPower = 0;
        stats[Element.Fire] = 0;
        stats[Element.Wind] = 0;
        stats[Element.Ice] = 0;
        stats[Element.Ground] = 0;
    }

    // Use this for initialization
    void Start () {
        stats.Add(Element.Fire, 0);
        stats.Add(Element.Wind, 0);
        stats.Add(Element.Ice, 0);
        stats.Add(Element.Ground, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
