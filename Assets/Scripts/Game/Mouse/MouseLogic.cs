using System;
using Infrastructure.ServiceLocator;
using Input;
using UnityEngine;

namespace Game.Mouse
{
    public class MouseLogic : MonoBehaviour
    {
        private IInputService _input;
        private CircleCollider2D _collider;

        public event Action OnMouseClicked;

        private void Awake()
        {
            _collider = GetComponent<CircleCollider2D>();
            _input = ServiceLocator.Container.Single<IInputService>();
        }

        private void Update()
        {
            if (_input.TouchInMouse(_collider))
            {
                OnMouseClicked?.Invoke();
            }
        }
    }
}