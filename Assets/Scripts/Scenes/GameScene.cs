using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
  protected override void Init()
  {
    base.Init();
    SceneType = Define.Scene.Game;

    Dictionary<int, Data.Stat> dict = Managers.Data.StatDict;
    gameObject.GetOrAddComponent<CursorController>();

    GameObject player = Managers.Game.Spawn(Define.WorldObject.Player, "UnityChan");
    Camera.main.gameObject.GetOrAddComponent<CameraController>().SetPlayer(player);

    GameObject go = new GameObject { name = "SpawningPool" };
    SpawningPool pool = go.GetOrAddComponent<SpawningPool>();
    pool.SetKeepMonsterCount(3);
  }
  public override void Clear()
  {

  }
}
