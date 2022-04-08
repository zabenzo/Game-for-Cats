using Infrastructure.ServiceLocator;
using UnityEngine;

namespace Infrastructure.Input
{
    public interface IInputService : IService
    {
        bool TouchInMouse(Collider2D mouse);
    }
}