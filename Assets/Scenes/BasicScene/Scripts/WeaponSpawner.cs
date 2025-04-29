using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject targetWeapon;

    public void spawnWeapon()
    {
        if (Player.ammoCount <= 0)
        {
            //Debug.Log("No ammo left!");
            return;
        }
        GameObject weapon = Instantiate(targetWeapon, transform.position, Quaternion.identity) as GameObject;
        weapon.transform.SetParent(transform);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        gameManager = FindAnyObjectByType<GameManager>();
        decreaseAmmo();
        gameManager.updateUI();
    }

    public void decreaseAmmo()
    {
        gameManager.changeAmmoCount(-1);
        gameManager.updateUI();
    }

    public void increaseAmmo()
    {
        gameManager.changeAmmoCount(1);
        gameManager.updateUI();
    }
}
