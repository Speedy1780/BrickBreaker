using System.Collections;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 2;
    protected Transform myTransform;
    protected int movementType;
    private Vector3 initialScale;
    private float scaleDuration;

    private void Awake()
    {
        movementType = PlayerPrefs.GetInt(PlayerPrefsKeys.MovementType, 1);
        enabled = false;

        if (movementType != MovementType())
            DestroyImmediate(this);
    }
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
    protected abstract int MovementType();

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