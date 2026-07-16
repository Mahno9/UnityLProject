using System;
using System.Collections.Generic;

using _Project.Develop.Runtime.Gameplay.Features.TeamsFeature;

using UnityEngine;

namespace _Project.Develop.Runtime.Configs.Gameplay.Entities
{
    public abstract class ExplosionConfig : EntityConfig
    {
        [field: SerializeField, Min(0)] public float  Radius           { get; private set; } = 3;
        [field: SerializeField, Min(0)] public float  Lifetime         { get; private set; } = 0.4f;
        [field: SerializeField, Min(0)] public float  CreationCooldown { get; private set; } = 0.5f;
        [field: SerializeField, Min(0)] public float  Damage           { get; private set; } = 50f;
        [field: SerializeField]         public string PrefabPath       { get; private set; } = R.Entities.PlayerExplosion;
    }
}