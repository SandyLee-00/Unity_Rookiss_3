using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpawningPool : MonoBehaviour
{
  [SerializeField]
  private int _monsterCount = 0;
  [SerializeField]
  private int _reserveCount = 0;
  [SerializeField]
  private int _keepMonsterCount = 0;
  [SerializeField]
  private Vector3 _spawnPos = new Vector3(0, 0, -38);
  [SerializeField]
  private float _spawnRadius = 15.0f;
  [SerializeField]
  private float _spawnTime = 5.0f;

  public void AddMonsterCount(int value) { _monsterCount += value; }
  public void SetKeepMonsterCount(int count) { _keepMonsterCount = count; }
  private void Start()
  {
    Managers.Game.OnSpawnEvent -= AddMonsterCount;
    Managers.Game.OnSpawnEvent += AddMonsterCount;
  }

  private void Update()
  {
    while (_reserveCount + _monsterCount < _keepMonsterCount)
    {
      StartCoroutine("ReserveSpawn");
    }
  }

  public IEnumerator ReserveSpawn()
  {
    _reserveCount++;
    yield return new WaitForSeconds(Random.Range(0, _spawnTime));
    GameObject obj = Managers.Game.Spawn(Define.WorldObject.Monster, "Knight");

    NavMeshAgent nma = obj.GetOrAddComponent<NavMeshAgent>();

    Vector3 randPos;
    while (true)
    {
      Vector3 randDir = Random.insideUnitSphere * Random.Range(0, _spawnRadius);
      randDir.y = 0;
      randPos = _spawnPos + randDir;

      NavMeshPath path = new NavMeshPath();
      if (nma.CalculatePath(randPos, path))
        break;
    }
    obj.transform.position = randPos;
    _reserveCount--;
  }
}
