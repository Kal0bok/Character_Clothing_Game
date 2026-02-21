using UnityEngine;

public class ClothingItem : MonoBehaviour
{
    [Header("Настройки привязки")]
    public Transform targetSlot; // Сюда в инспекторе перетащи слот (например Slot_Body)
    public string sortingLayerName = "Clothing"; // Имя слоя, который ты создал

    private bool isDragging = false;
    private Vector3 offset;
    private Vector2 originalPosition;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        originalPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        isDragging = true;
        offset = transform.position - GetMouseWorldPos();
        spriteRenderer.sortingOrder = 100; // Поднимаем вещь над всем, пока несем
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        isDragging = false;

        // Проверяем расстояние до слота
        float distance = Vector2.Distance(transform.position, targetSlot.position);

        if (distance < 1.0f) // Если бросили рядом со слотом
        {
            SnapToCharacter();
        }
        else
        {
            ReturnToInventory();
        }
    }

    void SnapToCharacter()
    {
        transform.position = targetSlot.position;
        transform.SetParent(targetSlot);
        spriteRenderer.sortingLayerName = sortingLayerName;
        spriteRenderer.sortingOrder = 10; // Порядок внутри слоя
    }

    void ReturnToInventory()
    {
        transform.SetParent(null);
        transform.position = originalPosition;
        spriteRenderer.sortingOrder = 1;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}