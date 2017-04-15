using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public GameObject enemySlot;

    public float initialTime;
    public float initialLife;

    public int nbTotalEnemies;

    // Use this for initialization
    void Start () {
        initialTime = Time.time;
        nbTotalEnemies = 0;
    }
	
    public void GenerateEnemy()
    {
        nbTotalEnemies++;
        float currentTime = Time.time - initialTime;
        int lifeRatio = Random.Range(50, 100);

        enemySlot.GetComponent<PV>().SetPV(Mathf.CeilToInt(initialLife * lifeRatio / 100));
        enemySlot.GetComponent<Weapons>().ShuffleWeapon(100-lifeRatio, currentTime);
    }


	// Update is called once per frame
	void Update () {
		// if ennemy is dead, generate a new ennemy
	}
}
