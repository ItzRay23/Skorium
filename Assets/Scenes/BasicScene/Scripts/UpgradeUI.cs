using System;
using TMPro;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    public GameObject dmgStat;
    public GameObject dmgUpgrade;
    public GameObject dmgCostText;
    public GameObject gainStat;
    public GameObject gainUpgrade;
    public GameObject gainCostText;
    public GameObject valueStat;
    public GameObject valueUpgrade;
    public GameObject valueCostText;
    public GameObject ammoStat;
    public GameObject ammoUpgrade;
    public GameObject ammoCostText;

    private int damageCost = 10;
    private int gainCost = 15;
    private int valueCost = 30;
    private int ammoCost = 15;

    private int damageLvl = 1;
    private int gainLvl = 1;
    private int valueLvl = 1;


    public void updateUI()
    {
        updateDamageUpgrade();
        updateGainUpgrade();
        updateValueUpgrade();
        updateAmmoUpgrade();
    }

    private void updateDamageUpgrade()
    {
        dmgStat.GetComponent<TextMeshProUGUI>().text = "Current Damage: " + Player.damage.ToString();
        dmgUpgrade.GetComponent<TextMeshProUGUI>().text = "+1 Damage";
        dmgCostText.GetComponent<TextMeshProUGUI>().text = "Cost: " + damageCost.ToString() + " Skor";
    }

    private void updateGainUpgrade()
    {
        gainStat.GetComponent<TextMeshProUGUI>().text = "Current Gain: +" + (Player.gain * 100).ToString() + "%";
        gainUpgrade.GetComponent<TextMeshProUGUI>().text = "+20% Skor Gain";
        gainCostText.GetComponent<TextMeshProUGUI>().text = "Cost: " + gainCost.ToString() + " Skor";
    }

    private void updateValueUpgrade()
    {
        valueStat.GetComponent<TextMeshProUGUI>().text = "Current Value: " + TargetStats.value.ToString();
        valueUpgrade.GetComponent<TextMeshProUGUI>().text = "+10% Value";
        valueCostText.GetComponent<TextMeshProUGUI>().text = "Cost: " + valueCost.ToString() + " Skor";
    }

    private void updateAmmoUpgrade()
    {
        ammoStat.GetComponent<TextMeshProUGUI>().text = "Current Ammo: " + Player.ammoCount.ToString();
        ammoUpgrade.GetComponent<TextMeshProUGUI>().text = "+10 Ammo";
        ammoCostText.GetComponent<TextMeshProUGUI>().text = "Cost: " + ammoCost.ToString() + " Skor";
    }

    public void upgradeDmg()
    {
        if (Player.score >= damageCost)
        {
            Player.score -= damageCost;
            Player.damage += 1;
            damageLvl++;
            damageCost += damageLvl + 2;
            
        }
    }

    public void upgradeGain()
    {
        if (Player.score >= gainCost)
        {
            Player.score -= gainCost;
            Player.gain += 0.2f;
            gainCost += (int)(gainLvl * Math.Floor(Mathf.Pow(1.4f * gainLvl, 1.2f)));
            gainLvl++;
        }
    }

    public void upgradeValue()
    {
        if (Player.score >= valueCost)
        {
            Player.score -= valueCost;
            TargetStats.value += (int)(TargetStats.value * 0.1f);
            valueCost += (int)(valueLvl * Math.Floor(Mathf.Pow(1.5f * valueLvl, 1.3f)));
            valueLvl++;
        }
    }

    public void buyAmmo()
    {
        if (Player.score >= ammoCost)
        {
            Player.score -= ammoCost;
            if (Player.ammoCount == 0)
            {
                Player.ammoCount += 10;
                WeaponSpawner weaponSpawner = FindAnyObjectByType<WeaponSpawner>();
                weaponSpawner.spawnWeapon();
            } else
            {
                Player.ammoCount += 10;
            }

            if (ammoCost < 50)
            {
                ammoCost += 2;
            }
        }
    }

    void Update()
    {
        updateUI();
    }
}
