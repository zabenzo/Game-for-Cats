using Extensions;
using Infrastructure.ServiceLocator;
using UnityEngine;
using Utility;

namespace Game.Mouse
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class MouseMove : MonoBehaviour
    {
        private IScreenUtility _screenUtility;
        private MouseLogic _mouseLogic;
        private Rigidbody2D _rigidbody;

        private Vector2 _moveDirection;
        
        private float _moveSpeed;
        private float _minX;
        private float _minY;
        private float _maxX;
        private float _maxY;

        public void Construct(float moveSpeed)
        {
            _moveSpeed = moveSpeed;
        }

        private void Awake()
        {
            InitializeComponents();
            InitializeMoveLimits();
            
            _mouseLogic.OnMouseClicked += TeleportMouseOnBasicPosition;
        }

        private void Start() => 
            ChangeMoveDirection();

        private void FixedUpdate() => 
            MoveMouse();

        private void Update()
        {
            if (OutOfLimits())
            {
                ChangeMoveDirection();
            }
        }

        private void TeleportMouseOnBasicPosition()
        {
            _rigidbody.position = new Vector2(RandomXDirection(_minX, _maxX), RandomYDirection(_minY, _maxY));
            ChangeMoveDirection();
        }

        private void ChangeMoveDirection()
        {
            float maxXDirection;
            float minXDirection;
            float maxYDirection;
            float minYDirection;
            
            if (transform.position.x > _maxX)
            {
                maxXDirection = 0.0f;
                minXDirection = _minX;
            }
            else
            {
                maxXDirection = _maxX;
                minXDirection = 0.0f;
            }

            if (transform.position.y > _maxY)
            {
                maxYDirection = 0.0f;
                minYDirection = _minY;
            }
            else
            {
                maxYDirection = _maxY;
                minYDirection = 0.0f;
            }
            
            _moveDirection = new Vector2(RandomXDirection(minXDirection, maxXDirection), RandomYDirection(minYDirection, maxYDirection));
            transform.LookAt2D(_moveDirection);
        }


        private void InitializeMoveLimits()
        {
            _minX = _screenUtility.LeftLimit() + GameConstants.PositionValueOffset;
            _maxX = _screenUtility.RightLimit() - GameConstants.PositionValueOffset;
            _minY = _screenUtility.BottomLimit() + GameConstants.PositionValueOffset;
            _maxY = _screenUtility.TopLimit() - GameConstants.PositionValueOffset;
        }

        private void InitializeComponents()
        {
            _screenUtility = ServiceLocator.Container.Single<IScreenUtility>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _mouseLogic = GetComponent<MouseLogic>();
        }

        private void MoveMouse() => 
            _rigidbody.velocity = _moveDirection.normalized * _moveSpeed;

        private bool OutOfLimits() =>
            transform.position.x > _maxX || transform.position.x < _minX || transform.position.y > _maxY ||
            transform.position.y < _minY;

        private float RandomYDirection(float minYDirection, float maxYDirection) => 
            Random.Range(minYDirection, maxYDirection);

        private float RandomXDirection(float minXDirection, float maxXDirection) => 
            Random.Range(minXDirection, maxXDirection);
    }
}