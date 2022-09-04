using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
   [SerializeField] int MaxLife;

    GameData_SO PlayerLives;
    public bool DamageHit;

    private void Awake()
    {
        MaxLife = 100;
    }
    private void Start()
    {
        setLife(MaxLife);
        PlayerLives.Lives = MaxLife;
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
        PlayerLives.Lives -= damage;
        DamageHit = true;
    }
    public void Healing(int healValue)
    {
        PlayerLives.Lives += healValue;
    }
}
