using StarterAssets;
using UnityEngine;
using Cinemachine;
using TMPro;

public class Victory : MonoBehaviour
{
    public GameObject heather;
    public GameObject victoryText;
    public GameObject victoryCanvas;
    public Animator animator;
    public CinemachineVirtualCamera virtualCamera;
    StarterAssetsInputs starterAssetsInputs;
    ThirdPersonController thirdPersonController;
    public GameObject backGroundMusic;
    public GameObject backGroundMusicWon;
    public GameObject objectiveCanvas;
    public Attack attackScript;
    public TextMeshProUGUI musicOnOff;
    public GameObject arissasLightning;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            thirdPersonController = GetComponent<ThirdPersonController>();

            objectiveCanvas.SetActive(false);
            backGroundMusic.SetActive(false);
            if (musicOnOff.text.Equals("Off"))
            {
                backGroundMusicWon.SetActive(true);
            }
            victoryCanvas.SetActive(true);
            heather.SetActive(false);
            victoryText.SetActive(true);
            starterAssetsInputs.enabled = false;
            thirdPersonController.enabled = false;
            animator.SetBool("Won", true);
            virtualCamera.Priority = 1000;
            attackScript.enabled = false;
            animator.SetBool("doesArissaAttack", false);
            arissasLightning.SetActive(false);
        }
    }
}
