using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour, IUpdatable
{
    public GameObject player;
    public Camera cam;

    private float mapWidth = 16.0f;
    private float maxX = 14.4f;
    private float minX = 1.6f;
    private float maxY = -1.2f;
    private float minY = -14.8f;

    public void OnUpdate()
    {
        Vector3 newPos = new Vector3(player.transform.position.x,
                player.transform.position.y, cam.transform.position.z);


        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        cam.transform.position = newPos;
    }

}
