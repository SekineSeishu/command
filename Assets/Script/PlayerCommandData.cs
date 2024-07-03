using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObject/CreateCharacterData")]
public class PlayerCommandData : ScriptableObject
{
    public int _hp;
    public int _maxHp;
    public int _attackDamage;
    public int _defaultAttackDatamage;
    public int _sp;
    public int _maxSp;
    public int _skillCount;
    public bool _skillEffect;
    //public int _helse;

    public List<ItemData> _itemDatas;


    public void SetData()
    {
        _hp = _maxHp;
        _attackDamage = _defaultAttackDatamage;
        _sp = _maxSp;
        _skillCount = 0;
        _skillEffect = false;
    }

    public void Attack(Enemy enemy)
    {
        enemy.hitDamage(_attackDamage);
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
