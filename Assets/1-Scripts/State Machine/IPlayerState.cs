using UnityEngine;

namespace SN.MetaVerse
{
    public interface IPlayerState
    {
        void OnChangedState();
    }

    public class Idle : IPlayerState
    {

        public void OnChangedState()
        {
            GameManager.onIdle?.Invoke();
        }
    }
    public class Run : IPlayerState
    {

        public void OnChangedState()
        {
            GameManager.onRun?.Invoke();

        }
    }
    public class Walk : IPlayerState
    {

        public void OnChangedState()
        {
            GameManager.onWalk?.Invoke();
        }
    }
    public class Jump : IPlayerState
    {

        public void OnChangedState()
        {
            GameManager.onJump?.Invoke();

        }
    }
    public class Dance : IPlayerState
    {

        public void OnChangedState()
        {
            GameManager.onDance?.Invoke();

        }
    }
}


