using UnityEngine;
using UnityEngine.EventSystems;

public class ZoomAndPan : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform content; // The content to zoom and pan
    public float zoomSpeed = 0.1f; // Speed of zooming
    public float panSpeed = 0.5f; // Speed of panning

    private bool isPanning = false;
    private bool mouseOver = false;
    private Vector2 lastMousePosition;

    void Update()
    {
        if (mouseOver)
        {
            HandleZoom();
            HandlePan();
        }

        if (Input.GetMouseButtonDown(2))
        {
            isPanning = true;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(2))
        {
            isPanning = false;
        }

    }

    void HandleZoom()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            float scaleFactor = 1 + Input.mouseScrollDelta.y * zoomSpeed;
            content.localScale *= scaleFactor;
        }
    }

    void HandlePan()
    {

        if ((isPanning) && (mouseOver))
        {
            Vector2 delta = (Vector2)Input.mousePosition - lastMousePosition;
            content.anchoredPosition += delta * panSpeed;
            lastMousePosition = Input.mousePosition;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseOver = false;
    }
}