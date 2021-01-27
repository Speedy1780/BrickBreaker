using UnityEngine;
using UnityEngine.UI;

public class MovementButtonController : MonoBehaviour
{
    [SerializeField] private int movementType;
    [SerializeField] private Button button;

    private void Awake() => button.interactable = PlayerPrefs.GetInt(PlayerPrefsKeys.MovementType, 0) != movementType;

    public void ChangeMovementType()
    {
        PlayerPrefs.SetInt(PlayerPrefsKeys.MovementType, movementType);
        button.interactable = false;
    }
}
