using UnityEngine;

public class TapMovement : Movement
{
    [SerializeField] private float sensitivity = 8;
    [SerializeField] private float maxHorizontal = 8;
    private float halfWidth;

    protected override void Start()
    {
        base.Start();
        halfWidth = Screen.width * 0.5f;
    }

    protected override void MovePlayer()
    {
        if (Input.mousePosition.x < halfWidth)
            myTransform.Translate(Vector3.left * sensitivity * Time.deltaTime);
        else
            myTransform.Translate(Vector3.right * sensitivity * Time.deltaTime);

        LimitHorizontal();
    }

    void LimitHorizontal()
    {
        float xPosition = myTransform.position.x;
        if (Mathf.Abs(xPosition) > maxHorizontal)
        {
            Vector3 position = myTransform.position;
            position.x = maxHorizontal * Mathf.Sign(xPosition);
            myTransform.position = position;
        }
    }
}