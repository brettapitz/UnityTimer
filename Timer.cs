using UnityEngine.Events;

public class Timer
{
	public UnityEvent timeOut = new UnityEvent();
	public float length = 1;
	public bool loop;
	public bool isRunning = false;
	public float currentTime = 0;

	public Timer(float lengthInSeconds, bool shouldLoop) {
		length = lengthInSeconds;
		loop = shouldLoop;
		TimerManager.Singleton.Add(this);
	}

	public void Start() {
		currentTime = 0;
		isRunning = true;
	}

	public void Stop() {
		currentTime = 0;
		isRunning = false;
	}

	public void Pause() {
		isRunning = !isRunning;
	}
}