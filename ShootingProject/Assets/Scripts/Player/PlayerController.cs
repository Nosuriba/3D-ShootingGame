using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private Rigidbody _rigidBody;

    private float _speed;

    private const float _jumpSpeed = 1.0f;      // ジャンプ時の速度

    private bool _isJump;                       // true : ジャンプ可能, false : ジャンプ不可能

    private const float _maxFallSpeed = -1.0f;  // 落下時の最大速度
    void Start()
    {
        _camera     = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        _rigidBody  = GetComponent<Rigidbody>();
        _speed      = 0f;
        _isJump     = false;
    }

    void Update()
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
          this.transform.position += Vector3.up * _speed;
        // _rigidBody.MovePosition(this.transform.position + (Vector3.up * _speed) * Time.deltaTime);

        /// カメラの正面方向に角度を合わせる
        this.transform.localEulerAngles = new Vector3(0, _camera.transform.eulerAngles.y, 0);
    }   

    /// 移動処理
    private void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += transform.forward;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += -transform.forward;
        }
        else { }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += transform.right;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += -transform.right;
        }
        else { }
    }

    // ジャンプ処理
    private void Jumping()
    {
        _isJump = false;
        _speed  = _jumpSpeed;
    }

    private void Falling()
    {
        /// 落下速度の調整
        _speed = (_speed >= _maxFallSpeed ? _speed - 0.02f : _speed);
    }

    // 当たり判定が行われている間に入る
   
    private void OnCollisionEnter(Collision col)
    {
        /// 床に着地した時に入る処理
        if (col.gameObject.CompareTag("Floor"))
        {
            _isJump = true;
            _speed  = 0;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (_isJump)
        {
            _speed = 0;
        }
       
        _isJump = false;
    }
}
