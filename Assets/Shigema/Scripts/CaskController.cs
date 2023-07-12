using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary> トゲが落ちるかどうか判定するクラス  </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]

public class CaskController : MonoBehaviour
{

    [SerializeField] float _speed;
    Rigidbody2D rb;
    //[SerializeField, Header("タグ")] 
    [SerializeField, Tooltip("梯子のタグの名前 (Ladder)")] string _ladderTag;
    [SerializeField, Tooltip("地面のタグの名前 (Ground)")] string _groundTag;
    [SerializeField, Tooltip("端のタグの名前 (Edge)")] string _edgeTag;
    [SerializeField, Tooltip("下に瞬間移動（コライダ通り抜けられる）")] Vector3 _trPos;
    [SerializeField, Tooltip("どれくらい下に移動させるか(正数で良い)")] float _minusPosY;
    [SerializeField, Tooltip("下に移動するか否かの判定材料")] int rnd;
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

            // ランダム関数
            rnd = Random.Range(1, 6);

            // 下に落ちるか否か
            if (rnd >= 4)
            {
                // 落ちる処理を「0.5f」秒後に実行
                //Invoke(nameof(ChangePos), 0.1f);
                Debug.Log("落ちる");
                StartCoroutine(ChangePos());
                
            }
            else if (rnd < 4)
            {
                // 落ちない
                Debug.Log("落ちない");
            }
            Debug.Log("Ladder");
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _groundTag) Destroy(gameObject);

    }

    IEnumerator ChangePos()
    {
        // 下に落ちる

        this.gameObject.layer = 7;
        Debug.Log("レイヤー変更後　:　" + gameObject.layer);

        //this.gameObject.layer = _layerMask;
        rb.velocity = Vector2.up * rb.velocity.y;

        // 他の関数の処理を優先
        yield return new WaitForSeconds(0.4f); 

        this.gameObject.layer = 0;
    }
}
