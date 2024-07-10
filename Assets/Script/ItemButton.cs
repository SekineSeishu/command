using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class ItemButton : MonoBehaviour
{
    [SerializeField] private ItemData _item;
    private string _itemName;
    [SerializeField] private TMP_Text _nameText;

    public void Add(ItemData newItem)
    {
        _item = newItem;
        _itemName = newItem.name;
        _nameText.text = _itemName;
    }
    public void item()
    {
        PlayerManager.Instance.SelectItem(_itemName);
    }
}
