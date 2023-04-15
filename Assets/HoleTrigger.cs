using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public MiniGolf GameManager;
    // Change level when ball enters hole
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
        {
            GameManager.NextLevel();
        }
    }
}
