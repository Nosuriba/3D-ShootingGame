using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _gravity = 1.2f;

    private Rigidbody _rb;

    private float _horizontal;
    private float _vertical;
    private float _fallSpeed;                    // ジャンプ中の速度(名前を変えたほうがいいかも)

    private bool _isJump;                        // true : ジャンプ可能, false : ジャンプ不可能

    private const float _jumpSpeed = 9f;         // ジャンプ時の速度
    private const float _maxFallSpeed = -6.0f;   // 落下時の最大速度

    void Start()
    {
        _camera     = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _rb         = GetComponent<Rigidbody>();
        _fallSpeed  = 0;
        _isJump     = false;
    }

    private void Update()
    {
        /// 移動方向の入力値取得
        _horizontal = Input.GetAxisRaw("Horizontal") * 10;
        _vertical   = Input.GetAxisRaw("Vertical") * 10;
    }

    private void FixedUpdate()
    {
        Movement();

        if (Input.GetKeyDown(KeyCode.Space)/* && _isJump*/)
        {
            Jumping();
        }

        if (!_isJump)
        {
            Falling();
        }

        /// カメラの正面方向に角度を合わせる
        this.transform.localEulerAngles = new Vector3(0, _camera.transform.eulerAngles.y, 0);
    }

    /// 移動処理
    private void Movement()
    {
        /// カメラのZ軸の方向ベクトルを求める
        Vector3 camVec  = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        // Z軸方向の移動量を求める
        Vector3 moveForward = camVec * _vertical + _camera.transform.right * _horizontal;

        /// 移動値の取得
        Vector3 vel = moveForward + new Vector3(0, _fallSpeed, 0);

        /// RigidBodyに力を加える(速度を加算させている)
        _rb.AddForce(vel, ForceMode.VelocityChange);

        /// 速度の表示(デバッグ)
        Debug.Log(_rb.velocity);

        /// 速度の減速
        _rb.velocity *= 0.85f;
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

    // 当たり判定が行われている間に入る(敵キャラと当たった時などで使用する)
    private void OnCollisionEnter(Collision col)
    {
        /// 床に着地した時に入る処理
        if (col.gameObject.CompareTag("Floor"))
        {
            _isJump = true;
        }
    }

    // 当たり判定で離れた時に入る
    private void OnCollisionExit(Collision col)
    {
        _isJump = false;
    }
}
