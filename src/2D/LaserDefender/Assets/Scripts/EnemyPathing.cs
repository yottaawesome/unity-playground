using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField]
    bool useWaypointFirstPosition = true;

    List<Transform> waypoints;
    WaveConfig waveConfig;
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.GetWaypoints();

        if (useWaypointFirstPosition)
            transform.position = waypoints[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardWaypoint();
    }

    public void SetWaveConfig(WaveConfig newConfig)
    {
        waveConfig = newConfig;
    }

    private void MoveTowardWaypoint()
    {
        if (waypoints.Count == 0)
            return;

        // Move towards the current waypoint
        Vector3 tagetPosition = waypoints[waypointIndex].position;
        
        float movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, tagetPosition, movementThisFrame);

        // If we've reached the waypoint position, increment the index
        if (transform.position == waypoints[waypointIndex].position)
            waypointIndex++;

        // If we've reached the last waypoint position, destroy
        if (transform.position == waypoints[waypoints.Count - 1].position)
            Destroy(gameObject, 0);
    }
}
