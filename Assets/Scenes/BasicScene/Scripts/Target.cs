using System;
using TMPro;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int health;
    public int value;
    [SerializeField]
    private TextMeshPro HPText;

    public void takeDamage(int damage)
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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("I was collided with!");
            takeDamage(Player.damage);
            Debug.Log("Damage Taken: " + Player.damage);
            updateTarget();
        }
    }

    public void Start()
    {
        updateTarget();
    }
}
