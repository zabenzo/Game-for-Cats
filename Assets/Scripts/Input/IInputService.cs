using Game.Mouse;
using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Input
{
    public interface IInputService : IService
    {
        bool TouchInMouse(Collider2D mouse);
    }
}