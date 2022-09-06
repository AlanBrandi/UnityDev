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
    }

    int DeadEnemyCount = 0;

    public void SetDeadCount()
    {
        DeadEnemyCount++;
    }
    public int GetDeadCount()
    {
        return DeadEnemyCount;
    }
}
