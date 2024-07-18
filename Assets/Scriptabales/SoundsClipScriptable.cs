using UnityEngine;

namespace SN.MetaVerse
{
    [CreateAssetMenu(fileName = "SoundsClipScriptable", menuName = "Scriptable Objects/SoundsClipScriptable")]
    public class SoundsClipScriptable : ScriptableObject
    {

        [SerializeField]
        private AudioClip _runAudio, _walkAudio;
        public AudioClip runAudio => _runAudio;
        public AudioClip walkAudio => _walkAudio;



    }
}
