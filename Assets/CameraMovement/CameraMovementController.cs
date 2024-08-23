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

    [SerializeField] private Transform startPointBg;

    [SerializeField] private Transform endPointVirtualCamera;

    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private RectTransform summonBar;

    [SerializeField] private float Max_Speed;


    void Start()
    {
        transform.position = new Vector2(startPointBg.position.x, transform.position.y);

        limitationLeftPositionX = transform.position.x;

        float virtualCameraWidth = getHeightOfCamera();

        limitationRightPositionX = endPointBg.position.x - virtualCameraWidth;

        virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>().m_TrackedObjectOffset = new Vector2(virtualCameraWidth/2 , 0);  

    }

    private float getHeightOfCamera() {

        Camera mainCamera = Camera.main;

        float height = mainCamera.orthographicSize * 2;

        float width = height * mainCamera.aspect;

        return width;
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
            if (lastMousePosition.y < summonBar.rect.height) return;

            float distancePosXMoved = (lastMousePosition.x - Input.mousePosition.x) * speedDrag * Time.deltaTime;

            if (distancePosXMoved > Max_Speed) { 
                distancePosXMoved = Max_Speed * distancePosXMoved/distancePosXMoved;
            }

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
