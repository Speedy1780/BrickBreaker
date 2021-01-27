using UnityEngine;
using UnityEngine.UI;

public class SensitivityController : MonoBehaviour
{
    [SerializeField] private Slider sensitivity;

    private void Awake() => sensitivity.value = PlayerPrefs.GetFloat(PlayerPrefsKeys.TapSensitivity, 8);
    public void ChaneSensitivity(float value) => PlayerPrefs.SetFloat(PlayerPrefsKeys.TapSensitivity, value);
}
