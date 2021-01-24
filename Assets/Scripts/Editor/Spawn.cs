using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class Spawn : EditorWindow
{
    // Add menu item
    [MenuItem("CONTEXT/SpawnBricks/Spawn Bricks")]
    static void SpawnBricks(MenuCommand command)
    {
        SpawnBricks body = (SpawnBricks)command.context;
        body.PlaceBricks();
    }
}