using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;
    [SerializeField] private float _deltaDistance = 0.5f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody2D;
    private int _currentPoint;

    private static readonly int IsRunning = Animator.StringToHash("is-running");

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _currentPoint = 0;
    }

    private void FixedUpdate()
    {
        var direction = (_points[_currentPoint].position - transform.position).normalized;
        var xVelocity = direction.x * _speed;
        var yVelocity = _rigidbody2D.velocity.y;
        var distance = Vector2.Distance(_points[_currentPoint].position, transform.position);

        _rigidbody2D.velocity = new Vector2(xVelocity, yVelocity);  
        _animator.SetBool(IsRunning, direction.x != 0);
        UpdateSpriteDirection(direction);

        if (distance < _deltaDistance)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
            {
                _currentPoint = 0;
            }
        }
    }

    private void UpdateSpriteDirection(Vector3 direction)
    {           
            if (direction.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
    }
}
