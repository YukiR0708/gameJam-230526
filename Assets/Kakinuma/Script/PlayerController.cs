using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //�ړ����x(�C���X�y�N�^�[����ύX��)
    private Rigidbody2D rb = null;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2D�̃C���X�^���X���擾
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        //float verticalKey = Input.GetAxis("Vertical");
        float xSpeed = 0;
        if (horizontalKey > 0) //�E�ړ����x
        {
            //transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
        }
        if (horizontalKey < 0) //���ړ����x
        {
            xSpeed = -speed;
        }
        rb.velocity = new Vector2(xSpeed, rb.velocity.y); //���x�ŏI����(y��Gravity Scale)

    }
}
