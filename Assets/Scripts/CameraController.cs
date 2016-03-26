using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class CameraController : MonoBehaviour
	{
		[SerializeField] private Transform followTarget = null;
		[SerializeField] private float smoothness = 1.0f;
		[SerializeField] private float speed = 20.0f;

		private void Update()
		{
			Transform transform = this.transform;

			Vector3 focusPos = this.followTarget.transform.position;
			Vector3 targetPos = focusPos - new Vector3(0.0f, 0.0f, 10);
			Vector3 posDiff = (targetPos - transform.position);
			Vector3 targetVelocity = posDiff * 0.1f * Mathf.Pow(2.0f, -this.smoothness);

			// Move the camera
			transform.position += (targetVelocity * speed * Time.deltaTime);
		}
	}
}
