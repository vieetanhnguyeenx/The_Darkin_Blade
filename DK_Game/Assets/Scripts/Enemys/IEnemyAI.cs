using UnityEngine;

public interface IEnemyAI
{
    void DetectPlayer(Transform player);

    void LosePlayer();

    void HitObstacle(Vector2 obstaclePosition);

    void TakeDamage(int damageAmount);
}

