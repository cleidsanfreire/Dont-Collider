using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public List<GameObject> prefabs;
    public float intervalObstacle = 1; // Intervalo de tempo para spawnar inimigos
    public float speedObstacle = 20; // velocidade do obstacle

    [HideInInspector]
    public int score;

    [HideInInspector]
    private bool isGameOver = false;

    [HideInInspector]
    public float gameWidth = 8.6f;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameActive() {
        return !isGameOver;
    }

    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("Game Over!... You Score is " + score);
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        String sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        Debug.Log("Reload scene please. wait!!!");
    }
}
