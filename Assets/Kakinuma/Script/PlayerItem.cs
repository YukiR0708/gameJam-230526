using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    //アイテム用関数
    [SerializeField] GameManager _gm;
    [SerializeField] AudioManager _am;
    bool _isHammer = false;
    bool _isStar = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hammer()
    {
        _isHammer = true;
    }
    public void Star()
    {
        _isStar = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Toge" && !_isHammer && !_isStar)
        {
            _gm.GameOver();
        }
        else if (collision.gameObject.tag == "Toge" && _isHammer || _isStar)
        {
            _am.SePlay(1);
            Destroy(collision.gameObject);
        }
    }
}
