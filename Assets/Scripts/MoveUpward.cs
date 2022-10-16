using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpward : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        speed = Random.Range(speed, speed + 2f);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
