using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBasics", menuName = "EnemyBasics")]
public class EnemyScriptableObject : ScriptableObject
{
    public int Life = 100;
    public float Speed = 10;
    public float StoppingDistance = 20;
    public float RetreatDistance = 10;
    public int HitDamage = 50;
    public Material FlashMaterial;
    public GameObject DeathEffect;
    public GameObject Projectile;
}
