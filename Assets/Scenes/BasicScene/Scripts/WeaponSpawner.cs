using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    private GameManager gameManager;
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
