using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] private int maxColumns = 11;
    [SerializeField] private int bricksAmount = 22;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private GameObject brickPrefab;

    /// <summary>
    /// Place bricks in a grid layout
    /// </summary>
    public void PlaceBricks()
    {
        DeleteChildren();
        int row;
        int column;
        for (int brickIndex = 0; brickIndex < bricksAmount; brickIndex++)
        {
            GameObject brick = Instantiate(brickPrefab, transform);
            brick.name = $"Brick_{brickIndex}";
            brick.transform.SetParent(transform);
            row = Mathf.FloorToInt(brickIndex / maxColumns);
            column = brickIndex % maxColumns;
            brick.transform.position = startPosition + Vector3.right * column + Vector3.down * row;
        }
    }

    /// <summary>
    /// Delete all spawned bricks
    /// </summary>
    void DeleteChildren()
    {
        Transform myTransform = transform;
        while (myTransform.childCount > 0)
            DestroyImmediate(myTransform.GetChild(0).gameObject);
    }
}