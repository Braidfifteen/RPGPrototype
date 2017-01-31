using UnityEngine;

public class CharacterSpotScript : MonoBehaviour, ISelectable
{
    public CharacterInfo characterInfo;
    public SpriteRenderer spriteRenderer;
    public CharacterBattleSpotActivateDeactivateGameObject activateDeactivateGameObject;
    public int allSpotsIndex;
    public int enemyOrPlayerIndex;
    public bool IsPlayerPartySpot;

    public GameObject characterPrefab;

    private bool isSelected = false;
    private bool isEmpty = true;

    public bool IsEmpty { get { return isEmpty; } }

    public void Reset()
    {
        spriteRenderer.sprite = null;
        characterInfo = null;
        isEmpty = true;
        //characterPrefab.GetComponent<DestroyGameObject>().Destroy();
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
        characterPrefab = Instantiate(obj);
        characterPrefab.transform.position = transform.position;
        characterPrefab.transform.rotation = transform.rotation;
        characterPrefab.transform.parent = transform;
        characterPrefab.SetActive(true);
        
        this.allSpotsIndex = allSpotsIndex;
        characterInfo = characterPrefab.GetComponent<CharacterInfo>();
        characterInfo.SetCurrentSpot(this);
        activateDeactivateGameObject.SetDestroyObjectObserver(characterPrefab.GetComponent<DestroyGameObject>());
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
