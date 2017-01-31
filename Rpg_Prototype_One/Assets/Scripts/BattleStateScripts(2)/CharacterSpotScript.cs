using UnityEngine;

public class CharacterSpotScript : MonoBehaviour, ISelectable
{
    public CharacterInfo characterInfo;
    public SpriteRenderer spriteRenderer;
    public CharacterBattleSpotActivateDeactivateGameObject activateDeactivateGameObject;
    public int allSpotsIndex;
    public int enemyOrPlayerIndex;
    public bool IsPlayerPartySpot;

    private bool isSelected = false;
    private bool isEmpty = true;

    public bool IsEmpty { get { return isEmpty; } }

    public void Reset()
    {
        spriteRenderer.sprite = null;
        characterInfo = null;
        isEmpty = true;
        activateDeactivateGameObject.DeactivateBattleSpotGameObject();
    }

    public void Set(Sprite s, CharacterInfo info, int allSpotsIndex)
    {
        this.allSpotsIndex = allSpotsIndex;
        spriteRenderer.sprite = s;
        characterInfo = info;
        characterInfo.SetCurrentSpot(this);
        activateDeactivateGameObject.ActivateBattleSpotGameObject();
    }

    public void Set(GameObject obj, int allSpotsIndex)
    {
        Instantiate(obj);
        obj.transform.position = transform.position;
        obj.transform.rotation = transform.rotation;

        obj.transform.localScale = new Vector3(2.0f, 2.0f, 0.0f);
        this.allSpotsIndex = allSpotsIndex;
        spriteRenderer.sprite = obj.GetComponent<SpriteRenderer>().sprite;
        characterInfo = obj.GetComponent<CharacterInfo>();
        characterInfo.SetCurrentSpot(this);
        activateDeactivateGameObject.ActivateBattleSpotGameObject();
        
    }

    public void OnSelect()
    {
        isSelected = true;
        print(characterInfo.GetName());
    }

    public CharacterInfo GetCharacterInfo()
    {
        return characterInfo;
    }
}
