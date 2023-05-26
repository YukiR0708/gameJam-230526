using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField, Tooltip("ハンマーだったらtrue")]
    bool _ishammer = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //PlayerItemがぶつかったGameObjectについていた時
        if (collision.gameObject.TryGetComponent<PlayerItem>(out PlayerItem playerItem))
        {
            AudioManager audioManager = collision.gameObject.GetComponent<AudioManager>();
            audioManager.SePlay(2);

            //ハンマーの時
            if (_ishammer)
            {
                playerItem.Hammer();
            }
            //スターの時
            else
            {
                playerItem.Star();
            }

            Destroy(gameObject);
        }
    }
}
