using UnityEngine;

public class QuickStart : MonoBehaviour
{
    public Camera mainCamera; 
    public Vector3 gamePosition = new Vector3(0, -10, -10);
    public float gameSize = 5f;

    public void TeleportToGame()
    {
        // 1. Проверяем, нажалась ли кнопка вообще
        Debug.Log("КНОПКА НАЖАТА!");

        // 2. Если камеру не перетащили в инспектор, пытаемся найти её сами
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        if (mainCamera != null)
        {
            // 3. Прямое перемещение без лишних условий
            mainCamera.transform.position = gamePosition;
            mainCamera.orthographicSize = gameSize;
            Debug.Log("Камера перемещена в: " + gamePosition);
        }
        else
        {
            Debug.LogError("ОШИБКА: Камера не найдена на сцене!");
        }
    }
}