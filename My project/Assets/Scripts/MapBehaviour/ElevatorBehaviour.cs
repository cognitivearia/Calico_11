using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviour : MonoBehaviour
{
    private bool moving = false;
    private int actualFloor = 1;
    [SerializeField] private Transform initialTransform;
    [SerializeField] private Transform finalTransform;
    private Transform thisTransform;
    [SerializeField] float elevatorSpeed = 4f; 

    void Start()
    {
        initialTransform = this.transform;
        thisTransform = GetComponent<Transform>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            buttonPress();
        }
        if (moving == true)
        {
            if (actualFloor == 1)
            {
                thisTransform.position = thisTransform.position + new Vector3(0, Time.deltaTime * elevatorSpeed,0);
                if (thisTransform.position.y>=finalTransform.position.y)
                {
                    actualFloor = 2;
                    moving = false;
                }
            }
            else if (actualFloor==2)
            {
                if (thisTransform.position.y <= initialTransform.position.y)
                {
                    actualFloor = 1;
                    moving = false;
                }
                thisTransform.position = thisTransform.position - new Vector3(0, Time.deltaTime * elevatorSpeed, 0);

            }
        }
    }

    public void buttonPress()
    {
        moving = true;    
    }
}
