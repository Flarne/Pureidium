using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
	[Tooltip("In m / s -1")] [SerializeField] float speed = 20f;
	[Tooltip("In m")] [SerializeField] float xRange = 18f;
	[Tooltip("In m")] [SerializeField] float yRange = 15f;

	[SerializeField] float positionPitchFactor = -2.3f;
	[SerializeField] float controlPitchFactor = -15f;
	[SerializeField] float positionYawFactor = 2.5f;
	[SerializeField] float controlRollFactor = -15f;

	float xThrow;
	float yThrow;
	float zThrow;

	void Start()
    {
        
    }
	
    void Update()
	{
		ProcessTranslation();
		ProcessRotation();
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

		float xOffset = xThrow * speed * Time.deltaTime;
		float yOffset = yThrow * speed * Time.deltaTime;

		float xRawPos = transform.localPosition.x + xOffset;
		float yRawPos = transform.localPosition.y + yOffset;

		float xMaxPos = Mathf.Clamp(xRawPos, -xRange, xRange);
		float yMaxPos = Mathf.Clamp(yRawPos, -yRange, yRange);

		transform.localPosition = new Vector3(xMaxPos, yMaxPos, transform.localPosition.z);
	}
}
