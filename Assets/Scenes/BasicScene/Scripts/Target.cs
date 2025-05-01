using System;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int health = TargetStats.health;
    private int value = TargetStats.value;
    [SerializeField]
    private TextMeshPro HPText;
    public ParticleSystem explosionPrefab;

    public static void changeHealth(int value)
    {
        TargetStats.health += value;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            int valueGain = (int)(value * (Player.gain + 1f));
            Player.score += valueGain;
            Player.totalScore += valueGain;
            Debug.Log("Target Destroyed with Damage Taken: " + Player.damage.ToString() + " and Value given: " + valueGain.ToString());
            Destroy(gameObject);
            GameManager gameManager = FindAnyObjectByType<GameManager>();
            gameManager.UpdateUI();
        }
    }

    public void OnDestroy()
    {
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        explosionPrefab.Play();
    }

    public void setTarget(int health, int value)
    {
        this.health = health;
        TargetStats.value = value;
    }

    public void updateTarget()
    {
        HPText.text = health.ToString();
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("I was collided with!");
            takeDamage(Player.damage);
            //Debug.Log("Damage Taken: " + Player.damage);
            updateTarget();
        }
    }

    public void Start()
    {
        updateTarget();
    }
}
