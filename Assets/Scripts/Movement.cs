using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    protected Transform myTransform;

    protected virtual void Start() => myTransform = transform;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MovePlayer();
        }
    }

    protected abstract void MovePlayer();
}