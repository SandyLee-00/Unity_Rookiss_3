using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
    }

    private void OnTriggerEnter(Collider other) {
        Managers.Sound.Play(Define.Sound.Effect, "UnityChan/univ0001");
        Managers.Sound.Play(Define.Sound.Effect, "UnityChan/univ0002");

    }
}
