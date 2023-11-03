using System;
using UnityEngine;

namespace GameSceneScripts
{
    [Serializable]
    public class BlockerColorAnimationHolder
    {
        public float AnimationTime;
        public AnimationCurve ColorAnimationCurve;
        [ColorUsage(false, true)] public Color ColorFrom;
        [ColorUsage(false, true)] public Color ColorTo;
    }
}
