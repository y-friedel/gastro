using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {
    
    public int potion;
    
    public int nbKilledEnemies;
    public Text nbEnemiesText;

    public GameObject hero;
    public GameObject enemy;

    private bool damageMode;
    private bool isGameOver;

    public void AddPV()
    {
        if (hero.GetComponent<Inventory>().GetPotion() != 0)
        {
            hero.GetComponent<PV>().AddPV(potion);
            hero.GetComponent<Inventory>().UsePotion();
        }
    }

    public void EnableDamage()
    {
        damageMode = true;
    }

    public void DisableDamage()
    {
        damageMode = false;
    }

    public void EnableGameOver()
    {
        isGameOver = true;
    }

    public void DisableGameOver()
    {
        isGameOver = false;
    }

    public void ChangeEnemy()
    {
        GetComponent<EnemyFactory>().GenerateEnemy();
    }

    public void Restart()
    {
        damageMode = false;
        isGameOver = false;
        hero.GetComponent<PV>().SetPV(hero.GetComponent<PV>().initialHP);
        GetComponent<EnemyFactory>().Restart();
        GetComponent<CanvasActions>().SetPauseOff();
        GetComponent<CanvasActions>().HidePopUpLose();
        hero.GetComponent<Inventory>().Restart();
        nbKilledEnemies = 0;
        nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
    }

    // Use this for initialization
    void Start ()
    {
        damageMode = false;
        isGameOver = false;
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
        if (!isGameOver)
        {
            if (damageMode)
            {
                ResolveAttack(hero, enemy);
            }

            if (enemy.GetComponent<PV>().value <= 0)
            {
                GetComponent<EnemyFactory>().GenerateEnemy();
                nbKilledEnemies++;
                nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
            }

            ResolveAttack(enemy, hero);

            if (hero.GetComponent<PV>().value <= 0)
            {
                isGameOver = true;
                GetComponent<CanvasActions>().DisplayPopUpLose();                
            }
        }
        
    }
    
}
