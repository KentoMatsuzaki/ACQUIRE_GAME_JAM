using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ObstacleManager.Instance._playerName && Player.Instance.IsInvincible() == false)
        {
            ObstacleManager.Instance._isOver = true;
            Player.Instance.OnGameOver();
        }
    }
}
