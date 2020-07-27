using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float _gravity = 0.9f;

    [SerializeField]
    private float _power = 5f;                 // 移動時の力量

    private Rigidbody _rb;

    private float _fallSpeed;                  // ジャンプ中の速度
    private bool _isJump;                      // true : ジャンプ可能, false : ジャンプ不可能

    private const float _jumpSpeed    = 9f;    // ジャンプ時の速度
    private const float _maxFallSpeed = -6f;   // 落下時の最大速度

    void Start()
    {
        _rb         = GetComponent<Rigidbody>();
        _fallSpeed  = _jumpSpeed / 2;
        _isJump     = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isJump)
        {
            Jumping();
        }
    }

    private void FixedUpdate()
    {
        Movement();
        if (!_isJump)
        {
            Falling();
        }
    }

    /// 移動処理
    private void Movement()
    {
        Vector3 vecV, vecH;
        vecH = transform.right   * Input.GetAxisRaw("Horizontal") * _power;
        vecV = transform.forward * Input.GetAxisRaw("Vertical")   * _power;

        /// 移動値の取得
        Vector3 vel = vecH + vecV + new Vector3(0, _fallSpeed, 0);

        /// RigidBodyに力を加える(速度を加算させている)
        _rb.AddForce(vel, ForceMode.VelocityChange);
    }

    // ジャンプ処理
    private void Jumping()
    {
        _isJump    = false;
        _fallSpeed = _jumpSpeed;
    }

    // 落下処理
    private void Falling()
    {
        _fallSpeed = (_fallSpeed >= _maxFallSpeed ? _fallSpeed - _gravity : _fallSpeed);
    }

    // オブジェクトに触れている間入る
    private void OnCollisionStay(Collision col)
    {
        /// 床に着地した時に入る処理
        if (col.gameObject.CompareTag("Floor"))
        {
            _isJump = true;
        }
    }

    // オブジェクトから離れた時に入る
    private void OnCollisionExit(Collision col)
    {
        _isJump = false;
    }
}
