using UnityEngine;

public class KillZone : MonoBehaviour
{
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Player has entered the kill zone!");
            Destroy(collision.gameObject);
            WeaponSpawner weaponSpawner = FindAnyObjectByType<WeaponSpawner>();
            GameManager.changeAmmoCount(-1);
            if (Player.ammoCount > 0)
            {
                weaponSpawner.spawnWeapon();
            }
        }
    }
}
