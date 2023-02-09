using StarterAssets;
using UnityEngine;
using Cinemachine;

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
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            starterAssetsInputs = GetComponent<StarterAssetsInputs>();
            thirdPersonController = GetComponent<ThirdPersonController>();

            objectiveCanvas.SetActive(false);
            backGroundMusic.SetActive(false);
            backGroundMusicWon.SetActive(true);
            victoryCanvas.SetActive(true);
            heather.SetActive(false);
            victoryText.SetActive(true);
            starterAssetsInputs.enabled = false;
            thirdPersonController.enabled = false;
            animator.SetBool("Won", true);
            virtualCamera.Priority = 1000;
        }
    }
}
