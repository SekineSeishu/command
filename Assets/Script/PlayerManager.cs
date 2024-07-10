using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public float _effectTime = 2f;
    public string _selectCommandName;
    public bool _commandSelect;
    private string _selectItemName;
    private string _targetName;
    public PlayerData _playerData;

    [SerializeField] private GameManager _gm;
    [SerializeField] private GameObject _commandMenuUI;
    [SerializeField] private GameObject _selectCommandUI;
    [SerializeField] private GameObject _contract;
    [SerializeField] private GameObject _targetSlotPrefab;
    [SerializeField] private GameObject _itemSlotPrefab;
    [SerializeField] private TMP_Text _hpText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _commandSelect = false;
        _playerData.SetData();
    }

    // Update is called once per frame
    void Update()
    {
        _hpText.text = "HP:" + _playerData._hp;
    }

    public IEnumerator PlayerTurnStart()
    {
        _selectCommandName = null;
        if (_playerData._skillEffect)
        {
            if (_playerData._skillCount <= 0)
            {
                _playerData._skillEffect = false;
            }
        }
        _commandMenuUI.SetActive(true);

        while (!_commandSelect)
        {
            if (_commandSelect)
            {
                _commandSelect = false;
                yield return new WaitForSeconds(2); ;
            }
            yield return null;
        }
    }

    public IEnumerator CommandEffect()
    {
        _effectTime = 0;
        if (_selectCommandName == "Attack")
        {
            EnemyManager TargetEnemy = _gm.nowEnemyList.Find(enemy => enemy._enemyData._name == _targetName);
            _playerData.Attack(TargetEnemy);
            Debug.Log("プレイヤーの攻撃！");
        }
        if (_selectCommandName == "Skill")
        {
            _playerData.Skill();
            Debug.Log("プレイヤーはスキルを使った！");
        }
        if (_selectCommandName == "Item")
        {
            _playerData.Item(_selectItemName);
            _selectItemName = null;
            Debug.Log("プレイヤーはアイテムを使った！");
        }
        _selectCommandName = null;
        _commandSelect = false;
        ClearSlot();
        yield return new WaitForSeconds(2);
    }

    public void AttackButton()
    {
        Debug.Log("ボタンを押しました");
        SetTargetUI();
        _commandMenuUI.SetActive(false);
        _selectCommandUI.SetActive(true);
    }

    public void SelectTarget(string targetName)
    {
        _commandSelect = true;
        _selectCommandName = "Attack";
        _targetName = targetName;
        _selectCommandUI.SetActive(false);
    }

    public void SkillButton()
    {
        Debug.Log("ボタンを押しました");
        if (_playerData._sp > 0)
        {
            _commandSelect = true;
            _selectCommandName = "Skill";
            _commandMenuUI.SetActive(false);
        }
        Debug.Log("spがありません");
    }

    public void ItemButton()
    {
        Debug.Log("ボタンを押しました");
        SetItemUI();
        _commandMenuUI.SetActive(false);
        _selectCommandUI.SetActive(true);
    }
    public void SelectItem(string itemName)
    {
        _commandSelect = true;
        _selectCommandName = "Item";
        _selectItemName = itemName;
        _selectCommandUI.SetActive(false);
    }

    public void Back()
    {
        ClearSlot();
        _commandSelect = false;
        _selectCommandName = null;
        _commandMenuUI.SetActive(true);
        _selectCommandUI.SetActive(false);
    }

    public void SetTargetUI()
    {
        foreach (var enemy in _gm.nowEnemyList)
        {
            Debug.Log(enemy._enemyData._name);
            GameObject targetSlot = Instantiate(_targetSlotPrefab, _contract.transform);
            targetSlot.GetComponent<TargetButton>().Add(enemy._enemyData);
        }
    }
    public void SetItemUI()
    {
        foreach(var item in _playerData._itemDatas)
        {
            Debug.Log(item._name);
            GameObject itemSlot = Instantiate(_itemSlotPrefab, _contract.transform);
            itemSlot.GetComponent<ItemButton>().Add(item);
        }
    }

    public void ClearSlot()
    {
        foreach(Transform slot in _contract.transform)
        {
            GameObject.Destroy(slot.gameObject);
        }
    }
}
