using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control script/FPS Input")]
public class Movement : MonoBehaviour
{
    public float Speed = 6f;
    public float Gravity = -9.8f;
    private CharacterController _charController;

    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * Speed;
        float deltaZ = Input.GetAxis("Vertical") * Speed;

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);

        movement = Vector3.ClampMagnitude(movement, Speed);
        movement.y = Gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);
    }
}
