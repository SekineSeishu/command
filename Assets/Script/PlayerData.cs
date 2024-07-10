using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/CreateCharacterData")]
public class PlayerData : ScriptableObject
{
    public int _hp;
    public int _maxHp;
    public int _attackDamage;
    public int _defaultAttackDatamage;
    public int _sp;
    public int _maxSp;
    public int _skillCount;
    public bool _skillEffect;

    public List<ItemData> _itemDatas;

    public void SetData()
    {
        _hp = _maxHp;
        _attackDamage = _defaultAttackDatamage;
        _sp = _maxSp;
        _skillCount = 0;
        _skillEffect = false;
    }

    public void Attack(EnemyManager enemy)
    {
        enemy._enemyData.hitDamage(_attackDamage);
    }

    public void Skill()
    {
        _sp -= 10;
        _skillCount = 3;
        _skillEffect = true;
    }

    public void Item(string itemName)
    {
        ItemData macchingItem = _itemDatas.Find(ItemData => ItemData._name == itemName);
        Debug.Log("hp");
        _hp += macchingItem._helse;
        if (_hp > _maxHp)
        {
            _hp = _maxHp;
        }
    }

    public void hitDamage(int Damage)
    {
        if (_skillEffect)
        {
            if (Probability(80))
            {
                Debug.Log("‰ñ”ð‚µ‚½");
            }
            _skillCount--;
        }
        else
        {
           _hp -= Damage;

        }
        if (_hp <= 0)
        {
            Debug.Log("”s–kI");
        }
    }

    public static bool Probability(float fpercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if (fProbabilityRate == 100.0f && fProbabilityRate == fpercent)
        {
            return true;
        }
        else if (fProbabilityRate < fpercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
