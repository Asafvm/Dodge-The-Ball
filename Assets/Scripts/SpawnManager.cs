using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount = 0;
    public int lastWave = 0;
    [SerializeField] GameObject enemtToSpawn;
    [SerializeField] GameObject[] powerups;
    [SerializeField] GameObject[] powerupSpawnLocations;
    private bool gameOver = false;

    public void StartWave(int enemies)
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().NotifyNewWave(lastWave++);
        for (int i = 0; i < enemies; i++)
        {
            GameObject e = Instantiate(enemtToSpawn, GenerateRanfomPoint(), Quaternion.identity);
            e.transform.parent = GameObject.Find("Enemies").transform;
        }
        foreach (GameObject pos in powerupSpawnLocations)
        {
            if (pos.gameObject.transform.childCount > 0)
                Destroy(pos.gameObject.transform.GetChild(0).gameObject);
            GameObject g = Instantiate(powerups[Random.Range(0, powerups.Length)], pos.transform.position, Quaternion.identity);
            g.gameObject.transform.parent = pos.transform;
        }
            
            
    }

    internal void RestartGame()
    {
      enemyCount = 0;
        lastWave = 0;
        gameOver = false;
    }

    private Vector3 GenerateRanfomPoint()
    {
        return new Vector3(Random.Range(-9, 9), transform.position.y, Random.Range(-9, 9));
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0 && !gameOver)
        {
            StartWave(lastWave);
        }
            
        
    }

    internal void GameOver()
    {
        gameOver = true;
    }
}
