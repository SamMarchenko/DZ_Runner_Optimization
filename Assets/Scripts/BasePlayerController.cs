using System.Collections;
using UnityEngine;

namespace Runner
{
    [RequireComponent(typeof(Rigidbody), typeof(PlayerStatsComponent))]
    public abstract class BasePlayerController : MonoBehaviour
    {
        protected PlayerStatsComponent _playerStatsComponent;
        protected Rigidbody _rigidbody;

        protected virtual void Start()
        {
            _playerStatsComponent = GetComponent<PlayerStatsComponent>();
            _rigidbody = GetComponent<Rigidbody>();
            StartCoroutine(MoveForward());
        }

        protected void Jump()
        {
            _rigidbody.AddForce(transform.up * _playerStatsComponent.JumpForce, ForceMode.Impulse);
        }

        private IEnumerator MoveForward()
        {
            while (true)
            {
                transform.position += transform.forward * _playerStatsComponent.ForwardSpeed * Time.deltaTime;
                yield return null;
            }
        }
    }
}