using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("LifeMetris - READ ONLY")]
    [SerializeField] int CurrentLife;
    [SerializeField] int MaxLife;
    
    bool DamageHit;
    GameData_SO PlayerLives;

    [Header("Fx")]
    public GameObject PlayerHit;
    public GameObject PlayerDeath;

    [Header("Components")]
    public GameObject Bengala;

    private void Awake()
    {
        MaxLife = 100;
    }
    private void Start()
    {
        PlayerLives = GameManager.Instance.playerLives;
        setLife(MaxLife);
        PlayerLives.Lives = MaxLife;
    }

    private void Update()
    {
        CurrentLife = PlayerLives.Lives;

        if(PlayerLives.Lives <= 0)
        {
            Instantiate(PlayerDeath, GameObject.Find("Player").transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    //----------------------Métodos----------------------------

    //Encapsulamento
    public void setLife(int life)
    {
      PlayerLives.Lives = life;
    }
    public int GetLife()
    {
       return PlayerLives.Lives;
    }
    //----------------------------
    public void Damage(int damage)
    {
        if(DamageHit == false)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, .7f);
            Bengala.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .7f);
            PlayerLives.Lives -= damage;
            DamageHit = true;
            Instantiate(PlayerHit, GameObject.Find("Player").transform.position, Quaternion.identity);
            Invoke("InvincibilityOff", 1f);
        }
    }
    public void Healing(int healValue)
    {
        PlayerLives.Lives += healValue;
    }

    //-----------------------------
    public void InvincibilityOff()
    {
        DamageHit = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        Bengala.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
    }
}
