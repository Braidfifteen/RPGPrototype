using UnityEngine;

public class CharacterSpotScript : MonoBehaviour, ISelectable
{
    public CharacterInfo characterInfo;
    public SpriteRenderer spriteRenderer;
    public CharacterBattleSpotActivateDeactivateGameObject activateDeactivateGameObject;

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

    public void Set(Sprite s, CharacterInfo info)
    {
        spriteRenderer.sprite = s;
        characterInfo = info;
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
