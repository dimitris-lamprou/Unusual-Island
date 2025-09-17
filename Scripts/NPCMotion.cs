using UnityEngine;

public class NPCMotion : MonoBehaviour
{
    CharacterController characterController;
    public float speed = 0.25f;
    static float gravity = -9.81f;
    // Start is called before the first frame update

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        characterController.Move(transform.forward * speed * Time.deltaTime);

        if (!characterController.isGrounded)
        {
            characterController.Move(new Vector3(0, gravity, 0));
        }
    }
}
