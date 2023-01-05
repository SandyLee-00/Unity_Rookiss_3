using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
  protected override void Init()
  {
    base.Init();
    SceneType = Define.Scene.Game;

    Managers.UI.ShowSceneUI<UI_Inven>();

    //test
    for (int i = 0; i < 1; i++)
      Managers.Resource.Instantiate("UnityChan");
  }

  public override void Clear()
  {

  }
}
