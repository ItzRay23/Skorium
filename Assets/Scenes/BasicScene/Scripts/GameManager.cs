using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public GameObject ammoCounter;
    // public GameObject scoreCounter;
    // public GameObject upgradePanel;

    public void Start()
    {
        Player.ammoCount = 10;
        Player.damage = 5;
        updateUI();
    }

    public void changeAmmoCount(int value) 
    {
        Player.ammoCount += value;
    }

    public void changeScore(int value) 
    {
        Player.score += value;
    }

    public void updateUI()
    {
        Debug.Log("Ammo: " + Player.ammoCount.ToString());
        ammoCounter.GetComponent<TextMeshPro>().text = "Ammo: " + Player.ammoCount.ToString();
        
    }
}
