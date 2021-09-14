using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI waveText;
    private int score;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] GameObject gameOverPanel;
    private bool gameOver;

    private void Start()
    {
        gameOver = false;
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().RestartGame();
        score = 0;
        scoreText.text = score.ToString();
        gameOverPanel.SetActive(false);
    }
    public void AddScore(int value)
    {
        if (gameOver) return;
        score += value;
        scoreText.text = score.ToString();
    }

    public void NotifyNewWave(int waveNum)
    {
        StartCoroutine(DisplayWaveNumber(waveNum));
    }

    private IEnumerator DisplayWaveNumber(int waveNum)
    {
        waveText.text = $"Wave {waveNum}";
        waveText.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        waveText.gameObject.SetActive(false);

    }

    public void RestartGame()
    {
        gameOver = false;
        gameOverPanel.SetActive(false);
        GameObject.Find("SpawnManager").GetComponent<SpawnManager>().RestartGame();
        score = 0;
        scoreText.text = score.ToString();
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if(FindObjectOfType<PlayerController>() == null)
        {
            gameOver = true;
            gameOverPanel.SetActive(true);
            GameObject.Find("SpawnManager").GetComponent<SpawnManager>().GameOver();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
