using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] 
    Define.CameraMode _mode = Define.CameraMode.QuarterView;
    [SerializeField] 
    Vector3 _delta = new Vector3(0.0f, 6.0f, -5.0f);
    [SerializeField] 
    GameObject _player = null;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(_mode== Define.CameraMode.QuarterView)
        {
            transform.position = _player.transform.position + _delta;
            transform.LookAt(_player.transform);
        }
    }
    public void SetQuarterView(Vector3 delta)
    {
        _mode= Define.CameraMode.QuarterView;
        _delta = delta;
    }

}
