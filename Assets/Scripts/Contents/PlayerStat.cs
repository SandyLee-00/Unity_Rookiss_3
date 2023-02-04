using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : Stat
{
  [SerializeField]
  private int _exp;
  private int _maxExp;
  [SerializeField]
  private int _gold;

  // test 
  public int Exp
  {
    get { return _exp; }
    set
    {
      _exp = value;
      int level = Level;
      while (true)
      {
        Data.Stat stat;
        if (Managers.Data.StatDict.TryGetValue(level + 1, out stat) == false)
          break;
        if (_exp < stat.totalExp)
          break;
        level++;
      }
      if (level != Level)
      {
        Level = level;
        SetStat(Level);
      }
    }
  }
  public int Gold { get { return _gold; } set { _gold = value; } }
  public int MaxExp{ get { return _maxExp; } }


  private void Start()
  {
    _level = 1;
    _exp = 0;
    _defense = 1;
    _moveSpeed = 5.0f;
    _gold = 0;
    SetStat(_level);
  }

  public void SetStat(int level)
  {
    Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
    Data.Stat stat = dict[level];

    _hp = stat.maxhp;
    _maxHp = stat.maxhp;
    _attack = stat.attack;
    _maxExp = stat.totalExp;
  }
  protected override void OnDead(Stat attacker)
  {
    Start();
  }
}
