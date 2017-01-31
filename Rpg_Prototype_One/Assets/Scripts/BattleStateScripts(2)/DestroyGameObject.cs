using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public void Destroy()
    {
        Destroy(transform.gameObject);
    }
}
