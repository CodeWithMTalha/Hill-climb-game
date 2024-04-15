using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveCar : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _frontTireRB;
    [SerializeField] private Rigidbody2D _backTireRB;
    [SerializeField] private Rigidbody2D _carRB;
    [SerializeField] private float _speed = 150f;
    [SerializeField] private float _rotationSpeed = 300f;

    private float _moveInput;

    private bool moveLeft = false;
    private bool moveRight = false;

    // Start is called before the first frame update
    void Start()
    {
        moveLeft = false;
        moveRight = false;
    }

    // Update is called once per frame
    void Update()
    {
       // _moveInput = Input.GetAxisRaw("Horizontal");
        MovePlayer();
    }

    private void FixedUpdate()
    {
        _frontTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _backTireRB.AddTorque(-_moveInput * _speed * Time.fixedDeltaTime);
        _carRB.AddTorque(-_moveInput * _rotationSpeed * Time.fixedDeltaTime);
    }

    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void MovePlayer()
    {
        if (moveRight)
        {
            _moveInput = 1f;
        }
        else if (moveLeft)
        {
            _moveInput = -1f;
        }
        else
        {
            _moveInput = 0;
        }
    }
}
