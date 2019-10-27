using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerTrans;

    public float smoothSpeed = 0.125f;

    private Vector3 offset = new Vector3(0,0,-1);

    Camera mainCamera;
    float camVertExtent, camHorExtent;
    

    float leftBound, rightBound, bottomBound, topBound;
    void Start()
    {
        mainCamera = Camera.main;
        camVertExtent = mainCamera.orthographicSize;
        camHorExtent = mainCamera.aspect * camVertExtent;

        Bounds bounds = new Bounds();
        foreach (SpriteRenderer spriteBounds in GameObject.Find("BackGround").GetComponentsInChildren<SpriteRenderer>())
        {
            bounds.Encapsulate(spriteBounds.bounds);
        }
        
        leftBound = bounds.min.x + camHorExtent;
        rightBound = bounds.max.x - camHorExtent;
        topBound = bounds.max.y - camVertExtent;
        bottomBound = bounds.min.y + camVertExtent;
        offset = new Vector3(camHorExtent - 2, 0, -1);
    }

    void LateUpdate()
    {
        float camX = Mathf.Clamp(playerTrans.position.x + offset.x, leftBound, rightBound);
        float camY = Mathf.Clamp(playerTrans.position.y + offset.y, bottomBound, topBound);

        Vector3 desiredPosition = new Vector3(camX, camY, transform.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
