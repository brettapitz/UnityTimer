# UnityTimer
A simple timer implementation in Unity

## Usage
1. Place TimerManager.cs on a GameObject in your Scene
2. Construct a new timer with __new Timer(_float_ lengthInSeconds, _bool_ shouldLoop)__
3. Pass a callback function to __timer.timeOut.AddListener()__
4. That's it!

## Design
The Timer class is a generic C# class, and doesn't inherit from MonoBehaviour, so it doesn't need to be added to a GameObject, and it doesn't add unnecessary FixedUpdate calls (all updating is handled in a single FixedUpdate call in the Manager).

The API's simple: __Start()__ zeros and runs the timer, __Stop()__ zeros and stops it, and __Pause()__ pauses and unpauses it. Timer length and looping can be set through public members, though I'm not really clear on whether or not this is considered kosher in C#, so that behavior might get moved to public methods.

## Potential issues
If you construct the timer in an __Awake()__ method, you might have to edit __Project Settings > Script Execution Order__ to make sure the TimerManager Awakes first. If you construct in __Start()__ there shouldn't be a problem.
