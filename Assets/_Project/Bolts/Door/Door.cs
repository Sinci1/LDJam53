using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("General")]
    public Vector3 defaultPos;
    public Vector3 movedPos;
    [RangeAttribute(0f, 1f)] public float doorDelta;
    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 neededToMove = movedPos - defaultPos;
        transform.position = defaultPos + neededToMove * doorDelta;
    }
}
