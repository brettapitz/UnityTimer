using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
	public float length = 1;
	public bool loop = false;
	public bool startOnEnable = false;

	[HideInInspector]
	public UnityEvent timeOut = new UnityEvent();
	[HideInInspector]
	public bool isRunning = false;
	[HideInInspector]
	public float currentTime = 0;

	void Start() {
		TimerManager.Singleton.Add(this);
	}

	public void Run() {
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

	void OnEnable() {
		if (startOnEnable) Run();
	}
	void OnDisable() {
		if (loop) Stop();
	}
}