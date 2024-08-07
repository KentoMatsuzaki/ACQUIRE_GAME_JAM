using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ObstacleManager.Instance._isOver == false)
        {
            Vector2 current = new Vector2(transform.position.x, 0);  // y ç¿ïWÇÕ 0 Ç…å≈íË
            Vector2 target = new Vector2(-20, 0);                    // y ç¿ïWÇÕ 0 Ç…å≈íË
            float step = ScrollSpeed.Instance.Speed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(current, target, step);
            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);

            

            if (newPosition.x <= -18.6)
            {
                CloudManager.Instance.SpawnCloud();
                Destroy(this.gameObject);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == ObstacleManager.Instance._playerName)// && Player.Instance.IsInvincible() == false)
        {
            ObstacleManager.Instance._isOver = true;
            //Player.Instance.OnGameOver();
        }
    }
}
