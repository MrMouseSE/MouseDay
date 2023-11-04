using UnityEngine;
using UnityEngine.UI;

namespace GameSceneScripts.HalthSystem
{
    public class HealthColorController : MonoBehaviour
    {
        public Image HalthLine;
        [ColorUsage(true, true)] public Color FullHealthColor;
        [ColorUsage(true, true)] public Color LowHealthColor;

        public void UpdateHealthColor(float value)
        {
            HalthLine.color = Color.Lerp(LowHealthColor, FullHealthColor, value);
        }
    }
}