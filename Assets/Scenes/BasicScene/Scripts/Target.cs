using System;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public int value;
    [SerializeField]
    private TextMeshPro HPText;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //public void OnDestroy()
    //{
    //    Player.score += value;
    //    GameManager gameManager = FindAnyObjectByType<GameManager>();
    //    gameManager.updateUI();
    //}

    public void setTarget(int health, int value)
    {
        this.health = health;
        this.value = value;
    }

    public void updateTarget()
    {
        HPText.text = health.ToString();
    }

    public void Start()
    {
        updateTarget();
    }
}
