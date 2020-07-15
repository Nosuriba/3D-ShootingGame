using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private float _gravity = 0.2f;

    private Rigidbody _rb;

    private float _fallSpeed;                   // ジャンプ中の速度(名前を変えたほうがいいかも)

    private const float _jumpSpeed = 3.0f;      // ジャンプ時の速度

    private bool _isJump;                       // true : ジャンプ可能, false : ジャンプ不可能

    private const float _maxFallSpeed = -3.0f;  // 落下時の最大速度
    void Start()
    {
        _camera     = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _rb         = GetComponent<Rigidbody>();
        _isJump     = false;
        _fallSpeed  = 0;
    }

    private void Update()
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

    private void FixedUpdate()
    {
        Movement();
       
    }

    /// 移動処理
    private void Movement()
    {
        /// 移動値の取得
        Vector3 vel = new Vector3(Input.GetAxisRaw("Horizontal") * 10,
                                  _fallSpeed,
                                  Input.GetAxisRaw("Vertical") * 10);

        /// RigidBodyに力を加える(速度を加算させている)
        _rb.AddForce(vel, ForceMode.VelocityChange);
        /// 速度制限
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
            //_vel.y = 0;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (_isJump)
        {
            //_vel.y = 0;
        }
       
        _isJump = false;
    }
}
