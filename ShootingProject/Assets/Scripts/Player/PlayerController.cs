using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _vel;           // 速度
    void Start()
    {
        _vel = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Movement();
        Jumping();

        /// 速度の更新
        this.transform.position += _vel;
    }

    /// 仮の移動処理
    private void Movement()
    {
        /// 速度の初期化
        _vel.x = _vel.z = 0;
        if (Input.GetKey(KeyCode.W))
        {
            _vel.z = 0.3f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _vel.z = -0.3f;
        }
        else { }

        if (Input.GetKey(KeyCode.D))
        {
            _vel.x = 0.3f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _vel.x = -0.3f;
        }
        else { }
    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _vel.y = 6.0f;
        }
    }
}
