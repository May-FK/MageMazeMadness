using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("Speed the player will move at.")]
    public float speed = .5f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    [HideInInspector]
    public bool canMove = true;

    //Swaye Motion Variables
    private float direction = 1;
    private float timeTrigger;
    private float oldTime;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Swaye Motion
        timeTrigger = Time.time - oldTime;
        if (timeTrigger >= 3)
        {
            if (direction == 1)
            {
                direction = 1;
            }
            direction = 1;
            oldTime = Time.time;
            timeTrigger = 0;
            transform.Rotate(0, 180, 0);
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeedY = speed * direction;
        moveDirection = forward * curSpeedY;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
