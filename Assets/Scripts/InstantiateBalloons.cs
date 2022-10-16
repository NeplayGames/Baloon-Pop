using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateBalloons : MonoBehaviour
{
    [Header("Add bolloon that is popable")]
    [SerializeField] GameObject balloon;

    [Header("Add item that is not popable")]
    [SerializeField] GameObject noSuitableBalloon;

    [Header("Add minimin time required for next popable balloon to instantiate")]
    [SerializeField] float minTimeForPopableBalloon;

    [Header("Add maximum time required for next popable balloon to instantiate")]
    [SerializeField] float maxTimeForPopableBalloon;

    [Header("Add minimum time required for next non popable balloon to instantiate")]
    [SerializeField] float minTimeForNonPopableBalloon;

    [Header("Add maximum time required for next non popable balloon to instantiate")]
    [SerializeField] float maxTimeForNonPopableBalloon;
    float timeForNonPopableBalloon = 0, timeForPopableBalloon = 0;
    float tempA =0, tempB = 0;

    float perFrameTime;

   

    [SerializeField] float time = 2f;

    const float tau = Mathf.PI * 2f;

    void Start()
    {
        ChangeValue();
    }

    // Update is called once per frame
    void Update()
    {

        float cycle = Time.realtimeSinceStartup / time;
        cycle -= time;
        float rawSign = Mathf.Sin(cycle * tau);
     

        transform.position = new Vector3(transform.position.x + rawSign/30, transform.position.y, transform.position.z);

        perFrameTime = Time.deltaTime;
        if(tempB< timeForNonPopableBalloon)
        {
            tempB += perFrameTime;
        }
        else
        {
            tempB = 0;
            timeForNonPopableBalloon = Random.Range(minTimeForNonPopableBalloon, maxTimeForNonPopableBalloon);
            Instantiate(noSuitableBalloon, transform.position, balloon.transform.rotation);

        }
        if (tempA < timeForPopableBalloon)
        {
            tempA += perFrameTime;
        }
        else
        {
            tempA = 0;
            Instantiate(balloon, transform.position, balloon.transform.rotation);
            timeForPopableBalloon = Random.Range(minTimeForPopableBalloon, maxTimeForPopableBalloon);

        }
    }

    void ChangeValue()
    {
        if (maxTimeForNonPopableBalloon > 1)
            maxTimeForNonPopableBalloon -= 0.2f;
        if (maxTimeForPopableBalloon > 1)
            maxTimeForPopableBalloon -= 0.2f;
        if (minTimeForNonPopableBalloon > 1)
            minTimeForNonPopableBalloon -= 0.2f;
        if (minTimeForNonPopableBalloon > 1)
            minTimeForNonPopableBalloon -= 0.2f;

        Invoke(nameof(ChangeValue), 2f);
    }
}
