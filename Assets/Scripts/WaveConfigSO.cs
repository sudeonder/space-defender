using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "ScriptableObjects/WaveConfig")]
public class WaveConfigSO : ScriptableObject
{
    
    // A ScriptableObject in Unity is a data container that can hold any 
    //type of data you want to create. It is a type of asset that you can create 
    //and customize within the Unity Editor and then use within your game code.

    [SerializeField]
    Transform pathPrefab;
    [SerializeField]
    float moveSpeed = 5f;

    public Transform GetStartingWaypoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWaypoints()
    {
        var wayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            wayPoints.Add(child);
        }
        return wayPoints;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }
}
