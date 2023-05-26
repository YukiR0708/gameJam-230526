using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed; //�ړ����x(�C���X�y�N�^�[����ύX��)
    private Rigidbody2D rb = null;
    [SerializeField] GameObject _footPoint = default;
    [SerializeField, Tooltip("ray�̒���")] float _rayLength = 0f;

    public float _ladderSpeed; //�ړ����x(�C���X�y�N�^�[����ύX��)
    private bool isLadder = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //Rigidbody2D�̃C���X�^���X���擾
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        float verticalKey = Input.GetAxisRaw("Vertical");
        float xSpeed = 0;
        float ySpeed = 0;
        if (horizontalKey > 0) //�E�ړ����x
        {
            //transform.localScale = new Vector3(1, 1, 1);
            xSpeed = speed;
        }
        if (horizontalKey < 0) //���ړ����x
        {
            xSpeed = -speed;
        }

        if (isLadder)
        {
            if (verticalKey > 0)
            {
                ySpeed = verticalKey * 0.15f;
            }
        }
        //RaycastHit2D raycastHit2D = Physics2D.Raycast(_footPoint.transform.position, Vector2.right, _rayLength);
        //Vector2 _playerUp = raycastHit2D.normal;
        //if(raycastHit2D.collider.gameObject.CompareTag("Slope"))
        //{
        //    var temp = Vector3.ProjectOnPlane(Vector2.right, -_playerUp);
        //    var _direction = new Vector2(temp.x, temp.y);
        //    rb.velocity = _direction * xSpeed + Vector2.up * rb.velocity.y;
        //}
        //else
        //{
        //    rb.velocity = new Vector2(xSpeed, rb.velocity.y); //���x�ŏI����(y��Gravity Scale)
        //}
        rb.velocity = new Vector2(xSpeed, rb.velocity.y+ySpeed); //���x�ŏI����(y��Gravity Scale)
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "LadderControll")
        {
            isLadder = false;
        }
    }
}
