using System;
using System.Collections;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    [SerializeField] private float minimunDistance = .2f;
    [SerializeField] private float maximumTime = 1f;
    [SerializeField,] private PlayerController playerController;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = .9f;
    
    private InputManager inputManager;

    private Vector2 startPosition;
    private float startTime;
    
    private Vector2 endPosition;
    private float endTime;
    
    private Coroutine coroutine;
    
    private void Awake()
    {
        inputManager = InputManager.Instance;
    }

    private void OnEnable()
    {
        inputManager.OnStartTouch += SwipeStart;
        inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManager.OnStartTouch -= SwipeStart;
        inputManager.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minimunDistance &&
            (endTime - startTime) <= maximumTime)
        {
            Debug.DrawLine(startPosition,endPosition,Color.red,5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe up");
        }
        else if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe down");
        }
        else if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            playerController.SwipeLeft();
        }
        else if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            playerController.SwipeRight();
        }
    }
}