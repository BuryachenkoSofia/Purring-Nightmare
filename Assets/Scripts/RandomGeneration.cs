using UnityEngine;
using Random = System.Random;

public class RandomGeneration : MonoBehaviour
{
  public GameObject[] food = new GameObject[3];
  public GameObject heart;
  private int rand, difficultyLevel;

  void Start()
  {
    Random rnd = new Random();

    difficultyLevel = PlayerPrefs.GetInt("difficultyLevel");
    rand = rnd.Next(0, 3);
    if (rand == 0)
    {
      Instantiate(heart, transform.position, Quaternion.identity);
    }
    for (int i = 0; i < rand; ++i)
    {
      Instantiate(food[difficultyLevel - 1], transform.position, Quaternion.identity);
    }
  }
}