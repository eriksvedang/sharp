using UnityEngine;

public class PanCam : MonoBehaviour
{
    public float speed = 18f;

    public float worldMarginRight = 9999f;
    public float worldMarginLeft = -9999f;
    public float worldMarginTop = 9999f;
    public float worldMarginBottom = -9999f;

    Vector3 movementDirection;
    Vector3 oldPos;

    private void Update()
    {
        var allowPanning = !Application.isEditor && Screen.fullScreen;
        HandleMousePanning(allowPanning);

        if(transform.position.x > worldMarginRight ||
           transform.position.x < worldMarginLeft ||
           transform.position.z > worldMarginTop ||
           transform.position.z < worldMarginBottom
           )
        {
            GoBack();
        }
    }

    public void HandleMousePanning(bool pan)
    {
        //Debug.Log($"Input.mousePosition = {Input.mousePosition}, Screen size = {Screen.width} x {Screen.height}");

        var margin = 10;
        var marginL = margin;
        var marginR = Screen.width - margin;
        var marginB = margin;
        var marginT = Screen.height - margin;
        var cameraDirection = new Vector3(0, 0, 0);

        if (Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.A) ||
            (pan && Input.mousePosition.x < marginL))
        {
            cameraDirection.x -= 1f;
        }

        if (Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.D) ||
            (pan && Input.mousePosition.x > marginR))
        {
            cameraDirection.x += 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.W) ||
            (pan && Input.mousePosition.y > marginT))
        {
            cameraDirection.z += 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow)||
            Input.GetKey(KeyCode.S) ||
            (pan &&Input.mousePosition.y < marginB))
        {
            cameraDirection.z -= 1f;
        }

        SetMovement(cameraDirection);
        oldPos = transform.position;
        transform.Translate(movementDirection.normalized * speed * Time.deltaTime, Space.World);
    }

    public void GoBack()
    {
        movementDirection = Vector3.zero;
        transform.position = oldPos;
    }

    public void SetMovement(Vector3 direction)
    {
        movementDirection = direction;
    }
}
