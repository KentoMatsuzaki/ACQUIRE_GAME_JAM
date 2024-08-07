using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
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
            Vector2 current = new Vector2(transform.position.x, 0);  // y ���W�� 0 �ɌŒ�
            Vector2 target = new Vector2(-15, 0);                    // y ���W�� 0 �ɌŒ�
            float step = ScrollSpeed.Instance.Speed * Time.deltaTime;
            Vector2 newPosition = Vector2.MoveTowards(current, target, step);
            transform.position = new Vector3(newPosition.x, transform.position.y, transform.position.z);

            // ��Q�����^�[�Q�b�g�ʒu�ɓ��B������폜
            if (newPosition.x <= -10)
            {
                ObstacleManager.Instance.SpawnObstacles();
                Destroy(this.gameObject);
            }
        }

    }
}
