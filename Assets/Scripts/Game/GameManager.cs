using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject gameManager = new GameObject("GameManager");
                gameManager.AddComponent<GameManager>();
            }
            return instance;
        }
    }
    #endregion

    [HideInInspector] public GameData_SO playerLives;

    public int Score = 0;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        playerLives = Resources.Load("PlayerLives") as GameData_SO;
        DontDestroyOnLoad(gameObject);
        Score = playerLives.Score;
    }
    int DeadEnemyCount = 0;


    public void DeadEnemyCounterToZero()
    {
        DeadEnemyCount = 0;
        Score = 0;
    }

    public void SetDeadCount()
    {
        DeadEnemyCount++;
        Score = CalculateScore();
    }

    public int GetDeadCount()
    {
        return DeadEnemyCount;
    }

    public int CalculateScore()
    {
        return DeadEnemyCount * 100;
    }
}
