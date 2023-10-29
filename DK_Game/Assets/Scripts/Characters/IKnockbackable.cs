using UnityEngine;

namespace Assets.Scripts.Characters
{

    public interface IKnockbackable
    {
        void DealKnockback(Vector2 knockback);
    }
}

