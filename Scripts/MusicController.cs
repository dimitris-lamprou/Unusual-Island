using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MusicController : MonoBehaviour
{
    public TextMeshProUGUI button;
    public GameObject music1;
    public GameObject music2;
    public GameObject musicAction;
    public Transform arissasTransform;
    public Scrollbar mutantHealthbar;
    public void TurnOn_OffMusic()
    {
        if (button.text.Equals("Off"))
        {
            button.text = "On";
            music1.SetActive(false);
            music2.SetActive(false);
            musicAction.SetActive(false);
        }
        else
        {
            button.text = "Off";
            if (arissasTransform.position.x < 755 || arissasTransform.position.z < 840)
            {
                music1.SetActive(true);
            }
            else
            {
                if (mutantHealthbar.size == 0)
                {
                    music1.SetActive(true);
                }
                else
                {
                    musicAction.SetActive(true);
                }
            }
        }
    }
}
