using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
  public static Managers s_instance;
  public static Managers Instance { get { Init(); return s_instance; } }

  #region Contents
  private GameManagerEx _game = new GameManagerEx();

  public static GameManagerEx Game { get { return Instance._game; } }
  #endregion
  #region Core
  private DataManager _data = new DataManager();
  private InputManager _input = new InputManager();
  private PoolManager _pool = new PoolManager();
  private ResourceManager _resource = new ResourceManager();
  private SceneManagerEx _scene = new SceneManagerEx();
  private SoundManager _sound = new SoundManager();
  private UIManager _ui = new UIManager();

  public static DataManager Data { get { return Instance._data; } }
  public static InputManager Input { get { return Instance._input; } }
  public static PoolManager Pool { get { return Instance._pool; } }
  public static ResourceManager Resource { get { return Instance._resource; } }
  public static SceneManagerEx Scene { get { return Instance._scene; } }
  public static SoundManager Sound { get { return Instance._sound; } }
  public static UIManager UI { get { return Instance._ui; } }
  #endregion
  public void Start()
  {
    Init();
  }
  public void Update()
  {
    _input.OnUpdate();
  }
  public static void Init()
  {
    if (s_instance == null)
    {
      GameObject go = GameObject.Find("@Managers");
      if (go == null)
      {
        go = new GameObject { name = "@Managers" };
        go.AddComponent<Managers>();
      }
      DontDestroyOnLoad(go);
      s_instance = go.GetComponent<Managers>();

      s_instance._data.Init();
      s_instance._pool.Init();
      s_instance._sound.Init();
    }
  }
  public static void Clear()
  {
    Input.Clear();
    Sound.Clear();
    UI.Clear();
    Scene.Clear();

    Pool.Clear();
  }
}
