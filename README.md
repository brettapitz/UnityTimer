# UnityTimer
A simple timer implementation in Unity

## Usage
1. Place TimerManager.cs on a GameObject in your Scene
2. Pass a callback function to __timer.timeOut.AddListener()__
3. That's it!

## Design
The Timer class is a MonoBehaviour so that it can detect when its GameObject's disabled, but instead of having a FixedUpdate, it automatically registers with TimerManager, which updates all timers in a single FixedUpdate.

The API's simple: __Run()__ zeros and runs the timer, __Stop()__ zeros and stops it, and __Pause()__ pauses and unpauses it.
