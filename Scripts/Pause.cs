using StarterAssets;
using Cinemachine;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public ThirdPersonController thirdPersonController;
    public StarterAssetsInputs starterAssetsInputs;
    public CinemachineVirtualCamera virtualCamera;
    public GameObject canvas;
    public Animator animator;
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            canvas.SetActive(true);
            Cursor.visible = true;
            thirdPersonController.enabled = false;
            starterAssetsInputs.cursorInputForLook = false;
            starterAssetsInputs.cursorLocked = false;
            animator.enabled = false;
            virtualCamera.Priority = 100;
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
