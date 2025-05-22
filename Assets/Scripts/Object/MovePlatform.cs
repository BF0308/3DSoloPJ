using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    public Transform[] targets;
    public float moveSpeed=1.0f;
    public int targetIndex=0;

    // Update is called once per frame
    void Update()
    {
        if (targets.Length == 0) return;

        Transform target = targets[targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            targetIndex = (targetIndex + 1) % targets.Length;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        other.collider.transform.SetParent(this.transform);
    }

    private void OnCollisionExit(Collision other)
    {
        other.collider.transform.SetParent(null);
    }
}
