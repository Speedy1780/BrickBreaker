using UnityEngine;

public class SwipeMovement : Movement
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private AnimationCurve horizontalLimit;
    private Vector3 playerPosition;

    protected override void Start()
    {
        base.Start();
        if (mainCamera == null)
            mainCamera = Camera.main;

        playerPosition = myTransform.position;
    }

    protected override void MovePlayer()
    {
        playerPosition.x = GetHorizontalPosition();
        myTransform.position = playerPosition;
    }

    //Returns the x position of the player
    float GetHorizontalPosition() => horizontalLimit.Evaluate(mainCamera.ScreenToViewportPoint(Input.mousePosition).x);
}