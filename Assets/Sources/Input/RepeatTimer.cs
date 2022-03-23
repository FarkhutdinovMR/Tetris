using System;

public class RepeatTimer
{
    private readonly Action _action;
    private readonly float _frequency;

    private bool _isOn;
    private float _runningTime;

    public RepeatTimer(Action action, float frequency)
    {
        _action = action;
        _frequency = frequency;
    }

    public void Start()
    {
        _isOn = true;
        DoAction();
    }

    public void Stop() => _isOn = false;

    public void Tick(float deltaTime)
    {
        if (_isOn)
        {
            _runningTime += deltaTime;

            if (_runningTime >= _frequency)
                DoAction();
        }
    }

    private void DoAction()
    {
        _action.Invoke();
        _runningTime = 0f;
    }
}