using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Actions : MonoBehaviour {

    public int damageValue;
    public int potion;

    public int nbEnemies;
    public Text nbEnemiesText;

    public GameObject hero;
    public GameObject enemy;
    

    private bool damageMode;
    private bool enemyDeath;

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

    public void SetEnemyDeath(bool isEnemyDeath)
    {
        enemyDeath = isEnemyDeath;
    }

    public bool GetEnemyDeath()
    {
        return enemyDeath;
    }

    public void ChangeEnemy()
    {
        GetComponent<EnemyFactory>().GenerateEnemy();
    }

    // Use this for initialization
    void Start () {
        damageMode = false;
        enemyDeath = false;
        nbEnemies = 0;
        nbEnemiesText.text = "Kills : " + nbEnemies.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		if(damageMode)
        {
            enemy.GetComponent<PV>().RemovePV(hero.GetComponent<Weapons>().damage);

            if (enemy.GetComponent<PV>().value <= 0)
            {
                enemyDeath = true;
            }

            if(enemyDeath == true)
            {
                GetComponent<EnemyFactory>().GenerateEnemy();
                nbEnemies++;
                nbEnemiesText.text = "Kills : " + nbEnemies.ToString();
                enemyDeath = false;
            }
        }
	}
    
}
