using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private Rigidbody _rb;

    private Vector3 _vel;

    private const float _jumpSpeed = 1.0f;      // ジャンプ時の速度

    private bool _isJump;                       // true : ジャンプ可能, false : ジャンプ不可能

    private const float _maxFallSpeed = -1.0f;  // 落下時の最大速度
    void Start()
    {
        _camera     = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _rb         = GetComponent<Rigidbody>();
        _isJump     = false;
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

        /// ジャンプ処理
          //this.transform.position += Vector3.up * _speed;
        // _rigidBody.MovePosition(this.transform.position + (Vector3.up * _speed) * Time.deltaTime);

        /// カメラの正面方向に角度を合わせる
        this.transform.localEulerAngles = new Vector3(0, _camera.transform.eulerAngles.y, 0);

        _rb.velocity *= 0.85f;
    }

    private void FixedUpdate()
    {
        /// RigidBodyに力を加える(速度を加算させている)
        _rb.AddForce(_vel, ForceMode.VelocityChange);

        Vector3 gravity = new Vector3(0, _vel.y, 0);
        _rb.AddForce(gravity, ForceMode.Acceleration);
        /// 速度制限
        Debug.Log(_rb.velocity);
    }

    /// 移動処理
    private void Movement()
    {
        _vel = Vector3.zero;


        _vel = new Vector3(Input.GetAxisRaw("Horizontal") * 10, 0, Input.GetAxisRaw("Vertical") * 10);
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
        // _vel.y = (_vel.y >= _maxFallSpeed ? _vel.y - 0.02f : _vel.y);

        _vel.y -= 2f;
    }

    // 当たり判定が行われている間に入る(敵キャラと当たった時などで使用する)
    private void OnCollisionEnter(Collision col)
    {
        /// 床に着地した時に入る処理
        if (col.gameObject.CompareTag("Floor"))
        {
            _isJump = true;
            _vel.y = 0;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (_isJump)
        {
            _vel.y = 0;
        }
       
        _isJump = false;
    }
}
