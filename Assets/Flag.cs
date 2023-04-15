using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Transform ball;
    private Vector3 flagStart;
    void Start()
    {
        flagStart = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance(ball.position, transform.position);
        if (distance > 7f) return;
        transform.position = new Vector3(flagStart.x, flagStart.y + Mathf.Min(5f-distance,5), flagStart.z);
    }
}
