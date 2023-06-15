using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool canSwipe = true;
    private Rigidbody _rigidbody;

    private Vector3 cubeFoward;
    private Vector3 cubeRight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cubeFoward = transform.forward;
        cubeRight = transform.right;
    }

    private void Update()
    {
        // Movimenta o cubo para frente
        // Verifica se o cubo está no chão
        if (CheckIfCubeIsFalling())
        {
            _rigidbody.useGravity = true;
            _rigidbody.AddForce(transform.forward * 1f);
            canSwipe = false;
        }
        else
        {
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            _rigidbody.useGravity = false;
            canSwipe = true;
        }
    }

    private bool CheckIfCubeIsFalling()
    {
        // Realiza um Raycast da posição do cubo para baixo
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1f))
        {
            // Verifica se o Raycast atingiu um objeto
            if (hit.collider.CompareTag("Ground"))
            {
                // Cubo está no chão
                return false;
            }
        }

        // Cubo está caindo
        return true;
    }

    public void SwipeLeft()
    {
        if (canSwipe)
        {
            transform.forward = cubeFoward;
        }
    }

    public void SwipeRight()
    {
        if (canSwipe)
        {
            transform.forward = cubeRight;
            
        }
    }
}
