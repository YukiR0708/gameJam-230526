using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary> ゲームマネージャー制限時間やスコアを管理する  </summary>
public class GameManager : MonoBehaviour
{
    [SerializeField, Tooltip("現在のスコア")] int _score = 0;
    [SerializeField, Tooltip("制限時間(初期設定)")] float _initialLimit = 0f;
    [SerializeField, Tooltip("現在の残り時間")] float _nowTime = 0f;
    [SerializeField, Tooltip("時間テキスト")] Text _timerText = default;
    [SerializeField, Tooltip("スコアテキスト")] Text _scoreText = default;
    float _bonusScore = 0f;
    [SerializeField, Tooltip("ボーナスに乗算する値")] float _bonusAdd = 0f;
    [SerializeField, Tooltip("ボーナステキスト")] Text _bonusText = default;
    [SerializeField, Tooltip("スコアのカンスト値")] float _maxScore = 100000;
    [Tooltip("前フレームのステート")] GameState _oldState = GameState.InGame;
    [Tooltip("クリア時の残り時間")] static float _leftTime = 0f;
    public float LeftTime { get { return _leftTime; } }

    /// <summary> ゲームの状態を管理する列挙型 </summary>
    public enum GameState
    {
        InGame, //ゲーム中
        Clear,  //クリア
        GameOver,   //ゲームオーバー
    }

    static GameState _nowState = GameState.InGame;
    /// <summary> GameStateのプロパティ </summary>
    public GameState NowState { get => _nowState; set => _nowState = value; }

    void Start()
    {
        _nowTime = _initialLimit;
    }

    void Update()
    {
        if (_nowState == GameState.InGame)
        {
            Timer();
        }
        else if (_nowState == GameState.Clear && _oldState == GameState.InGame)
        {
            SceneManager.LoadScene("Result");
        }
        else if (_nowState == GameState.GameOver && _oldState == GameState.InGame)
        {
            GameOver();
        }

        _oldState = _nowState;
    }

    /// <summary> スコアを加算するメソッド </summary>
    /// <param name="score"> 加算したいスコア </param>
    public void AddScore(int score)
    {
        if (_score < _maxScore)
        {
            _score += score;
        }

        _scoreText.text = "Score:" + _score.ToString("D5");
    }

    /// <summary> 残り時間を減らして表示するメソッド  </summary>
    private void Timer()
    {
        _nowTime -= Time.deltaTime;
        _timerText.text = "Time:" + _nowTime.ToString("D5");
        if (_nowTime <= 0f)
        {
            _nowState = GameState.GameOver;
        }
    }

    /// <summary> ゲームオーバーにするメソッド  </summary>
    public void GameOver()
    {
        _nowState = GameState.GameOver;
    }

    /// <summary> ゲームクリアにするメソッド  </summary>
    public void Clear()
    {
        _bonusScore = _leftTime * _bonusAdd + _score;
        _bonusText.text = "ボーナス" + _bonusScore.ToString("D5");
        _nowState = GameState.Clear;
    }

}
