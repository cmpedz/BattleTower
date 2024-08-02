using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 lastMousePosition;

    private bool isMouseDown = false;

    private float limitationLeftPositionX;

    private float limitationRightPositionX;

    [SerializeField] private float speedDrag = 5f;

    [SerializeField] private Transform endPointBg;

    [SerializeField] private Transform endPointVirtualCamera;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;



    void Start()
    {
        limitationLeftPositionX = transform.position.x;

        float virtualCameraHalfWidth = endPointVirtualCamera.position.x - transform.position.x;

        limitationRightPositionX = endPointBg.position.x - virtualCameraHalfWidth;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) { 
            isMouseDown = true;
            lastMousePosition = Input.mousePosition;
        }

        if(Input.GetMouseButtonUp(0)) { 
            isMouseDown= false;
        }

        if(isMouseDown )
        {

            float distancePosXMoved = (lastMousePosition.x - Input.mousePosition.x) * speedDrag * Time.deltaTime;

            float targetPositionX = transform.position.x + distancePosXMoved;

            if(targetPositionX < limitationLeftPositionX )
            {
                targetPositionX = limitationLeftPositionX;
            }

            if (targetPositionX > limitationRightPositionX) { 
                targetPositionX = limitationRightPositionX;
            }

            Vector2 targetPosition = new Vector2 (targetPositionX, transform.position.y);

            transform.position = targetPosition;    

        }
    }
}
