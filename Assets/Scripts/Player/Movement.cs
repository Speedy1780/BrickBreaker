using System.Collections;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    protected Transform myTransform;
    private Vector3 initialScale;
    private float scaleDuration;

    protected virtual void Start()
    {
        myTransform = transform;
        initialScale = myTransform.localScale;
        scaleDuration = 0;
    }

    private void OnEnable()
    {
        EventManager.EDoubleSize += ActivateDoubleSize;
        EventManager.EGameEnded += DisableMovement;
    }

    private void OnDisable()
    {
        EventManager.EDoubleSize -= ActivateDoubleSize;
        EventManager.EGameEnded -= DisableMovement;
    }

    private void ActivateDoubleSize(float duration)
    {
        if (scaleDuration <= 0)
            StartCoroutine(DoubleSize());

        scaleDuration += duration;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            MovePlayer();
    }

    void DisableMovement() => enabled = false;

    protected abstract void MovePlayer();

    IEnumerator DoubleSize()
    {
        Vector3 doubleScale = initialScale;
        doubleScale.x *= 2;

        yield return StartCoroutine(ScalePlayer(doubleScale));

        while (scaleDuration > 0)
        {
            scaleDuration -= Time.deltaTime;
            yield return null;
        }

        scaleDuration = 0;
        yield return StartCoroutine(ScalePlayer(initialScale));
    }

    IEnumerator ScalePlayer(Vector3 target)
    {
        while (transform.localScale != target)
        {
            transform.localScale = Vector3.MoveTowards(transform.localScale, target, scaleSpeed * Time.deltaTime);
            yield return null;
        }
    }
}