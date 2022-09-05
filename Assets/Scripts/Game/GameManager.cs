using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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


    public void ChanceScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

}
