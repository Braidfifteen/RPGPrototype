using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject player;
    private float mapWidth = 16.0f;
    private float maxX = 14.3f;
    private float minX = 1.6f;
    private float maxY = -1.2f;
    private float minY = -14.8f;

    private void Start()
    {
       // calcMinMax();
    }

    private void Update()
    {
        Vector3 newPos = new Vector3(player.transform.position.x,
                player.transform.position.y, transform.position.z);

      //  newPos = Camera.main.ScreenToWorldPoint(newPos);

        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        newPos.y = Mathf.Clamp(newPos.y, minY, maxY);

        transform.position = newPos;
    }

    private void calcMinMax()
    {
        float height = Camera.main.orthographicSize * 2.0f;
        print(height);
        float width = height * Screen.width / Screen.height;
        maxX = (mapWidth - width) / 2.0f;
        minX = -maxX;
        print(minX);
    }
}
