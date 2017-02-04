using UnityEngine;
using UnityEngine.UI;

public class BattleDamageNumbersManager : MonoBehaviour
{
    public Text DamageNumbersText;
    public RectTransform DamageNumbersRect;
    public RectTransform CanvasRect;
    public Camera battleCam;

    private bool isUpdating = false;
    private float timer = 0.0f;
    private float timeAmount = 2.0f;

    public void SetDamageNumbersText(int damageAmount)
    {
        DamageNumbersText.text = damageAmount.ToString();
    }

    public void SetDamageNumbersTextActive(bool isActive)
    {
        isUpdating = isActive;
        transform.gameObject.SetActive(isActive);
    }

    public void SetUpDamageNumbers(int damageAmount, Vector3 loc)
    {
        SetDamageNumbersText(damageAmount);
        SetDamageNumbersPosition(loc);
        SetDamageNumbersTextActive(true);
    }

    public void SetDamageNumbersPosition(Vector3 loc)
    {
        Vector3 viewportPoint = battleCam.WorldToViewportPoint(loc);
        Vector3 worldObjectScreenPos = new Vector3
            (((viewportPoint.x * CanvasRect.sizeDelta.x) - (CanvasRect.sizeDelta.x * 0.5f)),
            ((viewportPoint.y * CanvasRect.sizeDelta.y) - (CanvasRect.sizeDelta.y * 0.5f)), 0.0f);
        DamageNumbersRect.anchoredPosition = worldObjectScreenPos;
    }

    public void Updating()
    {
        if (isUpdating)
        {
            timer += Time.deltaTime;
            if (timer >= timeAmount)
            {
                SetDamageNumbersTextActive(false);
                timer = 0.0f;
            }
        }
    }

    public bool IsUpdating()
    {
        return isUpdating;
    }
}
