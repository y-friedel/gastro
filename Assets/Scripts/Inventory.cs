using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public int goldInit;
    public int potionInit;

    public Text potionText;
    public Text goldText;
    private int gold;
    private int potion;

    public int GetPotion()
    {
        return potion;
    }

    public void AddPotion(int nbpot)
    {
        potion += nbpot;
        ShowPotionText();
    }

    public void AddPotion()
    {
        potion++;
        ShowPotionText();
    }

    public void UsePotion()
    {
        potion--;
        ShowPotionText();
    }

    public void ShowPotionText()
    {
        potionText.text = "Potions : " + potion.ToString();
    }

    public int GetGold()
    {
        return gold;
    }

    public void AddGold(int nbgold)
    {
        gold += nbgold;
        ShowGoldText();
    }

    public void UseGold(int nbgold)
    {
        gold -= nbgold;
        ShowGoldText();
    }

    public void Restart()
    {
        potion = potionInit;
        gold = goldInit;
        ShowGoldText();
        ShowPotionText();
    }

    public void ShowGoldText()
    {
        goldText.text = "Gold : " + gold.ToString();
    }

    // Use this for initialization
    void Start () {
        Restart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
