using UnityEngine;

public class DiverController : MonoBehaviour
{
    [Header("Auto Descent Settings")]
    public float descentSpeed = 2f;
    public float tourDuration = 50f;
    public float horizontalDrift = 0.3f;
    public float driftSpeed = 0.5f;

    [Header("Animation")]
    public float bobAmount = 0.05f;
    public float bobSpeed = 2f;

    private float tourTimer = 0f;
    private float bobTimer = 0f;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        tourTimer += Time.deltaTime;

        float normalizedTime = tourTimer / tourDuration;
        float depth = normalizedTime * 120f;
        
        float drift = Mathf.Sin(tourTimer * driftSpeed) * horizontalDrift;
        
        bobTimer += Time.deltaTime * bobSpeed;
        float bob = Mathf.Sin(bobTimer) * bobAmount;

        Vector3 newPosition = startPosition;
        newPosition.y -= depth;
        newPosition.x += drift;
        newPosition.z += bob;

        transform.position = newPosition;

        if (tourTimer >= tourDuration)
        {
            tourTimer = 0f;
            transform.position = startPosition;
        }
    }

    public float GetDepth()
    {
        return Mathf.Abs(transform.position.y - startPosition.y);
    }

    public string GetDepthZone()
    {
        float depth = GetDepth();
        
        if (depth < 20f) return "Shallow Waters";
        if (depth < 40f) return "Twilight Zone";
        if (depth < 60f) return "Mid Depths";
        if (depth < 80f) return "Deep Zone";
        if (depth < 100f) return "Abyss Approach";
        return "The Abyss";
    }
}
