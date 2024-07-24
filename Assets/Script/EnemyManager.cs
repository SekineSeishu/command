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

    //�_���[�W���󂯂�
    public void HitDamage(int damage)
    {
        Debug.Log(_enemyData._name + ":" + damage + "�󂯂�");
        _enemyData._hp -= damage; ;
        if (_enemyData._hp <= 0)
        {
            KnockDown();
        }
    }
    //�|���ꂽ�Ƃ�
    public void KnockDown()
    {
        var enemy = gameObject.GetComponent<EnemyManager>();
        GameManager.Instance.nowEnemyList.Remove(enemy);
        Destroy(gameObject);
        Debug.Log("�����I");
    }
    //�v���C���[���U���i�Ώۂ̓����_���j
    public IEnumerator EnemyTurn()
    {
        Debug.Log("�G�̍U���I");
        _enemyData.Attack(GameManager.Instance.nowPlayerList[GetIndex()]._playerData);
        yield return new WaitForSeconds(_attackTime);
    }

    //�U���Ώۂ�I��
    private int GetIndex()
    {
        int index = Random.Range(0, GameManager.Instance.nowPlayerList.Count);
        Debug.Log(index);
        return index;
    }
}
