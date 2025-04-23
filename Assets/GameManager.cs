using UnityEngine;
using TMPro;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    private int damage;
    private int score;

    public GameObject ammoCounter;
    public GameObject scoreCounter;
    public GameObject upgradePanel;
    
    public void updateUI()
    {
        ammoCounter.GetComponent<TextMeshProUGUI>().text = "Ammo: " + WeaponSpawner.getAmmoCount();
    }

    private void Update()
    {
        updateUI();
    }
}
