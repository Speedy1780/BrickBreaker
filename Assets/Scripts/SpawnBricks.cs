using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    [SerializeField] private int maxColumns = 11;
    [SerializeField] private int bricksAmount = 22;
    [SerializeField] private GameObject brickPrefab;

    public void PlaceBricks()
    {
        DeleteChildren();
        for (int brickIndex = 0; brickIndex < bricksAmount; brickIndex++)
        {
            GameObject brick = Instantiate(brickPrefab, transform);
            brick.name = $"Brick_{brickIndex}";
            brick.transform.SetParent(transform);
            int row = Mathf.FloorToInt(brickIndex / maxColumns);
            int column = brickIndex % maxColumns;
            brick.transform.position = new Vector3(-5 + column, 4.5f - row, 0);
        }
    }

    void DeleteChildren()
    {
        Transform myTransform = transform;
        while (myTransform.childCount > 0)
        {
            DestroyImmediate(myTransform.GetChild(0).gameObject);
        }
    }
}