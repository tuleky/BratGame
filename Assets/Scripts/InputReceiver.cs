using System;
using UnityEngine;

public class InputReceiver
{
	public Action<float> OnSlide;
	
	Vector2 _firstPress = Vector2.zero;

	float _currentVel;
	float _inputDifferenceX;
	
	public void OnUpdate()
	{
		if (Input.GetMouseButtonDown(0))
		{
			_firstPress = Input.mousePosition;
		}

		if (Input.GetMouseButton(0))
		{
			float mousePosX = Input.mousePosition.x;
			float inputDiffXClamped = Mathf.Clamp((mousePosX - _firstPress.x), -10f, 10f);
			_inputDifferenceX = Mathf.SmoothDamp(_inputDifferenceX, inputDiffXClamped / 5f, ref _currentVel, smoothTime: .2f);
			
			OnSlide.Invoke(_inputDifferenceX);

			_firstPress = Input.mousePosition;
		}

		if (Input.GetMouseButtonUp(0))
		{
			_inputDifferenceX = 0f;
			OnSlide.Invoke(0f);
		}
	}
}