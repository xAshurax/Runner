using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Begin : MonoBehaviour
{
    private Vector2 touchBegin;
    private Vector2 touchEnd;
    
    private float minDistance=20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                touchBegin = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                touchEnd = touch.position;

                float distance = Vector2.Distance(touchBegin, touchEnd);
                if(distance>=minDistance)
                {
                    SceneManager.LoadScene(1);
                }

            }
        }
        
    }
}
