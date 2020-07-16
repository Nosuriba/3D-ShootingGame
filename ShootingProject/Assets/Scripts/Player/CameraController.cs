using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;            // 回転の中心となるプレイヤー格納用

    [SerializeField]
    private float speed = 2.0f;           // 回転速度

    private float preX;                 
    private float nowX;

    //呼び出し時に実行される関数
    void Start()
    {
        preX   = nowX = 0f;
    }

    private void Update()
    {
        preX = nowX;
        nowX = Input.GetAxisRaw("Mouse X");

        Rotation();
    }

    private void FixedUpdate()
    {
      
    }


    // カメラの回転を行う
    private void Rotation()
    {
        // 回転の度合いを設定する
       //  Vector3 rotaRate = new Vector3((nowX - preX), -Input.GetAxisRaw("Mouse Y"), 0);
        Vector3 rotaRate = new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxisRaw("Mouse Y"), 0);


        /////// カメラの角度に制限を付けることができたが、制限された角度がだんだんずれてしまう不具合がある。
        /* カメラの回転 */
        
        /// Y軸回転
        transform.RotateAround(player.transform.position, Vector3.up, rotaRate.x);

        /// X軸回転
        transform.RotateAround(player.transform.position, transform.right, rotaRate.y);

    }
}
