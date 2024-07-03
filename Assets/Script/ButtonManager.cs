using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public ItemData _item;
    private string _itemName;
    [SerializeField] private TMP_Text _text;

    public void Add(ItemData newItem)
    {
        _item = newItem;
        _itemName = newItem.name;
        _text.text = _itemName;
    }
    public void item()
    {
        PlayerManager.Instance.SelectItem(_itemName);
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
