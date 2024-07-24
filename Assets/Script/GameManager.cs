using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public List<PlayerManager> nowPlayerList;
    public List<EnemyManager> nowEnemyList;
    [SerializeField] private Transform AllPlayer;
    [SerializeField] private Transform AllEnemy;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void nowCharacterSerch()
    {
        nowPlayerList.Clear();
        nowEnemyList.Clear();
        foreach (Transform child in AllPlayer)
        {
            PlayerManager player = child.GetComponent<PlayerManager>();
            if (player != null)
            {
                nowPlayerList.Add(player);
            }
        }
        foreach (Transform child in AllEnemy)
        {
            EnemyManager enemy = child.GetComponent<EnemyManager>();
            if (enemy != null)
            {
                nowEnemyList.Add(enemy);
            }
        }
    }
}
