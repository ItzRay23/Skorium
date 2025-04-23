using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField]
    private static int ammoCount;

    private void Start()
    {
        ammoCount = 5;
    }

    public void decreaseAmmo()
    {
        ammoCount--;
    }

    public void increaseAmmo()
    {
        ammoCount++;
    }

    public static int getAmmoCount()
    {
        return ammoCount;
    }

    private void Update()
    {
        
    }
}
