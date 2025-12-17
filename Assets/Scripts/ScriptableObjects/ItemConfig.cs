using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "ScriptableObject/Item")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private string id;
        [SerializeField] private List<EffectConfig> effects;
        [SerializeField] private float duration;
        [SerializeField] private int scoreValue;

        public string Id { get => id; set => id = value; }
        public List<EffectConfig> Effects { get => effects; set => effects = value; }
        public float Duration { get => duration; set => duration = value; }
        public int ScoreValue { get => scoreValue; set => scoreValue = value; }
    }

    [Serializable]
    public class EffectConfig
    {
        public EffectType type;
        public float multiplier = 1f;
    }

    public enum EffectType
    {
        SPEED,
        SIZE
    }
}