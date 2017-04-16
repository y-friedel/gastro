using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalStats : MonoBehaviour {

    public enum Element { Fire = 1, Wind = 2, Ice = 3, Ground = 4 };

    public int standardStats;
    public Dictionary<Element, int> stats;

    public void SetElementPower(Element elem, int power)
    {
        stats[elem] = power;
    }

    public void ResetStats()
    {
        standardStats = 0;
        stats[Element.Fire] = 0;
        stats[Element.Wind] = 0;
        stats[Element.Ice] = 0;
        stats[Element.Ground] = 0;
    }

    // Use this for initialization
    void Start () {
        stats = new Dictionary<Element, int>();
        stats.Add(Element.Fire, 0);
        stats.Add(Element.Wind, 0);
        stats.Add(Element.Ice, 0);
        stats.Add(Element.Ground, 0);
    }
	

    public void Shuffle(float currentTime)
    {
        int newRatio = Random.Range(5, 50);
        Element elementType = (ElementalStats.Element)Random.Range(1, 5);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
