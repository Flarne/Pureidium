using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
	[Header ("Genral")]
	[Tooltip("In m / s -1")] [SerializeField] float controlSpeed = 20f;
	[Tooltip("In m")] [SerializeField] float xRange = 18f;
	[Tooltip("In m")] [SerializeField] float yRange = 15f;

	[Header("Screen-Position Based")]
	[SerializeField] float positionPitchFactor = -1f;
	[SerializeField] float positionYawFactor = 1f;

	[Header("Control-trow Based")]
	[SerializeField] float controlRollFactor = -10f;
	[SerializeField] float controlPitchFactor = -10f;

	float xThrow;
	float yThrow;
	//float zThrow;

	bool isControlEnabled = true;

	void Update()
	{
		if (isControlEnabled)
		{
			ProcessTranslation();
			ProcessRotation();
		}
	}

	void OnPlayerDeath() // called by string reference
	{
		isControlEnabled = false;
	}

	private void ProcessRotation()
	{
		float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
		float pitchDueToControlThrow = yThrow * controlPitchFactor;

		float yaw = transform.localPosition.x * positionYawFactor;

		float roll = xThrow * controlRollFactor;

		float pitch = pitchDueToPosition + pitchDueToControlThrow;
		
		transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
	}

	private void ProcessTranslation()
	{
		xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		yThrow = CrossPlatformInputManager.GetAxis("Vertical");

		float xOffset = xThrow * controlSpeed * Time.deltaTime;
		float yOffset = yThrow * controlSpeed * Time.deltaTime;

		float xRawPos = transform.localPosition.x + xOffset;
		float yRawPos = transform.localPosition.y + yOffset;

		float xMaxPos = Mathf.Clamp(xRawPos, -xRange, xRange);
		float yMaxPos = Mathf.Clamp(yRawPos, -yRange, yRange);

		transform.localPosition = new Vector3(xMaxPos, yMaxPos, transform.localPosition.z);
	}
}
