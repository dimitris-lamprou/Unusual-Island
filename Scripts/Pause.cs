using StarterAssets;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class Pause : MonoBehaviour
{
    public ThirdPersonController thirdPersonController;
    public StarterAssetsInputs starterAssetsInputs;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject canvas;
    public GameObject healthbar;
    public Animator animator;
    public Attack attackScript;
    public GameObject victoryCanvas;
    public GameObject arissasLightning;

    public NavMeshAgent mutantAgent;
    public Animator mutantAnimator;
    public GameObject mutantFootStepsSound;
    public MutantBehavior mutantBehaviorScript;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.SetActive(true);
            Cursor.visible = true;
            thirdPersonController.enabled = false;
            starterAssetsInputs.cursorInputForLook = false;
            starterAssetsInputs.cursorLocked = false;
            animator.SetBool("doesArissaAttack", false);
            animator.enabled = false;
            virtualCamera.Priority = 100;
            healthbar.SetActive(false);
            attackScript.enabled = false;
            victoryCanvas.SetActive(false);
            arissasLightning.SetActive(false);

            mutantAgent.enabled = false;
            mutantAnimator.enabled = false;
            mutantFootStepsSound.SetActive(false);
            mutantBehaviorScript.enabled = false;
        }
    }
    public void CancelJumpAndEnableCursorLock()
    {
        starterAssetsInputs.jump = false;
        starterAssetsInputs.cursorLocked = true;
        starterAssetsInputs.cursorInputForLook = true;
        Cursor.visible = false;
        animator.SetBool("Won", false);
    }
}
