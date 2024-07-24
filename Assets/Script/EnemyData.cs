using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObject/CreateEnemyData")]
public class EnemyData : ScriptableObject
{
    public string _name;
    public int _hp;
    public int _maxHp;
    public int _attackDamage;
    public int _defaultAttackDatamage;

    public void SetData()
    {
        _hp = _maxHp;
        _attackDamage = _defaultAttackDatamage;
    }
    public void Attack(PlayerData player)
    {
        player.hitDamage(_attackDamage);
    } 
}
