using UnityEngine;
using UnityEngine.UI;

public class LoadResult : MonoBehaviour
{
    float _bonusScore = 0f;
    [SerializeField, Tooltip("ボーナスに乗算する値")] float _bonusAdd = 0f;
    [SerializeField, Tooltip("ボーナステキスト")] Text _bonusText = default;
    [SerializeField] GameManager _gm = default;

    void Start()
    {
        _bonusScore = _gm.LeftTime * _bonusAdd + _gm.Score;
        _bonusText.text = "ボーナス" + _bonusScore.ToString("00000");
    }

}
