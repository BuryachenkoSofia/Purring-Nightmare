using Random = System.Random;
using UnityEngine;

public class KeySpawn : MonoBehaviour
{
  public GameObject keyObject;
  public GameObject tochka1, tochka2, tochka3, tochka4, tochka5, tochka6, tochka7, tochka8, tochka9, tochka10;
  public int keySpawnNumber;

  void Start()
  {
    Random rnd = new Random();
    keySpawnNumber = rnd.Next(1, 11);
    switch (keySpawnNumber)
    {
      case 1:
        Instantiate(keyObject, tochka1.transform.position, Quaternion.identity);
        break;
      case 2:
        Instantiate(keyObject, tochka2.transform.position, Quaternion.identity);
        break;
      case 3:
        Instantiate(keyObject, tochka3.transform.position, Quaternion.identity);
        break;
      case 4:
        Instantiate(keyObject, tochka4.transform.position, Quaternion.identity);
        break;
      case 5:
        Instantiate(keyObject, tochka5.transform.position, Quaternion.identity);
        break;
      case 6:
        Instantiate(keyObject, tochka6.transform.position, Quaternion.identity);
        break;
      case 7:
        Instantiate(keyObject, tochka7.transform.position, Quaternion.identity);
        break;
      case 8:
        Instantiate(keyObject, tochka8.transform.position, Quaternion.identity);
        break;
      case 9:
        Instantiate(keyObject, tochka9.transform.position, Quaternion.identity);
        break;
      case 10:
        Instantiate(keyObject, tochka10.transform.position, Quaternion.identity);
        break;
    }
  }
}
