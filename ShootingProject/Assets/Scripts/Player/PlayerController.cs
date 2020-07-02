using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 _vel;                       // 速度

    private Rigidbody rb;                       // RigidBodyの情報取得用  

    [SerializeField]
    private const float _jumpSpeed = 1.0f;      // ジャンプ時の速度

    private bool _isJump;                       // true : ジャンプ可能, false : ジャンプ不可能

    private const float _maxFallSpeed = -1.0f;  // 落下時の最大速度
    void Start()
    {
        _vel    = new Vector3(0, 0, 0);
        rb      = GetComponent<Rigidbody>();
        _isJump = false;
    }

    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && _isJump)
        {
            Jumping();
        }

        if (!_isJump)
        {
            Falling();
        }
        /// 速度の更新
        this.transform.position += _vel;
    }

    /// 移動処理
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

    // ジャンプ処理
    private void Jumping()
    {
        _isJump = false;
        _vel.y  = _jumpSpeed;
    }

    private void Falling()
    {
        /// 落下速度の調整
        _vel.y = (_vel.y >= _maxFallSpeed ? _vel.y - 0.05f : _vel.y);
    }

    // 当たり判定が行われている間に入る
   
    private void OnCollisionEnter(Collision col)
    {
        /// 床に着地した時に入る処理
        if (col.gameObject.CompareTag("Floor"))
        {
            _isJump = true;
        }
    }

}
