using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetButton : MonoBehaviour
{
    [SerializeField] EnemyData _enemy;
    private string _name;
    [SerializeField] private TMP_Text _nameText;

    public PlayerManager player;
    public void Add(EnemyData enemy)
    {
        _enemy = enemy;
        _name = enemy._name;
        _nameText.text = _name;
        player = GetComponentInParent<PlayerManager>();
    }

    public void Attack()
    {
        //PlayerManager PM = GetComponentInParent<PlayerManager>();
        player.SelectTarget(_name);
    }
}
