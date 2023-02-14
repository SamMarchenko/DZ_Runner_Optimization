using UnityEngine;

namespace Runner
{
    public class TriggerComponent : MonoBehaviour
    {
        [SerializeField]
        private Collider _collider;

		[SerializeField]
		private bool _isDamage;

        void Start()
        {
            _collider.isTrigger = true;
        }

		private void OnTriggerEnter(Collider other)
		{
            Debug.Log($"Я вызываюсь на объекте {gameObject.name} из-за реакции на {other.gameObject.name}");
            // if (!other.CompareTag("Player"))
            // {
            //     return;
            // }
            if (_isDamage)
            {
                GameManager.Self.SetDamage();
            }
            else
            {
                GameManager.Self.UpdateLevel();
			}
        }
	}
}