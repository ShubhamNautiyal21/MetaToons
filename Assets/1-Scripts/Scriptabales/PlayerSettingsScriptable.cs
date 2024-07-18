using UnityEngine;

namespace SN.MetaVerse
{
    [CreateAssetMenu(fileName = "PlayerSettingsScriptable", menuName = "Scriptable Objects/PlayerSettingsScriptable")]
    public class PlayerSettingsScriptable : ScriptableObject
    {
        [SerializeField]
        private float _playerSpeed, _sprintSpeed, _jumpHeight, _gravityValue, _mouseSensitivity;


        public float playerSpeed => _playerSpeed;
        public float sprintSpeed => _sprintSpeed;
        public float jumpHeight => _jumpHeight;
        public float gravityValue => _gravityValue;
        public float mouseSensitivity => _mouseSensitivity;

    }
}
