using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
  [SerializeField]
  int _exp;
  [SerializeField]
  int _gold;

  public int Exp { get { return _exp; } set { _exp = value; } }
  public int Gold { get { return _gold; } set { _gold = value; } }

  private void Start()
  {
    _level = 1;
    _hp = 200;
    _maxHp = 200;
    _attack = 25;
    _defense = 5;
    _moveSpeed = 5.0f;
    _exp = 0;
    _gold = 0;
  }
  protected override void OnDead()
  {

  }
}
