using UnityEngine;

public class CharacterSpot : MonoBehaviour
{
    public CharacterInfo characterInfo;
    public SpriteRenderer spriteRenderer;

    private bool isEmpty = true;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public bool IsEmpty { get { return isEmpty; } }

    public void Reset()
    {
        transform.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        characterInfo = null;
        isEmpty = true;
        transform.gameObject.SetActive(false);
    }

    public void Set(Sprite s, CharacterInfo info)
    {
        spriteRenderer.sprite = s;
        characterInfo = info;
        transform.gameObject.SetActive(true);
    }
}
