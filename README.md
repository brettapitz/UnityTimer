# UnityTimer
A simple timer implementation in Unity

## Usage
Place TimerManager.cs on a GameObject in your Scene and pass a callback function to __timer.timeOut.AddListener()__

## Design
A new Timer adds itself to TimerManager.Singleton, which updates all timers in a single Update call. A Stopped timer is removed from the manager.

To keep removal quick, instead of List.Remove, the index is nulled and added to a stack of free indices. The Add method checks for free slots before pushing to the List.

Not inheriting from MonoBehaviour means no OnDestroy or OnDisable method, so looping Timers have to be explicitly stopped by their callers or they'll run forever.

The API's simple: __Start()__ runs the timer, or zeros it if it's already running, __Stop()__ stops it.
