using UnityEngine;

public class GameStarter : MonoBehaviour
{
    private Camera cam;
    
    [Header("position")]
    public Vector3 gamePosition = new Vector3(0, -10, -10);
    
    [Header("zoom")]
    public float gameSize = 5f;
    
    public float transitionSpeed = 2f;
    private bool isTransitioning = false;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if (isTransitioning)
        {
            transform.position = Vector3.Lerp(transform.position, gamePosition, Time.deltaTime * transitionSpeed);
            
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, gameSize, Time.deltaTime * transitionSpeed);

            if (Vector3.Distance(transform.position, gamePosition) < 0.05f && Mathf.Abs(cam.orthographicSize - gameSize) < 0.05f)
            {
                transform.position = gamePosition;
                cam.orthographicSize = gameSize;
                isTransitioning = false;
                
            }
        }
    }

    public void StartGameTransition()
    {
        isTransitioning = true;
    }
}