using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Vector3[] Positions;
    [SerializeField]
    private float DockDuration = 2f;
    [SerializeField]
    private float MoveSpeed = 0.01f;
    [SerializeField]
    private float RotationPerFrame = 1f;

    private List<NavMeshAgent> AgentsOnPlatform = new List<NavMeshAgent>();

    private void Start()
    {
        StartCoroutine(MovePlatform());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            AgentsOnPlatform.Add(agent);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out NavMeshAgent agent))
        {
            AgentsOnPlatform.Remove(agent);
        }
    }

    private IEnumerator MovePlatform()
    {
        transform.position = Positions[0];
        int positionIndex = 0;
        int lastPositionIndex;
        float angle = transform.rotation.eulerAngles.y;
        WaitForSeconds Wait = new WaitForSeconds(DockDuration);

        while (true)
        {
            lastPositionIndex = positionIndex;
            positionIndex++;
            if (positionIndex >= Positions.Length)
            {
                positionIndex = 0;
            }

            Vector3 platformMoveDirection = (Positions[positionIndex] - Positions[lastPositionIndex]).normalized;
            float distance = Vector3.Distance(transform.position, Positions[positionIndex]);
            float distanceTraveled = 0;
            while (distanceTraveled < distance)
            {
                angle += RotationPerFrame;
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, angle, transform.rotation.eulerAngles.z);

                distanceTraveled += platformMoveDirection.magnitude * MoveSpeed;

                for (int i = 0; i < AgentsOnPlatform.Count; i++)
                {
                    Vector3 rotatedDestination = Quaternion.Euler(0, RotationPerFrame, 0)
                        * (AgentsOnPlatform[i].destination - transform.position)
                        + transform.position;

                    AgentsOnPlatform[i].destination = rotatedDestination + (platformMoveDirection * MoveSpeed);
                    // for always aligned agents to platforms, you can use this but it will not allow the Agent to move while the platform is moving
                    //Vector3 rotatedPosition = Quaternion.Euler(0, RotationPerFrame, 0)
                    //    * (AgentsOnPlatform[i].transform.position - transform.position)
                    //    + transform.position;

                    //AgentsOnPlatform[i].transform.rotation = Quaternion.Euler(
                    //    AgentsOnPlatform[i].transform.rotation.eulerAngles.x,
                    //    AgentsOnPlatform[i].transform.rotation.eulerAngles.y + RotationPerFrame,
                    //    AgentsOnPlatform[i].transform.rotation.eulerAngles.z
                    //);

                    //AgentsOnPlatform[i].Warp(rotatedPosition + platformMoveDirection * MoveSpeed);
                }

                transform.position += platformMoveDirection * MoveSpeed;

                yield return null;
            }

            yield return Wait;
        }
    }
}
