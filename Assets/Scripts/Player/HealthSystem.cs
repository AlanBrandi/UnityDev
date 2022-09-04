using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
   [SerializeField] int CurrentLife;
    int MaxLife;
    GameData_SO PlayerLives;
    public bool DamageHit;

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
            PlayerLives.Lives -= damage;
            DamageHit = true;
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
    }
}
