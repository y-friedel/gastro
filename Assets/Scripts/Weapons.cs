using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapons : MonoBehaviour {


    [Header("Computing Settings")]
    public int initialDamage;
    public float initialTime;
    public float evolutionRate; // Power evolution between two steps
    public float timeStepDuration; // Duration of a step in seconds

    public enum Element {Fire, Wind, Ice, Ground};

    [Header("Current Weapon")]
    public int damage;
    public int elementalDamage;
    public Element elementType;


    public void ShuffleWeapon(int powerPercent, float currentTime)
    {
        int tempDamage = initialDamage + Mathf.FloorToInt(initialDamage * ((currentTime / timeStepDuration) * evolutionRate * powerPercent / 100));

        int elementalPart = Random.Range(1, 20);
        damage = (100 - elementalPart) * tempDamage / 100;
        elementalDamage = tempDamage - damage;
    }


    // Use this for initialization
    void Start () {
        initialTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	}
}
