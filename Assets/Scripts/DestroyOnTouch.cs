using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTouch : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Balloon") || collision.CompareTag("yellowBalloon"))
        {
            Destroy(collision.gameObject);
        }
    }
}
