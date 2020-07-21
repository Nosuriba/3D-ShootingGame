using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;            // 回転の中心となるプレイヤー格納用

    [SerializeField]
    private float speed = 2.0f;           // 回転速度

    //呼び出し時に実行される関数
    void Start()
    {
       
    }

    private void Update()
    {
        Rotation();
    }

    private void FixedUpdate()
    {
        // transform.position += player.GetComponent<PlayerController>().GetVel;
    }

    // カメラの回転を行う
    private void Rotation()
    {
        // 回転の度合いを設定する
        Vector3 rotaRate = new Vector3(Input.GetAxis("Mouse X"), -Input.GetAxisRaw("Mouse Y"), 0);

        /* カメラの回転 */
        
        /// Y軸回転(プレイヤーの回転)
        player.transform.RotateAround(player.transform.position, Vector3.up, rotaRate.x);

        /// X軸回転(カメラの回転)
        transform.RotateAround(player.transform.position, transform.right, rotaRate.y);
    }
}
