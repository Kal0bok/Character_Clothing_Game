using UnityEngine;

public class ClothingItem : MonoBehaviour
{
    [Header("Настройки привязки")]
    public Transform targetSlot;
    public string sortingLayerName = "Clothing";

    [Tooltip("Порядок: Штаны(5), Кофта(10), Оружие(15)")]
    public int priorityOrder = 10;

    private Vector3 offset;
    private Vector2 originalPosition;
    private SpriteRenderer spriteRenderer;
    private Transform originalParent;

    void Start()
    {
        originalPosition = transform.position;
        originalParent = transform.parent;
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Устанавливаем начальный вид
        spriteRenderer.sortingLayerName = sortingLayerName;
        spriteRenderer.sortingOrder = priorityOrder;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        spriteRenderer.sortingOrder = 100; // Поднимаем над всем при переносе
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        float distance = Vector2.Distance(transform.position, targetSlot.position);

        if (distance < 1.0f)
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
        spriteRenderer.sortingOrder = priorityOrder;
    }

    void ReturnToInventory()
    {
        transform.SetParent(originalParent);
        transform.position = originalPosition;
        spriteRenderer.sortingOrder = priorityOrder;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}