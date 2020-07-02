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

    //呼び出し時に実行される関数
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
        Rotation();
    }

    // カメラの回転を行う
    private void Rotation()
    {
        //Vector3でX,Y方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);

        /// カメラの回転
        camera.transform.RotateAround(player.transform.position, Vector3.up, angle.x);
        camera.transform.RotateAround(player.transform.position, transform.right, angle.y);
    }
}
