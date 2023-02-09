using UnityEngine;
using TMPro;

public class PlayerSettings : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    private void Awake()
    {
        dropdown.value = QualitySettings.GetQualityLevel();
    }
    public void ChangeGraphics(int choice)
    {
        QualitySettings.SetQualityLevel(choice);
    }
}
