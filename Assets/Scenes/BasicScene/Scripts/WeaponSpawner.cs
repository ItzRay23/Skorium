using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject targetWeapon;
    public GameObject spawner;

    public void spawnWeapon()
    {
        GameObject weapon = Instantiate(targetWeapon, spawner.transform.position, Quaternion.identity);
        weapon.transform.SetParent(spawner.transform);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        weapon.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.UpdateUI();
    }

    public void decreaseAmmo()
    {
        GameManager.changeAmmoCount(-1);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.UpdateUI();
    }

    public void increaseAmmo()
    {
        GameManager.changeAmmoCount(1);
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.UpdateUI();
    }
}
