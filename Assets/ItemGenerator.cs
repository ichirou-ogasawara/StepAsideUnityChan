using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    public GameObject unitychan;

    private int startPos = 35;
    private int goalPos = 360;
    private float posRange = 3.4f;
    private float unitychanPos;
    private int lastGeneratePos; //直近で通過した生成位置

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        this.lastGeneratePos = startPos; //生成位置をstartPosで初期化
    }

    // Update is called once per frame
    void Update()
    {
        this.unitychanPos = this.unitychan.transform.position.z; //unitychanのz座標を取得
        
        if ((unitychanPos - lastGeneratePos) >= 15) //直近の生成位置との距離が15mになると
        {
            int num = Random.Range (1, 11); //どのアイテムを出すのかをランダムに設定
            if (num <= 2)
            {
                //コーンをx軸方向に一直線上に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate (conePrefab);
                    cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, unitychanPos + 45); //50m先に生成
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range (1, 11);
                    int offsetZ = Random.Range (-5, 6);
                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate (coinPrefab);
                        coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, unitychanPos + 50 + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate (carPrefab);
                        car.transform.position = new Vector3 (posRange * j, car.transform.position.y, unitychanPos + 50 + offsetZ);
                    }
                }
            }
            if (lastGeneratePos < goalPos) //生成位置がゴールを超えるまで
            {
                this.lastGeneratePos += 15; //生成位置を15m先に更新
            }    
        }
    }
}
