using Random = System.Random;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
  public GameObject keyObject;
  public GameObject[] keyPoints = new GameObject[10];
  private int keySpawnNumber;

  void Start()
  {
    Random rnd = new Random();
    keySpawnNumber = rnd.Next(1, 11);
    Instantiate(keyObject, keyPoints[keySpawnNumber - 1].transform.position, Quaternion.identity);
  }
}