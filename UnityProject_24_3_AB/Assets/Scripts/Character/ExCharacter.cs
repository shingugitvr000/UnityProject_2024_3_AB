using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExCharacter : MonoBehaviour
{
    public float speed = 5.0f;
    
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected virtual void Move() //virtual ���� �Լ��� ���� ����ڿ��� �Լ��� ��ȯ�ϵ��� �Ѵ�. 
    {
        transform.Translate(
            Vector3.forward * speed * Time.deltaTime);
    }

    public void DestoryCharacter()
    {
        Destroy(gameObject);
    }
}
