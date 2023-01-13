using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
  PlayerStat _stat;
  Vector3 _destPos;
  void Start()
  {
    _stat = gameObject.GetComponent<PlayerStat>();
    Managers.Input.MouseAction -= OnMouseClicked;
    Managers.Input.MouseAction += OnMouseClicked;

  }

  public enum PlayerState
  {
    Idle,
    Moving,
    Die,
  }
  PlayerState _state = PlayerState.Idle;

  private void UpdateMoving()
  {
    Vector3 dir = _destPos - transform.position;
    if (dir.magnitude < 0.1f)
    {
      _state = PlayerState.Idle;
    }
    else
    {
      NavMeshAgent nma = gameObject.GetOrAddComponet<NavMeshAgent>();
      float moveDist = Mathf.Clamp(_stat.MoveSpeed * Time.deltaTime, 0, dir.magnitude);
      nma.Move(dir.normalized * moveDist);

      if (Physics.Raycast(transform.position + Vector3.up * 0.5f, dir, 1.0f, LayerMask.GetMask("Block")))
      {
        _state = PlayerState.Idle;
        return;
      }

      transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime);
    }

    Animator anim = GetComponent<Animator>();
    anim.SetFloat("wait_run_ratio", 1);
    anim.Play("WAIT_RUN");
  }

  private void UpdateIdle()
  {
    Animator anim = GetComponent<Animator>();
    anim.SetFloat("wait_run_ratio", 0);
    anim.Play("WAIT_RUN");
  }

  private void UpdateDie()
  {

  }


  void Update()
  {
    switch (_state)
    {
      case PlayerState.Idle:
        UpdateIdle();
        break;
      case PlayerState.Moving:
        UpdateMoving();
        break;
      case PlayerState.Die:
        UpdateDie();
        break;
    }
  }

  void OnMouseClicked(Define.MouseEvent evt)
  {
    if (_state == PlayerState.Die)
    {
      return;
    }

    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Wall")))
    {
      _destPos = hit.point;
      _state = PlayerState.Moving;
    }
  }
}
