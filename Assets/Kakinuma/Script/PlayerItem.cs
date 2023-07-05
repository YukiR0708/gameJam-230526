using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    //アイテム用関数
    [SerializeField] GameManager _gm;
    [SerializeField] AudioManager _am;

    //制限時間
    [SerializeField] float _hammerTime = 5f;
    [SerializeField] float _starTime = 5f;

    float _time = 0;

    //アイテム持っているか
    bool _hasItem = false;
    bool _isHammer = false;
    bool _isStar = false;
    void Start()
    {

    }

    void Update()
    {
        if (_hasItem)
        {
            if (_isHammer)
            {
                _time += Time.deltaTime;
                if (_time > _hammerTime)
                {
                    _isHammer = false;
                }
            }

            if (_isStar)
            {
                _time += Time.deltaTime;
                if (_time > _hammerTime)
                {
                    _isStar = false;
                }
            }
        }

    }
    public void Hammer()
    {
        if (!_hasItem)
        {
            _isHammer = true;
            _hasItem = true;
        }
    }
    public void Star()
    {
        if (!_hasItem)
        {
            _isStar = true;
            _hasItem = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Toge" && !_isHammer && !_isStar)
        {
            Debug.Log("gameover");
            _gm.GameOver();
        }
        else if (collision.gameObject.tag == "Toge" && (_isHammer || _isStar))
        {
            _am.SePlay(1);
            _gm.AddScore(20);
            Destroy(collision.gameObject);
        }
    }
}
