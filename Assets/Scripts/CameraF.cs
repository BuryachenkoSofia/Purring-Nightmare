using UnityEngine;

public class CameraF : MonoBehaviour
{
  public Transform player;
  private Vector3 playerVector;
  public int speed;

  public Vector2 DefaultResolution = new Vector2(1920, 960); // разрешение по умолчанию
  [Range(0f, 1f)] public float WidthOrHeight = 0; // изменения в ширину или высоту (переключатель в диапазоне от 0 до 1)
  private Camera Camera; // объект камеры 
  private float initialCameraSize; // исходный размер камеры
  private float needAspect; // нужный аспект

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;

    Camera = GetComponent<Camera>(); // получаем объект камеры 
    initialCameraSize = Camera.orthographicSize; // получаем исходный размер камеры
    needAspect = DefaultResolution.x / DefaultResolution.y; // задаем (уснаем) нужный аспект
  }
  private void FixedUpdate()
  {
    playerVector = player.position;
    playerVector.z = -10;
    transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);

    float constWidthSize = initialCameraSize * (needAspect / Camera.aspect); // узнаем постоянный размер ширины
    Camera.orthographicSize = Mathf.Lerp(constWidthSize, initialCameraSize, WidthOrHeight); // задаем параметры камеры
  }
}