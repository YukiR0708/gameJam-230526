using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class CaskController : MonoBehaviour
{

    [SerializeField] float _speed;
    Rigidbody2D rb;
    //[SerializeField, Header("�^�O")] 
    [SerializeField, Tooltip("��q�̃^�O�̖��O (Ladder)")] string _ladderTag;
    [SerializeField, Tooltip("�[�̃^�O�̖��O (Edge)")] string _edgeTag;
    [SerializeField, Tooltip("���ɏu�Ԉړ��i�R���C�_�ʂ蔲������j")] Vector3 _trPos;
    [SerializeField, Tooltip("�ǂꂭ�炢���Ɉړ������邩(�����ŗǂ�)")] float _minusPosY;
    [SerializeField, Tooltip("���Ɉړ����邩�ۂ��̔���ޗ�")] int rnd;
    //[SerializeField] LayerMask _layerMask;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        _trPos = this.transform.position;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == _ladderTag)
        {

            // �����_���֐�
            rnd = Random.Range(1, 6);

            // ���ɗ����邩�ۂ�
            if (rnd >= 4)
            {
                // �����鏈�����u0.5f�v�b��Ɏ��s
                //Invoke(nameof(ChangePos), 0.1f);
                Debug.Log("������");
                StartCoroutine(ChangePos());
                
            }
            else if (rnd < 4)
            {
                // �����Ȃ�
                Debug.Log("�����Ȃ�");
            }
            Debug.Log("Ladder");
        }
    }

    IEnumerator ChangePos()
    {
        // ���ɗ�����

        this.gameObject.layer = 7;


        //this.gameObject.layer = _layerMask;
        rb.velocity = Vector2.up * rb.velocity.y;

        // ����
        yield return new WaitForSeconds(0.5f); 

        this.gameObject.layer = 0;


        Debug.Log("���C���[�ύX��@:�@"  );
    }
}
