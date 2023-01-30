using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class Util
{
  public static T GetOrAddComponet<T>(GameObject go) where T : UnityEngine.Component
  {// obj에 컴포넌트 없으면 붙이고 컴포넌트 반환하기
    T component = go.GetComponent<T>();
    if (component == null)
      component = go.AddComponent<T>();
    return component;
  }

  public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
  {
    Transform transform = FindChild<Transform>(go, name, recursive);
    if (transform == null)
      return null;
    return transform.gameObject;
  }

  public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
  {
    if (go == null)
      return null;

    if (recursive == false)
    {
      for (int i = 0; i < go.transform.childCount; i++)
      {
        Transform transform = go.transform.GetChild(i);
        if (string.IsNullOrEmpty(name) || transform.name == name)
        {
          T component = transform.GetComponent<T>();
          if (component != null)
            return component;
        }

      }

    }
    else
    {
      foreach (T component in go.GetComponentsInChildren<T>())
      {
        if (string.IsNullOrEmpty(name) || component.name == name)
          return component;
      }
    }

    return null;
  }

}
