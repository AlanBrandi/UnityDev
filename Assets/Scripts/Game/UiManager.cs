using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HealthSlider = GetComponentInChildren<Slider>();
        DeathPanel = GameObject.Find("DeathPanel");
        HealthBar = GameObject.Find("HealthBar");
        DeathPanel.SetActive(false);
        HealthBar.SetActive(true);
    }

    private void Update()
    {
        HealthSlider.value = Player.gameObject.GetComponentInParent<HealthSystem>().GetLife();
        if (Player.gameObject.GetComponentInParent<HealthSystem>().GetLife() <= 0)
        {
            HealthBar.SetActive(false);
            DeathPanel.SetActive(true);
        }
    }
}
