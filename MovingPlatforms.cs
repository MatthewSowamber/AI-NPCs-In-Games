using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class MovingPlatforms : MonoBehaviour
{

    public NavMeshSurface surface;

    public void UpdateMoveUp()
    {
        transform.Translate(1f, 0f, 0f);
        UpdateMesh();

    }

    public void UpdateMoveDown()
    {
        transform.Translate(-1f, 0f, 0f);
        UpdateMesh();
    }

    public void UpdateMesh()
    {
        surface.BuildNavMesh();
    }
}
