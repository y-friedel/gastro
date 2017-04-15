using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public GameObject enemySlot;

	// Use this for initialization
	void Start () {
		//Generate the firstEnnemy
	}
	
    public void GenerateEnemy()
    {
        int newPV;
        if(Random.value > 0.5)
            newPV = 200;
        else
            newPV = 100;

        enemySlot.GetComponent<PV>().SetPV(newPV);
    }


	// Update is called once per frame
	void Update () {
		// if ennemy is dead, generate a new ennemy
	}
}
