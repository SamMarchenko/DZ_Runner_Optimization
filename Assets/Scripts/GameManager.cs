using UnityEngine;
using UnityEngine.UI;

namespace Runner
{
    public class GameManager : MonoBehaviour
    {
        private int _progress = 0;

        private float _step = 6f;
        private int _currentIndex = 0;
        private float _lastZ = 30f;
        

        [SerializeField, Range(1, 100), Tooltip("Это здоровье игрока, не перепутай")]
        private int _health = 10;
        [SerializeField]
        private Transform _player;
        [SerializeField]
        private Transform[] _levels;
        [SerializeField, Space]
        private Text _progressText;


        public static GameManager Self { get; private set; }



        void Awake()
        {
            Self = this;
        }

		private void Update()
		{
            if (_player.position.y <= -1f) SetDamage();
        }

		public void SetDamage()
        {
            _health -= 1;

            Debug.Log("Current health: " + _health);

            if(_health <= 0)
            {
                Debug.Log("---Игрок погиб!---");
                UnityEditor.EditorApplication.isPaused = true;
			}
		}

        public void UpdateLevel()
        {
            _progress++;
            _progressText.text = _progress.ToString();

            _lastZ += _step;
            for(int i = 0; i < _levels.Length; i++)
            {
                var position = _levels[_currentIndex].position;
                position.z = _lastZ;
                _levels[_currentIndex].position = position;
            }

            _currentIndex++;
            if (_currentIndex >= _levels.Length)
            {
                _currentIndex = 0;
            }
	    }
    }
}