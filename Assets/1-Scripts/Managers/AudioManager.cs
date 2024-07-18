using UnityEngine;

namespace SN.MetaVerse
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private SoundsClipScriptable soundsClipScriptable;


        public AudioClip walk, run;

        void OnEnable()
        {

            GameManager.onDance += OnDance;
            GameManager.onIdle += OnIdle;
            GameManager.onJump += OnJump;
            GameManager.onRun += OnRun;
            GameManager.onWalk += OnWalk;
        }
        void OnDisable()
        {
            GameManager.onDance -= OnDance;
            GameManager.onIdle -= OnIdle;
            GameManager.onJump -= OnJump;
            GameManager.onRun -= OnRun;
            GameManager.onWalk -= OnWalk;

        }

        void OnDance()
        {

        }
        void OnIdle()
        {
            _audioSource.clip = null;

        }
        void OnJump()
        {

        }
        void OnWalk()
        {

            _audioSource.clip = soundsClipScriptable.walkAudio;
            _audioSource.Play();




        }
        void OnRun()
        {

            _audioSource.clip = soundsClipScriptable.runAudio;
            _audioSource.Play();


        }


    }
}
