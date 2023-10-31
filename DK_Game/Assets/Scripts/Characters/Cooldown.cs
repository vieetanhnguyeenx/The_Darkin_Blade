using UnityEngine;

namespace Assets.Scripts.Characters
{
    [System.Serializable]
    public class Cooldown
    {
        [SerializeField] public float cooldownTime;
        private float _nextColdDown;

        public bool IsCoolingDown => Time.time < _nextColdDown;
        public void StartCoolDown() => _nextColdDown = Time.time + cooldownTime;

    }
}

