using UnityEngine;

[ExecuteAlways]
public class DoorPointer : MonoBehaviour
{
    private Transform player;
    private Camera camera;
    [SerializeField] private Transform iconPointer;

    private void Start()
    {
        camera = Camera.main;
        player = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
        Vector3 fromPlayerToDoor = transform.position - player.transform.position;
        Ray ray = new Ray(player.transform.position, fromPlayerToDoor);
        Debug.DrawRay(player.transform.position, fromPlayerToDoor);

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        int planeIndex = 0;
        float minDistance = Mathf.Infinity;
        for (int i = 0; i < 4; i++)
        {
            if (planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    planeIndex = i;
                }
            }
        }
        minDistance = Mathf.Clamp(minDistance, 0, fromPlayerToDoor.magnitude);
        Vector3 worldPosition = ray.GetPoint(minDistance);
        iconPointer.position = camera.WorldToScreenPoint(worldPosition);
        iconPointer.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(ray.direction.y, ray.direction.x) * Mathf.Rad2Deg-90f);
    }
}