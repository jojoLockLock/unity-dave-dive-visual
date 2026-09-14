using UnityEngine;

[ExecuteAlways]
public class UnderwaterFogController : MonoBehaviour
{
    [Header("Depth Colors")]
    public Color shallowColor = new Color(0.4f, 0.8f, 0.9f, 1f);
    public Color deepColor = new Color(0.05f, 0.1f, 0.3f, 1f);
    
    [Header("Fog Settings")]
    public float fogStart = 5f;
    public float fogEnd = 50f;
    public float depthColorTransition = 100f;
    
    [Header("Target")]
    public Transform diver;
    
    private Material skyboxMaterial;

    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Linear;
    }

    void Update()
    {
        if (diver == null) return;

        float depth = Mathf.Abs(diver.position.y);
        float depthNormalized = Mathf.Clamp01(depth / depthColorTransition);
        
        Color currentFogColor = Color.Lerp(shallowColor, deepColor, depthNormalized);
        RenderSettings.fogColor = currentFogColor;
        
        RenderSettings.fogStartDistance = fogStart;
        RenderSettings.fogEndDistance = fogEnd;
        
        Camera.main.backgroundColor = currentFogColor;
    }
}
