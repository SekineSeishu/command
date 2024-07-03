using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string _name;
    public int _hp;
    public int _attackDamage = 10;
    private float _attackTime;

    [SerializeField] private TMP_Text HpText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpText.text = "HP:" + _hp;
    }

    public IEnumerator EnemyTurn()
    {
        Debug.Log("ìGÇÃçUåÇÅI");
        GameManager.Instance.nowPlayerList[0].hitDamage(_attackDamage);
        //TurnManager.Instance.currentState = TurnManager.TurnState.PlayerTurn;
        yield return new WaitForSeconds(_attackTime);
    }
    public void Attack()
    {

    }

    public void hitDamage(int Damage)
    {
        _hp -= Damage;
        if (_hp <= 0)
        {
            Debug.Log("èüóòÅI");
        }
    }
}
