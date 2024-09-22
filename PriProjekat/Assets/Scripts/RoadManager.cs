using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public GameObject[] segments;
    public float speed = 0.4f;
    float segmentSize = 10f;

    private void FixedUpdate()
    {
        if (GameManager.gameState == GameManager.GameState.running)
        {
            MoveSegments();
        }
    }

    private void MoveSegments()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            float z = segments[i].transform.position.z;
            z -= speed;
            z = Mathf.Round(z * 10) / 10;
            segments[i].transform.position = new Vector3(0, 0, z);

            if (segments[i].transform.position.z <= -segmentSize)
            {
                segments[i].transform.position = new Vector3(0, 0, (segments.Length - 1) * segmentSize);
            }
        }
    }

    public void Reset()
    {
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].transform.position = new Vector3(0, 0, i * segmentSize);
        }
    }
}