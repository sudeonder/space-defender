using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField]
    private WaveConfigSO waveConfig;
    private List<Transform> wayPoints;
    private int wayPointIndex = 0;

    void Start()
    {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            Vector3 targetPosition = wayPoints[wayPointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);

            if (transform.position == targetPosition)
            {
                wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
