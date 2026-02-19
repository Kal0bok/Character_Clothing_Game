using NUnit.Framework;
using UnityEngine;
using RangeAttribute = UnityEngine.RangeAttribute;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [Range(0f, 1f)]
    public float power = 0.5f;

    [Header("Position Jiggler")]
    public bool jigglePosition = true;
    public Vector2 positionJigAmount;
    [Range(0f, 100f)]
    public float positionFrequency = 10f;
    float positionTimer;
    Vector2 basePosition;

    [Header("Rotation Jiggler")]
    public bool jiggleRotaton = true;
    public Vector3 rotationJigAmount;
    [Range(0f, 100f)]
    public float rotationFrequency = 10f;
    float rotationTimer;
    Quaternion baseRotation;

    [Header("Scale Jiggler")]
    public bool jiggleScale = true;
    public Vector2 scaleJigAmount;
    [Range(0f, 100f)]
    public float scaleFrequency = 10f;
    float scaleTimer;
    Vector2 baseScale;


    private void Start()
    {
        basePosition = transform.localPosition;
        baseRotation = transform.localRotation;
        baseScale = transform.localScale;
    }

    private void Update()
    {
        if (jigglePosition)
        {
            positionTimer += Time.deltaTime * positionFrequency;
            Vector2 offset = new Vector2(
                Mathf.Sin(positionTimer) * positionJigAmount.x,
                Mathf.Cos(positionTimer) * positionJigAmount.y);
            
            transform.localPosition = basePosition + offset * power;

        }
        if(jigglePosition)
        {
            rotationTimer += Time.deltaTime * rotationFrequency;
            Vector3 offset = new Vector3(
                Mathf.Sin(rotationTimer) * rotationJigAmount.x,
                Mathf.Cos(rotationTimer) * rotationJigAmount.y,
                Mathf.Sin(rotationTimer) * rotationJigAmount.z);
        }
        if (jiggleScale)
        {
            scaleTimer += Time.deltaTime * scaleFrequency;
            transform.localScale = baseScale + scaleJigAmount * Mathf.Sin(scaleTimer) * power;
        }
    }

}
