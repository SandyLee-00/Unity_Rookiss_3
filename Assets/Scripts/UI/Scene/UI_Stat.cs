using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stat : UI_Scene
{
    public enum GameObjects
    {
        UI_Stat_HP_Bar,
        UI_Stat_EXP_Bar
    }
    public enum Texts
    {
        UI_Stat_Level_Text,
    }
    PlayerStat _stat;
    private GameObject Player;

    public override void Init()
    {
        base.Init();
        Bind<GameObject>(typeof(GameObjects));
        Bind<Text>(typeof(Texts));
        Player = Managers.Game.GetPlayer();
        _stat = Player.GetComponent<PlayerStat>();
    }

    private void Update()
    {
        float HPRatio = _stat.Hp / (float)_stat.MaxHp;
        GetObject((int)GameObjects.UI_Stat_HP_Bar).GetComponent<Slider>().value = HPRatio;
        float ExpRatio = (_stat.Exp - (float)_stat.MaxExp) / ((float)_stat.NextMaxExp - (float)_stat.MaxExp) ;
        GetObject((int)GameObjects.UI_Stat_EXP_Bar).GetComponent<Slider>().value = ExpRatio;
        Debug.Log($"{(_stat.Exp - (float)_stat.MaxExp)} {((float)_stat.NextMaxExp - (float)_stat.MaxExp)}");
        GetText((int)Texts.UI_Stat_Level_Text).GetComponent<Text>().text = $"LV {_stat.Level}";
    }


}
