using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform player;

    [Header("Min and max values from generation")]
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new (Mathf.Clamp(player.position.x, minX, maxX),
            Mathf.Clamp(player.position.y, minY, maxY),
            transform.position.z);

        transform.position = newPosition;
    }
}
