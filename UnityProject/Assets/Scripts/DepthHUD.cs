using UnityEngine;
using TMPro;

public class DepthHUD : MonoBehaviour
{
    public DiverController diver;
    public TextMeshProUGUI depthText;
    public TextMeshProUGUI zoneText;

    void Update()
    {
        if (diver != null)
        {
            float depth = diver.GetDepth();
            string zone = diver.GetDepthZone();

            if (depthText != null)
            {
                depthText.text = $"Depth: {depth:F1}m";
            }

            if (zoneText != null)
            {
                zoneText.text = zone;
            }
        }
    }
}
