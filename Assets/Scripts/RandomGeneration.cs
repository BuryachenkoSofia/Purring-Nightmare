using UnityEngine;
using Random = System.Random;

public class RandomGeneration : MonoBehaviour
{
  public GameObject kitekat, whiskas, purinaOne;
  public int trueOrFalse, difficultyLevel;

  void Start()
  {
    Random rnd = new Random();

    difficultyLevel = PlayerPrefs.GetInt("difficultyLevel");
    trueOrFalse = rnd.Next(0, 3);
    Debug.Log(difficultyLevel);
    switch (difficultyLevel)
    {
      case 1:
        if (trueOrFalse == 1)
        {
          Instantiate(kitekat, transform.position, Quaternion.identity);
        }
        if (trueOrFalse == 2)
        {
          Instantiate(kitekat, transform.position, Quaternion.identity);
          Instantiate(kitekat, transform.position, Quaternion.identity);
        }
        break;

      case 2:
        if (trueOrFalse == 1)
        {
          Instantiate(whiskas, transform.position, Quaternion.identity);
        }
        if (trueOrFalse == 2)
        {
          Instantiate(whiskas, transform.position, Quaternion.identity);
          Instantiate(whiskas, transform.position, Quaternion.identity);
        }
        break;

      case 3:
        if (trueOrFalse == 1)
        {
          Instantiate(purinaOne, transform.position, Quaternion.identity);
        }
        if (trueOrFalse == 2)
        {
          Instantiate(purinaOne, transform.position, Quaternion.identity);
          Instantiate(purinaOne, transform.position, Quaternion.identity);
        }
        break;
    }
  }
}
