using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    #region Singleton
    public static UiManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    Slider HealthSlider;
    GameObject Player;
    GameObject DeathPanel;
    GameObject HealthBar;
    GameObject FinalPanel;

    string CurrentScene;
    public TMP_Text TxtDeathEnemy;
    public TMP_Text TxtScore;
    public TMP_Text Timer;

    public TMP_Text ScoreTxt;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HealthSlider = GetComponentInChildren<Slider>();
        DeathPanel = GameObject.Find("DeathPanel");
        HealthBar = GameObject.Find("HealthBar");
        FinalPanel = GameObject.Find("FinalPanel");


        FinalPanel.SetActive(false);
        DeathPanel.SetActive(false);
        HealthBar.SetActive(true);
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void Update()
    {
        HealthSlider.value = Player.gameObject.GetComponentInParent<HealthSystem>().GetLife();
        ScoreTxt.text = GameManager.Instance.Score.ToString();
        if (Player.gameObject.GetComponentInParent<HealthSystem>().GetLife() <= 0)
        {
            HealthBar.SetActive(false);
            DeathPanel.SetActive(true);
        }
    }

    //--------------Método-----------------

    public void ChanceScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    
    public void TryAgain()
    {
        HealthBar.SetActive(true);
        AudioListener.pause = false;
        Time.timeScale = 1;
        TurnAllOn();
        GameManager.Instance.DeadEnemyCounterToZero();
        SceneManager.LoadScene(CurrentScene);
    }

    public void WonGame()
    {
        DisableAll();
        TxtDeathEnemy.text = GameManager.Instance.GetDeadCount().ToString();
        TxtScore.text = GameManager.Instance.CalculateScore().ToString();
        FinalPanel.SetActive(true);
    }

    void  DisableAll()
    {
        HealthBar.SetActive(false);
        DeathPanel.SetActive(false);
        FinalPanel.SetActive(false);
    }
    void TurnAllOn()
    {
        HealthBar.SetActive(true);
        DeathPanel.SetActive(true);
        FinalPanel.SetActive(true);
    }
}
