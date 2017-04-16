using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public int damageValue;
    public int potion;
    
    public int nbKilledEnemies;
    public Text nbEnemiesText;

    public GameObject hero;
    public GameObject enemy;

    private bool damageMode;

    public void AddPV()
    {
        hero.GetComponent<PV>().AddPV(potion);
    }

    public void EnableDamage()
    {
        damageMode = true;
    }

    public void DisableDamage()
    {
        damageMode = false;
    }


    public void ChangeEnemy()
    {
        GetComponent<EnemyFactory>().GenerateEnemy();
    }

    // Use this for initialization
    void Start () {
        damageMode = false;
        nbKilledEnemies = 0;
        nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
    }

    void ResolveAttack(GameObject attacker, GameObject defender)
    {
        int standardDamages = attacker.GetComponent<Weapons>().damage;
        int elementalDamages = attacker.GetComponent<Weapons>().elementalDamage;

        int standardDefense = defender.GetComponent<ElementalStats>().standardPower;
        int elementalDefense = defender.GetComponent<ElementalStats>().stats[attacker.GetComponent<ElementalStats>().selectedElement];

        if (standardDefense >= standardDamages)
            standardDamages = 0;

        if (elementalDefense >= elementalDamages)
            elementalDamages = 0;

        defender.GetComponent<PV>().RemovePV(standardDamages / 100f);
        defender.GetComponent<PV>().RemovePV(elementalDamages / 100f);

    }
	
	// Update is called once per frame
	void Update () {
		if(damageMode)
        {
            ResolveAttack(hero, enemy);

            //enemy.GetComponent<PV>().RemovePV(hero.GetComponent<Weapons>().damage);
        }

        if (enemy.GetComponent<PV>().value <= 0)
        {
            GetComponent<EnemyFactory>().GenerateEnemy();
            nbKilledEnemies++;
            nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
        }

        ResolveAttack(enemy, hero);
    }
    
}
