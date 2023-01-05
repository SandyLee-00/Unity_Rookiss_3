// using System.Collections;
// using System;
// using System.Collections.Generic;
// using UnityEngine;

// [Serializable]
// public class Stat
// {
//   public int level;
//   public int hp;
//   public int attack;
// }

// [Serializable]
// public class StatData : ILoader<int, Stat>
// {
//   public List<Stat> stats = new List<Stat>();

//   public Dictionary<int, Stat> MakeDict()
//   {
//     Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
//     foreach (Stat stat in data.stats)
//       StatDict.Add(stat.level, stat);
//   }
// }

// public interface ILoader<Key, Value>
// {
//   Dictionary<Key, Value> MakeDict();
// }
// public class DataManager
// {
//   public Dictionary<int, Stat> StatDict { get; private set; } = new Dictionary<int, Stat>();

//   public void Init()
//   {
//     TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/StatData");
//     StatData data = JsonUtility.FromJson<StatData>(textAsset.text);

//   }
// }
