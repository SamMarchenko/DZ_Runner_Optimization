using UnityEngine;

namespace Runner
{
    public class OldPlayerController : BasePlayerController
    {
        void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Jump();

            var direction = Input.GetAxis("Horizontal") * _playerStatsComponent.SideSpeed * Time.fixedDeltaTime;

            if (direction == 0f) return;
            _rigidbody.velocity += direction * transform.right;
        }
	}
}
