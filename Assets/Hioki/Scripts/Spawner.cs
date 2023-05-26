using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("��������v���n�u")] GameObject _toge = default;
    [SerializeField, Tooltip("�C���^�[�o��")] float _interval = 5f;
    /// <summary>���b���������J�E���g</summary>
    float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            //Instantite�M�𐶐����Ă�
            Instantiate(_toge, gameObject.transform, false);
            _timer = 0;
        }
    }
}
