using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float movementSpeed = 15f;

    [Header("Borders")]
    [SerializeField] private float borderX = 14f;
    [SerializeField] private float borderY = 8f;

    private void Update()
    {
        MoveByAxis();
    }

    private void FixedUpdate()
    {
        RotateToMouse();
        ClampPosition();
    }

    private void MoveByAxis()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirZ = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(dirX * movementSpeed, 0f, dirZ * movementSpeed);

        characterController.Move(direction * Time.deltaTime);
    }

    private void ClampPosition()
    {
        float posX = Mathf.Clamp(transform.position.x, -borderX, borderX);
        float posZ = Mathf.Clamp(transform.position.z, -borderY, borderY);
        transform.position = new Vector3(posX, transform.position.y, posZ);
    }

    private void RotateToMouse()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        Vector2 direction = mousePos - playerPos;

        float angle = Mathf.Atan2(direction.y, -direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0f, angle, 0f));
    }
}
