using UnityEngine.Events;

public class Timer {
	public float length = 1;
	public bool loop = false;
	public UnityEvent timeOut = new UnityEvent();
	public float currentTime = 0;
	public bool isRunning;

	int managerIndex;

	public Timer(float l) {
		length = l;
	}

	public void Start() {
		currentTime = 0;
		if (isRunning) return;

		managerIndex = TimerManager.Singleton.Add(this);
		isRunning = true;
	}

	public void Stop() {
		if (!isRunning) return;
		TimerManager.Singleton.Remove(managerIndex);
		isRunning = false;
	}

	public float Progress() {
		return currentTime / length;
	}
}