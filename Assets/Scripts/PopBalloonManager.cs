using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopBalloonManager : MonoBehaviour
{

    [SerializeField] Text scoreText;

    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : " + score;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit))
            {
                Collider coll = hit.collider;
                if (coll.CompareTag("Balloon"))
                {
                    score++;
                    scoreText.text = "Score : " + score;
                    Destroy(coll.gameObject);
                }
                if (coll.CompareTag("yellowBalloon"))
                {
                    Time.timeScale = 0;
                    Destroy(coll.gameObject);
                    GameOver();
                }
            }
        }
    }

    private void GameOver()
    {
        //Define what happens during game over
    }
}
