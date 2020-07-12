using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;            // 回転の中心となるプレイヤー格納用

    [SerializeField]
    private float speed = 2.0f;           // 回転速度

    [SerializeField]
    private float vAngle= 50;             // 縦角度の限界値 

    private Camera camera;                // カメラの情報

    private float preRotaX;
    private float preX;                 
    private float nowX;

    //呼び出し時に実行される関数
    void Start()
    {
        camera = GetComponent<Camera>();
        preX   = nowX = 0f;
        preRotaX = this.transform.rotation.eulerAngles.x;
    }

    void Update()
    {
        preX = nowX;
        nowX = Input.GetAxis("Mouse X");

        Rotation();
    }

    // カメラの回転を行う
    private void Rotation()
    {
        // 回転の度合いを設定する
        Vector3 rotaRate = new Vector3((nowX - preX) * speed, -(Input.GetAxis("Mouse Y") * speed), 0);


        /////// カメラの角度に制限を付けることができたが、制限された角度がだんだんずれてしまう不具合がある。
        /* カメラの回転 */
        
        /// Y軸回転
        camera.transform.RotateAround(player.transform.position, Vector3.up, rotaRate.x);

        preRotaX += rotaRate.y;

        if (preRotaX >= -vAngle && preRotaX <= vAngle)
        {
            /// X軸回転
            camera.transform.RotateAround(player.transform.position, transform.right, rotaRate.y);

            camera.transform.eulerAngles.x = Mathf.Clamp(camera.transform.eulerAngles.x, -vAngle, vAngle);
        }

    }
}
