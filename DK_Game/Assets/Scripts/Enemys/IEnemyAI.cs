using UnityEngine;

public interface IEnemyAI
{
    void DetectPlayer(Transform player);

    void LosePlayer();

    void UpdateAI();

    void HitObstacle(Vector2 obstaclePosition);

    void TakeDamage(int damageAmount);
    void SendDamage(GameObject target);

    void MoveAroundInitPosition();
}

