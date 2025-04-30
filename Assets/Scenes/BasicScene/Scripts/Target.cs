using System;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int health = TargetStats.health;
    private int value = TargetStats.value;
    [SerializeField]
    private TextMeshPro HPText;

    public static void changeHealth(int value)
    {
        TargetStats.health += value;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnDestroy()
    {
        int valueGain = (int)(value * (Player.gain + 1f));
        Player.score += valueGain;
        Player.totalScore += valueGain;
        Debug.Log("Target Destroyed with Damage Taken: " + Player.damage.ToString());
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.UpdateUI();
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
