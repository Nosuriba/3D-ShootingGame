using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Camera camera;                // カメラの情報

    [SerializeField]
    private GameObject player;            // 回転の中心となるプレイヤー格納用

    [SerializeField]
    private float speed = 2.0f;            // 回転速度

    [SerializeField]
    private float vAngle= 70;              // 縦角度の限界値 

    private float preX;                 
    private float nowX;

    //呼び出し時に実行される関数
    void Start()
    {
        camera = GetComponent<Camera>();
        preX = nowX = 0f;
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

        /// カメラの回転
        
        /// Y軸回転
        camera.transform.RotateAround(player.transform.position, Vector3.up, rotaRate.x);

        /// X軸回転
        camera.transform.RotateAround(player.transform.position, transform.right, rotaRate.y);

        //if (camera.transform.localEulerAngles.x >= vAngle)
        //{
        //    camera.transform.localEulerAngles = new Vector3(vAngle,
        //                                                    camera.transform.localEulerAngles.y,
        //                                                    camera.transform.localEulerAngles.z);
        //}
        //else if (camera.transform.localEulerAngles.x <= -vAngle)
        //{
        //    camera.transform.localEulerAngles = new Vector3(-vAngle,
        //                                                    camera.transform.localEulerAngles.y,
        //                                                    camera.transform.localEulerAngles.z);
        //}
    }
}
