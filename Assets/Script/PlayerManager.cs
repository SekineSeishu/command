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

    [SerializeField] private PlayerCommandData CommandData;
    [SerializeField] private GameObject CommandMenuUI;
    [SerializeField] private GameObject ItemCommandUI;
    [SerializeField] private GameObject Contract;
    [SerializeField] private GameObject ItemSlotPrefab;
    [SerializeField] private TMP_Text HpText;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        _commandSelect = false;
        CommandData.SetData();
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "HP:" + CommandData._hp;
    }

    public IEnumerator PlayerTurnStart()
    {
        _selectCommandName = null;
        if (CommandData._skillEffect)
        {
            if (CommandData._skillCount <= 0)
            {
                CommandData._skillEffect = false;
            }
        }
        CommandMenuUI.SetActive(true);

        while (!_commandSelect)
        {
            if (_commandSelect)
            {
                _commandSelect = false;
                //TurnManager.Instance.currentState = TurnManager.TurnState.CommandEffect;
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
            CommandData.Attack(GameManager.Instance.nowEnemyList[0]);
            Debug.Log("プレイヤーの攻撃！");
        }
        if (_selectCommandName == "Skill")
        {
            CommandData.Skill();
            Debug.Log("プレイヤーはスキルを使った！");
        }
        if (_selectCommandName == "Item")
        {
            CommandData.Item(_selectItemName);
            _selectItemName = null;
            Debug.Log("プレイヤーはアイテムを使った！");
        }
        _selectCommandName = null;
        _commandSelect = false;
        ClearSlot();
        //TurnManager.Instance.currentState = TurnManager.TurnState.EnemyTurn;
        yield return new WaitForSeconds(2);
    }

    public void AttackButton()
    {
        Debug.Log("ボタンを押しました");
        _commandSelect = true;
        _selectCommandName = "Attack";
        PlayerTurnStart();
        CommandMenuUI.SetActive(false);
    }

    public void SkillButton()
    {
        Debug.Log("ボタンを押しました");
        if (CommandData._sp > 0)
        {
            _commandSelect = true;
            _selectCommandName = "Skill";
            CommandMenuUI.SetActive(false);
        }
        Debug.Log("spがありません");
    }

    public void ItemButton()
    {
        Debug.Log("ボタンを押しました");
        SetItemUI();
        CommandMenuUI.SetActive(false);
        ItemCommandUI.SetActive(true);
    }
    public void SelectItem(string itemName)
    {
        _commandSelect = true;
        _selectCommandName = "Item";
        _selectItemName = itemName;
        ItemCommandUI.SetActive(false);
    }

    public void Back()
    {
        ClearSlot();
        _commandSelect = false;
        _selectCommandName = null;
        CommandMenuUI.SetActive(true);
        ItemCommandUI.SetActive(false);
    }
    public void hitDamage(int Damage)
    {
        if (CommandData._skillEffect)
        {
            if (Probability(80))
            {
                Debug.Log("回避した");
            }
            CommandData._skillCount--;
        }
        else
        {
            CommandData._hp -= Damage;

        }
        if (CommandData._hp <= 0)
        {
            Debug.Log("敗北！");
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

    public void SetItemUI()
    {
        foreach(var item in CommandData._itemDatas)
        {
            Debug.Log(item._name);
            GameObject itemSlot = Instantiate(ItemSlotPrefab, Contract.transform);
            itemSlot.GetComponent<ButtonManager>().Add(item);
        }
    }

    public void ClearSlot()
    {
        foreach(Transform slot in Contract.transform)
        {
            GameObject.Destroy(slot.gameObject);
        }
    }
}
