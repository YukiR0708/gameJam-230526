using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("生成するプレハブ")] GameObject _toge = default;
    [SerializeField, Tooltip("インターバル")] float _interval = 5f;
    /// <summary>何秒たったかカウント</summary>
    float _timer = 0;

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer > _interval)
        {
            //Instantite樽を生成してる
            Instantiate(_toge, gameObject.transform, false);
            _timer = 0;
        }
    }
}
