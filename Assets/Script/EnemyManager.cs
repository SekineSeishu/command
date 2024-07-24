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

    //ダメージを受ける
    public void HitDamage(int damage)
    {
        Debug.Log(_enemyData._name + ":" + damage + "受けた");
        _enemyData._hp -= damage; ;
        if (_enemyData._hp <= 0)
        {
            KnockDown();
        }
    }
    //倒されたとき
    public void KnockDown()
    {
        var enemy = gameObject.GetComponent<EnemyManager>();
        GameManager.Instance.nowEnemyList.Remove(enemy);
        Destroy(gameObject);
        Debug.Log("勝利！");
    }
    //プレイヤーを攻撃（対象はランダム）
    public IEnumerator EnemyTurn()
    {
        Debug.Log("敵の攻撃！");
        _enemyData.Attack(GameManager.Instance.nowPlayerList[GetIndex()]._playerData);
        yield return new WaitForSeconds(_attackTime);
    }

    //攻撃対象を選ぶ
    private int GetIndex()
    {
        int index = Random.Range(0, GameManager.Instance.nowPlayerList.Count);
        Debug.Log(index);
        return index;
    }
}
