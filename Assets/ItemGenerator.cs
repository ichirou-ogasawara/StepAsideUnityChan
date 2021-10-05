using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    public GameObject unitychan;

    private int startPos = 80;
    private int goalPos = 360;
    private float posRange = 3.4f; // アイテムを出すx方向の範囲(間隔を広げるため)
    float unitychanPos;

    // Start is called before the first frame update
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        //for (float generatePos = startPos; generatePos < goalPos; generatePos += (this.unitychanPos + 15)) //一定の距離ごとにアイテム
        
    }

    // Update is called once per frame
    void Update()
    {
        this.unitychanPos = this.unitychan.transform.position.z;
        float generatePos = (unitychanPos + 45.0f);

        if ((generatePos > startPos) && (generatePos < goalPos))
        {
            int num = Random.Range (1, 501); //どのアイテムを出すのかをランダムに設定
            if (num == 1)
            {
                //コーンをx軸方向に一直線上に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate (conePrefab);
                    cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, generatePos); //4はコーンの間隔を広げるための数値
                }
            }
            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range (1, 501);
                    int offsetZ = Random.Range (-5, 6);
                    if (1 <= item && item <= 3)
                    {
                        GameObject coin = Instantiate (coinPrefab);
                        coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, generatePos + offsetZ);
                    }
                    else if (4 <= item && item <= 5)
                    {
                        GameObject car = Instantiate (carPrefab);
                        car.transform.position = new Vector3 (posRange * j, car.transform.position.y, generatePos + offsetZ);
                    }
                }
            }
        }
    }
}
