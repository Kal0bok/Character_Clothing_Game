using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 1. Горизонтальное движение
        float moveInput = Input.GetAxisRaw("Horizontal"); // Получаем -1, 0 или 1
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        // 2. Проверка земли (маленький невидимый круг под ногами)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // 3. Прыжок
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // Поворот спрайта (опционально)
        if (moveInput != 0)
        {
            // Оставляем Y и Z такими, какие они есть в Инспекторе
            transform.localScale = new Vector3(Mathf.Sign(moveInput), transform.localScale.y, transform.localScale.z);
        }
    }
}