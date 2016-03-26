using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class ShipController : MonoBehaviour
	{
		[SerializeField] private float speed = 1.0f;
		[SerializeField] private float acceleration = 1.0f;

		private void Update()
		{
			Transform transform = this.transform;
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();

			Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
			Vector2 mousePos = Input.mousePosition;
			Vector2 lookDir = mousePos - screenPos;
			float targetAngle = (Mathf.PI * 4 + Mathf.Atan2(lookDir.y, lookDir.x) - Mathf.PI * 0.5f) % (Mathf.PI * 2);
			float currentAngle = transform.eulerAngles.z * Mathf.Deg2Rad;
			float turnDirection = Mathf.MoveTowardsAngle(currentAngle, targetAngle, 1.0f) - currentAngle;
			float turnLength = Mathf.DeltaAngle(currentAngle, targetAngle);
			//float targetAngleRatio = 1.0f;
			//float maxTurnSpeed = 1.0f;
			//float turnPower = 1.0f;
			//float turnSpeedRatio = Mathf.Min(turnLength * 0.25f, Mathf.Deg2Rad * 30.0f) / (Mathf.Deg2Rad * 30.0f);
			//float turnVelocity = turnSpeedRatio * turnDirection * maxTurnSpeed * targetAngleRatio;
			//float angularVelocityChange = (turnVelocity - body.angularVelocity) * turnPower;
			//body.AddTorque(angularVelocityChange, ForceMode2D.Impulse);
			transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * targetAngle);

			Vector2 targetDir = Vector2.zero;
			if (Input.GetKey(KeyCode.W))
				targetDir += Vector2.up;
			if (Input.GetKey(KeyCode.S))
				targetDir -= Vector2.up;
			if (Input.GetKey(KeyCode.A))
				targetDir -= Vector2.right;
			if (Input.GetKey(KeyCode.D))
				targetDir += Vector2.right;

			targetDir /= Mathf.Max(targetDir.magnitude, 1.0f);
			Vector2 targetVelocity = targetDir * speed;
			Vector2 force = (targetVelocity - body.velocity) * acceleration;

			body.AddForce(force * body.mass);
		}
	}
}
