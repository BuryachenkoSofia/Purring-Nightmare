using UnityEngine;

public class CameraF : MonoBehaviour
{
  public Transform player;
  private Vector3 playerVector;
  public int speed;

  public Vector2 DefaultResolution = new Vector2(1920, 960); 
  [Range(0f, 1f)] public float WidthOrHeight = 0; 
  private Camera Camera; 
  private float initialCameraSize; 
  private float needAspect; 

  private void Start()
  {
    player = GameObject.FindGameObjectWithTag("Player").transform;

    Camera = GetComponent<Camera>(); 
    initialCameraSize = Camera.orthographicSize;
    needAspect = DefaultResolution.x / DefaultResolution.y;
  }
  private void FixedUpdate()
  {
    playerVector = player.position;
    playerVector.z = -10;
    transform.position = Vector3.Lerp(transform.position, playerVector, speed * Time.deltaTime);

    float constWidthSize = initialCameraSize * (needAspect / Camera.aspect);
    Camera.orthographicSize = Mathf.Lerp(constWidthSize, initialCameraSize, WidthOrHeight);
  }
}