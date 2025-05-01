using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject ammoCounter;
    public GameObject scoreCounter;
    public GameObject totalScoreCounter;
    public GameObject waveCounter;
    public GameObject debugUI;
    public GameObject MainMenu;
    public GameObject about;
    public GameObject GroundGroup;
    public GameObject PlayerMovement;
    public GameObject PlayerLook;
    public void Start()
    {
        Player.ammoCount = 15;
        Player.damage = 5;
        Player.score = 0;
        Player.totalScore = 0;
        Player.wave = 1;
        TargetStats.health = 5;
        TargetStats.value = 10;
        debugUI.SetActive(false);
        GroundGroup.SetActive(false);
        PlayerMovement.SetActive(false);
        PlayerLook.SetActive(false);
        UpdateUI();
    }

    public static void changeAmmoCount(int value)
    {
        Player.ammoCount += value;
    }

    public static void setDamage(int value)
    {
        Player.damage = value;
    }

    public static void changeSkor(int value)
    {
        Player.score += value;
    }

    public void toggleDebug()
    {
        if (debugUI.activeSelf)
        {
            debugUI.SetActive(false);
        }
        else
        {
            debugUI.SetActive(true);
        }
    }

    public void toggleAbout()
    {
        if (about.activeSelf)
        {
            about.SetActive(false);
        }
        else
        {
            about.SetActive(true);
        }
    }

    public void Play()
    {
        MainMenu.SetActive(false);
        GroundGroup.SetActive(true);
        PlayerMovement.SetActive(true);
        PlayerLook.SetActive(true);
    }

    public void SpawnWave()
    {
        if (FindObjectsByType<Target>(FindObjectsSortMode.None).Length == 0)
        {
            TargetSpawner targetSpawner = FindAnyObjectByType<TargetSpawner>();
            Player.wave++;
            Target.changeHealth((int)Math.Pow(Player.wave * 1.4f, 1.3f));
            targetSpawner.SpawnTargets();
        } else
        {
            Debug.Log("Cannot spawn wave until this wave has been cleared!");
        }
    }

    public void UpdateUI()
    {
        ammoCounter.GetComponent<TextMeshPro>().text = "Ammo: " + Player.ammoCount.ToString();
        scoreCounter.GetComponent<TextMeshProUGUI>().text = "Skor: " + Player.score.ToString();
        totalScoreCounter.GetComponent<TextMeshProUGUI>().text = "Total Skor: " + Player.totalScore.ToString();
        waveCounter.GetComponent<TextMeshProUGUI>().text = "Wave " + Player.wave.ToString();
    }

    public void Quit()
    {
        Application.Quit();
    }

    void Update()
    {
        UpdateUI();
    }
}
