using UnityEngine;
using UnityEngine.EventSystems;

public class DragScript : MonoBehaviour,
    IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    private SoundEffectScript sfxScript;

    [Header("Fling Settings")]
    [SerializeField] private float friction = 0.95f; // How fast it slows down (0 to 1)
    [SerializeField] private float stopThreshold = 0.1f; // Speed at which it fully stops

    private Vector2 velocity;
    private bool isDragging = false;

    void Start()
    {
        sfxScript = FindFirstObjectByType<SoundEffectScript>();
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Only apply "fling" motion if we aren't currently holding the object
        if (!isDragging && velocity.magnitude > stopThreshold)
        {
            // Apply friction
            velocity *= friction;

            // Update position
            Vector3 newPos = rectTransform.position + (Vector3)velocity;

            // Keep it within screen bounds while flinging
            newPos.x = Mathf.Clamp(newPos.x, rectTransform.rect.width / 2, Screen.width - rectTransform.rect.width / 2);
            newPos.y = Mathf.Clamp(newPos.y, rectTransform.rect.height / 2, Screen.height - rectTransform.rect.height / 2);

            rectTransform.position = newPos;

            // Bounce off edges (Optional: stops the velocity if it hits a wall)
            if (newPos.x <= rectTransform.rect.width / 2 || newPos.x >= Screen.width - rectTransform.rect.width / 2) velocity.x *= -0.5f;
            if (newPos.y <= rectTransform.rect.height / 2 || newPos.y >= Screen.height - rectTransform.rect.height / 2) velocity.y *= -0.5f;
        }
    }

    public void OnPointerDown(PointerEventData Data)
    {
        sfxScript.PlaySFX(0);
        velocity = Vector2.zero; // Stop any current fling motion when clicked
    }

    public void OnBeginDrag(PointerEventData Data)
    {
        isDragging = true;
    }

    public void OnDrag(PointerEventData Data)
    {
        // Calculate velocity based on mouse movement since last frame
        velocity = Data.delta;

        Vector2 mousePosition = Data.position;
        mousePosition.x = Mathf.Clamp(mousePosition.x, 0 + rectTransform.rect.width / 2, Screen.width - rectTransform.rect.width / 2);
        mousePosition.y = Mathf.Clamp(mousePosition.y, 0 + rectTransform.rect.height / 2, Screen.height - rectTransform.rect.height / 2);

        rectTransform.position = mousePosition;
    }

    public void OnEndDrag(PointerEventData Data)
    {
        isDragging = false;
        // The current 'velocity' from the last OnDrag frame will now take over in Update()
    }
}