using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
   
    public List<GameObject> enemyList = new List<GameObject>();
    [SerializeField] private GameManager gameManager;
    void Start()
    {
  
        FindEnemies();
    }
    private void Update()
    {
        if(enemyList.Count == 0) 
        {
            gameManager.Win();
        }
    }
    void FindEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        enemyList.AddRange(enemies);

        Debug.Log("Numero di enemy trovati: " + enemyList.Count);
    }
}