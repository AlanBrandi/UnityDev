using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData_New", menuName = "GameData")]
public class GameData_SO : ScriptableObject
{
    public int Score;
    public int Lives;
    public void OnAfterDeserialize()
    {
        Lives = 100;
        Score = 0;
    }

    public void OnBeforeSerialize()
    {
    }
}
