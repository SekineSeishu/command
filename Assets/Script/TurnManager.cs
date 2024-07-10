using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static TurnManager Instance;
    public PlayerManager Player;
    public EnemyManager Enemy;

    private void Awake()
    {
        Instance = this;
    }
    public enum TurnState
    {
        PlayerTurn,
        CommandEffect,
        EnemyTurn
    }

    public TurnState currentState;
    public bool CommpleteTurn;
    // Start is called before the first frame update
    void Start()
    {
        CommpleteTurn = false;
        currentState = TurnState.PlayerTurn;
        StartCoroutine(Turn());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Turn()
    {
        while (true)
        {
            switch (currentState)
            {
                case TurnState.PlayerTurn:
                    Debug.Log("プレイヤーのターン");
                    foreach (var player in GameManager.Instance.nowPlayerList)
                    {
                        yield return StartCoroutine(player.PlayerTurnStart());
                    }
                    currentState = TurnState.CommandEffect;
                    break;

                case TurnState.CommandEffect:
                    Debug.Log("コマンド効果");
                    yield return StartCoroutine(Player.CommandEffect());
                    currentState = TurnState.EnemyTurn;
                    break;
                case TurnState.EnemyTurn:
                    Debug.Log("敵のターン");
                    foreach (var enemy in GameManager.Instance.nowEnemyList)
                    {
                        yield return StartCoroutine(enemy.EnemyTurn());
                    }
                    currentState = TurnState.PlayerTurn;
                    break;
            }
        }
    }
}
