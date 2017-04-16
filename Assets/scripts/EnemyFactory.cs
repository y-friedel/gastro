using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour {

    public GameObject enemySlot;

    public int nbTotalEnemies;

    [Header("General Settings")]
    public float initialTime;
    public float timeStepDuration; // Duration of a step in seconds

    [Header("Enemy Weapon Settings")]
    public float damageEvolutionRate; // Power evolution between two steps
    public float damageUpdate;

    [Header("Enemy Life Settings")]
    public int initialLife;
    public float lifeEvolutionRate; // Power evolution between two steps
    public float lifeUpdate;

    [Header("Enemy Elemental Settings")]
    public int initialPower;
    public float powerEvolutionRate; // Power evolution between two steps
    public float powerUpdate;


    // Use this for initialization
    void Start () {
        initialTime = Time.time;
        nbTotalEnemies = 0;

        GenerateEnemy();
    }

    public void GenerateEnemy()
    {
        nbTotalEnemies++;
        float currentTime = Time.time - initialTime;

        int lifeRatio = Random.Range(50, 100);
        int damageRatio = 100 - lifeRatio;
        int elementalSubRatio = Random.Range(1, 30);

        float lifePower = (initialLife + initialLife * lifeRatio / 100f) // Random Modifier 
                                * (currentTime / timeStepDuration) * lifeEvolutionRate // Time Modifier
                                * lifeUpdate; // Magic Modifier


        float statsPower = (initialPower + initialPower * damageRatio / 100f)
                                * (currentTime / timeStepDuration) * damageEvolutionRate // Time Modifier
                                * powerUpdate; // Magic Modifier

        float subElementalPower = statsPower * elementalSubRatio / 100f;
        float subStandardPower = statsPower - subElementalPower;

        // Set life
        enemySlot.GetComponent<PV>().SetPV(lifePower);

        // Set stats
        ElementalStats ennemyElementalStats = enemySlot.GetComponent<ElementalStats>();
        ElementalStats.Element elementType = (ElementalStats.Element)Random.Range(1, 5);
        ennemyElementalStats.ResetStats();
        ennemyElementalStats.standardStats = Mathf.CeilToInt(subStandardPower);
        ennemyElementalStats.stats[elementType] = Mathf.CeilToInt(subElementalPower);

        // Set damages
        enemySlot.GetComponent<Weapons>().damage = Mathf.CeilToInt(subStandardPower * damageUpdate);
        enemySlot.GetComponent<Weapons>().elementalDamage = Mathf.CeilToInt(subElementalPower * damageUpdate);

    }


	// Update is called once per frame
	void Update () {
		// if ennemy is dead, generate a new ennemy
	}
}
