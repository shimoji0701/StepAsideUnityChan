using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour{
    public GameObject carPrefab;     //carPrefabを入れる
    public GameObject coinPrefab;    //coinPrefabを入れる
    public GameObject conePrefab;    //conePrefabを入れる

    private int startPos = -160; //スタート地点
    private int goalPos = 120;   //ゴール地点
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private GameObject unitychan;
    private float unityPosz;　　//①


    //①. 最後にアイテムを生成したときのunityちゃんの位置を保存するメンバ変数を準備する
   // ②. アイテムを生成したら1.に位置を格納する
   // ③. ①.の変数と現在のunityちゃんの位置を比較する
    //④. ③の結果がnメートルより大きい時アイテムを生成する ->①.に戻る

    // Use this for initialization
    void Start() {

        this.unitychan = GameObject.Find("unitychan");
        //this.unityPosz = this.unitychan.transform.position.z;
        

    }

    // Update is called once per frame
    void Update() {
        
            if(this.unitychan.transform.position.z  >= startPos-50) {     //③、④     

            
                //どのアイテムをだすかランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2){
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f){
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, startPos);
                        
                    }
                }
                else{
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++){
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くz座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置: 30%車配置:10%何もなし
                        if (1 <= item && item <= 6){
                            //コイン生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, startPos + offsetZ);
                            
                        }
                        else if (7 <= item && item <= 9){
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, startPos + offsetZ);
                            
                        }
                    }
                }
            //this.unityPosz = unitychan.transform.position.z;
            startPos += 15;
        }

       }

    
    
    }
