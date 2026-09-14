using UnityEngine;

public class GodRayEffect : MonoBehaviour
{
    [Header("Animation")]
    public float scrollSpeed = 0.1f;
    public float intensityPulse = 0.5f;
    public float pulseSpeed = 1f;

    private Material material;
    private float timeOffset;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            material = renderer.material;
            timeOffset = Random.Range(0f, 100f);
        }
    }

    void Update()
    {
        if (material != null)
        {
            float offset = Time.time * scrollSpeed;
            material.SetTextureOffset("_MainTex", new Vector2(0, offset));

            float pulse = (Mathf.Sin((Time.time + timeOffset) * pulseSpeed) + 1f) * 0.5f;
            float intensity = Mathf.Lerp(0.5f, 1f, pulse * intensityPulse);
            
            Color color = material.color;
            color.a = intensity * 0.3f;
            material.color = color;
        }
    }

    void OnDestroy()
    {
        if (material != null)
        {
            Destroy(material);
        }
    }
}
