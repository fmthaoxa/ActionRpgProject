using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;

    private PlayerStats thePlayerStats;

    public int expToGive;
    public string enemyQuestName;
    private QuestManager theQM;


    // Use this for initialization
    void Start()
    {
        currentHealth = maxHealth;
        theQM = FindObjectOfType<QuestManager>();
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }


    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            theQM.enemyKilled = enemyQuestName;
            Destroy(gameObject);
            thePlayerStats.AddExeperience(expToGive);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        currentHealth -= damageToGive;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}

