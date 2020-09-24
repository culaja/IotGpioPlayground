using System.Threading;

namespace Framework
{
    internal sealed class Debouncer
    {
        public delegate void OnDebouncedChange(bool value);

        private bool _cashedValue;
        private bool _lastSentValue;

        public event OnDebouncedChange OnDebouncedChangeEvent;

        private readonly Timer _timer;

        public Debouncer()
        {
            _timer = new Timer(TimerCallback, null, 20, -1);
        }

        private void TimerCallback(object state)
        {
            if (_lastSentValue != _cashedValue)
            {
                OnDebouncedChangeEvent?.Invoke(_cashedValue);
                _lastSentValue = _cashedValue;
            }
        }

        public void RegisterNewInput(bool value)
        {
            _cashedValue = value;
            _timer.Change(20, -1);
        }
    }
}