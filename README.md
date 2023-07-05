# gameJam-230526  

## 命名規則について  
  * メンバ変数・・・頭にアンダースコア[ _ ]をつけ、キャメルケースにする  
   例：「*bool _onGround*」  
  * メソッド・・・パスカルケース  
   例：「*void AddScore()*」  
  * その他
    * 関数やフィールド変数ごとにsummaryをつけてコメントを作成。 
    * 複雑なループ処理や条件式があれば適度にコメントを残す。  
    * インスペクターから設定できる値には[Tooltip]をつけ、変数の用途や入れる値を書く  
    * 外部から値を変える可能性のある変数はプロパティを使う  
  
   <br>
   
## コミットメッセージについて  
コミットする際のメッセージの文頭には、下記を参考に情報を記載する

* [add]  
  * 新規ファイル,新規機能追加時  
  * 例：「[add]*PlayerJumpを作成*」  
* [update]  
  * バグ以外の機能修正  
  * 例：「[update]*PlayerJumpに接地判定を追加*」  
* [fix]  
  * バグ修正  
  * 例：「[fix]*Timerの表示が0秒で止まらない不具合を修正*」  
* [remove]  
  * ファイルの削除  
  * 例：「[remove]*使用していなかった素材を整理*」

 ## 使用したアセット
 *UnityAssetStore
  * (Free Pixel Space Platform Pack)[https://assetstore.unity.com/packages/2d/characters/free-pixel-space-platform-pack-146318]
  * (Lidfar's Basics: Platformer)[https://assetstore.unity.com/packages/2d/textures-materials/lidfar-s-basics-platformer-111698]
  * (Pixel Art Platformer - Village Props)[https://assetstore.unity.com/packages/2d/environments/pixel-art-platformer-village-props-166114]
*SE・BGM
  *(効果音ラボ)[https://soundeffect-lab.info/]
  *(魔王魂)[https://maou.audio/]
*フォント
  *(ゆるもじ)[https://www.asterism-m.com/font/bmp-2byte/]
