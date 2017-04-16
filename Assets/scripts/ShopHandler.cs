using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour {

    int nbHealthUpgrades;
    int nbStandardUpgrades;
    Dictionary<ElementalStats.Element, int> nbElementalUpgrades = new Dictionary<ElementalStats.Element, int>();
    int nbPotions;

    // Use this for initialization
    void Start () {
        nbElementalUpgrades[ElementalStats.Element.Fire] = 0;
        nbElementalUpgrades[ElementalStats.Element.Wind] = 0;
        nbElementalUpgrades[ElementalStats.Element.Ice] = 0;
        nbElementalUpgrades[ElementalStats.Element.Ground] = 0;
        nbHealthUpgrades = 0;
        nbStandardUpgrades = 0;
    }

    void UpdateHeroStats(GameObject hero)
    {
        ElementalStats heroStats = hero.GetComponent<ElementalStats>();
        PV heroPV = hero.GetComponent<PV>();
        Weapons heroWeapon = hero.GetComponent<Weapons>();

        float lifePower = heroPV.initialHP * (1f + (nbHealthUpgrades / 10f));


        float standardPower = heroStats.initialPower * (1f + (nbStandardUpgrades / 10f));
        int firePower = 1 + nbElementalUpgrades[ElementalStats.Element.Fire];
        int groundPower = 1 + nbElementalUpgrades[ElementalStats.Element.Ground];
        int icePower = 1 + nbElementalUpgrades[ElementalStats.Element.Ice];
        int windPower = 1 + nbElementalUpgrades[ElementalStats.Element.Wind];

        int standardAttack = Mathf.CeilToInt(standardPower);

        // Set life
        heroPV.SetPV(lifePower);

        // Set stats
        heroStats.standardPower = Mathf.CeilToInt(standardPower);
        heroStats.stats[ElementalStats.Element.Fire] = firePower;
        heroStats.stats[ElementalStats.Element.Ground] = groundPower;
        heroStats.stats[ElementalStats.Element.Ice] = icePower;
        heroStats.stats[ElementalStats.Element.Wind] = windPower;

        // Set damages
        heroWeapon.damage = Mathf.CeilToInt(standardPower * 2f);
        heroWeapon.elementalDamage = Mathf.CeilToInt(heroStats.stats[heroStats.selectedElement] * 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
