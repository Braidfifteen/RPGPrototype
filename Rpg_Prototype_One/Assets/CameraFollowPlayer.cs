using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    public void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x,
                player.transform.position.y, transform.position.z);
        transform.position = newPos;
    }
}
