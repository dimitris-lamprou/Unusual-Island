using UnityEngine;
using TMPro;

public class MusicController : MonoBehaviour
{
    public TextMeshProUGUI button;
    public GameObject music1;
    public GameObject music2;
    public void TurnOn_OffMusic()
    {
        if (button.text.Equals("Off"))
        {
            button.text = "On";
            music1.SetActive(false);
            music2.SetActive(false);
        }
        else
        {
            button.text = "Off";
            music1.SetActive(true);
            music2.SetActive(true);
        }
    }
}
