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
    private bool isGameOver;

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
        nbKilledEnemies = 0;
        nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
        hero.GetComponent<PV>().SetPV(hero.GetComponent<PV>().initialHP);
        GetComponent<EnemyFactory>().Restart();
        GetComponent<CanvasActions>().SetPauseOff();
        GetComponent<CanvasActions>().HidePopUpLose();
    }

    // Use this for initialization
    void Start ()
    {
        damageMode = false;
        isGameOver = false;
        nbKilledEnemies = 0;
        nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (!isGameOver)
        {
            if (damageMode)
            {
                enemy.GetComponent<PV>().RemovePV(hero.GetComponent<Weapons>().damage);

                if (enemy.GetComponent<PV>().value <= 0)
                {
                    GetComponent<EnemyFactory>().GenerateEnemy();
                    nbKilledEnemies++;
                    nbEnemiesText.text = "Kills : " + nbKilledEnemies.ToString();
                }
            }

            hero.GetComponent<PV>().RemovePV(enemy.GetComponent<Weapons>().damage / 100f);
            hero.GetComponent<PV>().RemovePV(enemy.GetComponent<Weapons>().elementalDamage / 100f);

            if (hero.GetComponent<PV>().value <= 0)
            {
                isGameOver = true;
                GetComponent<CanvasActions>().DisplayPopUpLose();                
            }
        }
    }
    
}
