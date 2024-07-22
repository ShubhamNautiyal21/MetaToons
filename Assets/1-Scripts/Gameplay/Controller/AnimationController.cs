using UnityEngine;

namespace SN.MetaVerse
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>();
        }

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

            _animator.Play("dance");

        }
        void OnIdle()
        {
            _animator.Play("idle");

        }
        void OnJump()
        {
            _animator.Play("jump");
        }
        void OnWalk()
        {
            _animator.Play("walk");
        }
        void OnRun()
        {
            _animator.Play("run");
        }

    }
}
