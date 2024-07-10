using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public EnemyData _enemyData;
    private float _attackTime;

    [SerializeField] private TMP_Text HpText;

    // Start is called before the first frame update
    void Start()
    {
        _enemyData.SetData();
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "HP:" + _enemyData._hp;
    }

    public IEnumerator EnemyTurn()
    {
        Debug.Log("ìGÇÃçUåÇÅI");
        _enemyData.Attack(GameManager.Instance.nowPlayerList[GetIndex()]._playerData);
        yield return new WaitForSeconds(_attackTime);
    }

    private int GetIndex()
    {
        int index = Random.Range(0, GameManager.Instance.nowPlayerList.Count);
        Debug.Log(index);
        return index;
    }
}
