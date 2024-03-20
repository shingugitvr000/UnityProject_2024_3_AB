using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExEnemy : MonoBehaviour
{
    public ExPlayer targetPlayer;
    
    //���� �÷��̾�� �ִ� ���ط�
    private int damage = 20;

    //�÷��̾�� ���ظ� �� �� ȣ��Ǵ� �Լ�
    public void AttackPlayer(ExPlayer player)
    {
        //�÷��̾�� ���ظ� ��
        player.TakeDamage(damage);
        //player.health -= damage;
    }

    private void Update()
    {
        if(targetPlayer != null) 
        {
            if(Input.GetKeyDown(KeyCode.Space)) 
            {
                Debug.Log("����");
                AttackPlayer(targetPlayer);
            }
        }
    }

}
