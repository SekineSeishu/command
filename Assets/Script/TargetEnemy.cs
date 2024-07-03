using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetEnemy : MonoBehaviour
{
    public Enemy _enemy;
    private string _enemyName;
    [SerializeField] private TMP_Text _text;

    public void AddEnemy(Enemy newEnemy)
    {
        _enemy = newEnemy;
        _enemyName = newEnemy._name;
        _text.text = _enemyName;
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
