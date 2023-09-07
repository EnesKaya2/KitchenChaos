using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] GameInput gameInput;
    private bool isWalking;
    void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNarmalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
        transform.position += moveDir * moveSpeed * Time.deltaTime;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotateSpeed * Time.deltaTime);

        isWalking = moveDir != Vector3.zero;
    }
    public bool IsWalking()
    {
        return isWalking;
    }

}
