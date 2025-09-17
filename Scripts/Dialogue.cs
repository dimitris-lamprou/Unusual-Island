using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public GameObject oldManVoice1;
    public GameObject oldManVoice2;
    public GameObject arissaVoice;
    public GameObject canvasForSubs;
    public GameObject OldMan;
    public NPCMotion oldMan;
    public Animator oldManAnimator;
    public Animator arissaAnimator;
    public CinemachineVirtualCamera oldManVirtualCamera;
    public CinemachineVirtualCamera heatherVirtualCamera;
    public ThirdPersonController arissaThirdPersonController;
    public StarterAssetsInputs arissaStarterAssetsInputs;
    public BoxCollider oldManBoxCollider;
    public Pause pause;
    public PlayerInput arissaPlayerInput;
    public TextMeshProUGUI subtitles;    
    public TextMeshProUGUI objective;
    public GameObject arissasLightning;
    public Attack attackScript;
    private Quaternion originalOldManRotation;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Old Man")) 
        {
            originalOldManRotation = oldMan.transform.rotation;
            oldMan.transform.rotation = oldMan.transform.rotation * other.transform.rotation;
            canvasForSubs.SetActive(true);
            arissaPlayerInput.enabled = false;
            arissaAnimator.SetBool("isInDialogue", true);
            pause.enabled = false;
            arissasLightning.SetActive(false);
            attackScript.enabled = false;
            arissaAnimator.SetBool("doesArissaAttack", false);
            arissaStarterAssetsInputs.jump = false;
            arissaStarterAssetsInputs.sprint = false;
            oldManVirtualCamera.Priority = 1000;
            oldManAnimator.SetBool("isArissaClose", true);
            oldMan.enabled = false;
            oldManVoice1.SetActive(true);
            Invoke("ArissaVoice", 15.274f);
            Invoke("OldManVoice2", 18.513f);
            Invoke("HeatherView", 35);
            Invoke("EndOfDialogue", 39.941f);
        }
    }
    public void OldManVoice2()
    {
        arissaAnimator.SetBool("isTalking", false);
        oldManVoice2.SetActive(true);
        subtitles.text = "-Old Man:\n\nhmm Interesting you are here for the heather of eternity i see. " +
            "Well I can't actually see but i can smell. The heather of eternity is located on the top of the mountain Dwarf.";
    }
    public void ArissaVoice()
    {
        arissaVoice.SetActive(true);
        arissaAnimator.SetBool("isTalking", true);
        subtitles.text = "-Arissa:\n\nI am searching for a unique herb";
    }
    public void EndOfDialogue()
    {
        pause.enabled = true;
        arissaAnimator.SetBool("isInDialogue", false);
        oldManAnimator.SetBool("isArissaClose", false);
        oldMan.enabled = true;
        oldManVirtualCamera.Priority = 0;
        heatherVirtualCamera.Priority = 0;
        arissaThirdPersonController.enabled = true;
        arissaStarterAssetsInputs.enabled = true;
        arissaAnimator.enabled = true;
        oldManBoxCollider.enabled = false;
        arissaPlayerInput.enabled = true;
        canvasForSubs.SetActive(false);
        objective.text = "Objective\n   Find the Heather of Eternity";
        oldMan.transform.rotation = originalOldManRotation;
        attackScript.enabled = true;
    }
    public void HeatherView()
    {
        heatherVirtualCamera.Priority = 2000;
    }
}
