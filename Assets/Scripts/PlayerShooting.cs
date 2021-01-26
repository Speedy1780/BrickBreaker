using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Movement movement;
    [SerializeField] private LineRenderer line;

    private Transform myTransform;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        if (movement == null)
            movement = GetComponent<Movement>();

        myTransform = transform;
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        BallMovement ball = PoolManager.Instance.GetPooledObject(PoolID.Ball).GetComponent<BallMovement>();
        ball.transform.SetPositionAndRotation(spawnPoint.position, Quaternion.identity);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        Debug.Log("Key down");
        line.SetPosition(0, myTransform.InverseTransformPoint(spawnPoint.position));
        Vector3 direction = Vector3.up;
        Vector3 tapPosition;

        while (Input.GetMouseButton(0))
        {
            tapPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            direction = tapPosition - spawnPoint.position;
            line.SetPosition(1, myTransform.InverseTransformPoint(tapPosition));
            yield return null;
        }

        movement.enabled = true;
        line.enabled = false;
        ball.Shoot(direction.normalized);
    }
}