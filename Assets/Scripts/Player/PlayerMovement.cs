using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    public float playerWalkingSpeed = 5f;
    public float playerRunningSpeed = 7f;
    public float jumpStrength = 6f;
    public float verticalRotationLimit = 80f;

    float forwardMovement;
    float sidewaysMovement;

    float verticalVelocity;

    float verticalRotation = 0;
    CharacterController cc;

    Floor floor;
    GameController controller;

    void Awake()
    {
        cc = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        floor = null;
        controller = null;

        if (gameControllerObject != null)
        {
            floor = gameControllerObject.GetComponent<Floor>();
            controller = gameControllerObject.GetComponent<GameController>();
        }
        if (floor == null)
        {
            Debug.Log("Cannot find 'Floor' script");
        }
        if (controller == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        
        float horizontalRotation = Input.GetAxis("Mouse X");
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y");
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        if (cc.isGrounded)
        {
            forwardMovement = Input.GetAxis("Vertical") * playerWalkingSpeed;
            sidewaysMovement = Input.GetAxis("Horizontal") * playerWalkingSpeed;
            //Run when pressed Left Shift
            if (Input.GetKey(KeyCode.LeftShift))
            {
                forwardMovement = Input.GetAxis("Vertical") * playerRunningSpeed;
                sidewaysMovement = Input.GetAxis("Horizontal") * playerRunningSpeed;
            }
            if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    DynamicCrosshair.spread = DynamicCrosshair.RUN_SPREAD;
                }
                else
                {
                    DynamicCrosshair.spread = DynamicCrosshair.WALK_SPREAD;
                }
            }
        }
        else
        {
            DynamicCrosshair.spread = DynamicCrosshair.JUMP_SPREAD;
        }
      
        verticalVelocity += Physics.gravity.y * Time.deltaTime;

        //Jump w/ space bar
        if (Input.GetButton("Jump") && cc.isGrounded)
        {
            verticalVelocity = jumpStrength;
        }

        Vector3 playerMovement = new Vector3(sidewaysMovement, verticalVelocity, forwardMovement);
 
        cc.Move(transform.rotation * playerMovement * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Heal"))
        {
            gameObject.GetComponent<PlayerHealth>().Heal(other.GetComponent<Pack>().value);

            string message = "+ " + other.GetComponent<Pack>().value.ToString() + " health";

            controller.setMessage(message);

            Destroy(other.gameObject);

            Debug.Log("Heal caught");

        }
        else if (other.CompareTag("Key"))
        {
            controller.setMessage("+ Key");

            floor.FoundKey(other.GetComponent<Pack>().value);

            Destroy(other.gameObject);

            Debug.Log("Key caught");
        }
        else if (other.CompareTag("Ammo"))
        {
            gameObject.GetComponentInChildren<Pistol>().MoreAmmo(other.GetComponent<Pack>().value);

            Destroy(other.gameObject);

            Debug.Log("Ammo caught");
        }
    }
}