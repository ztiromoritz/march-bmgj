using UnityEngine;
using System.Collections;


namespace BerlinJam
{
	public class Ship : MonoBehaviour
	{
		[SerializeField] private float speed = 1.0f;
		[SerializeField] private float acceleration = 1.0f;
		[SerializeField] private Bullet bulletPrefab = null;
		[SerializeField] private float bulletDelay = 0.2f;
		[SerializeField] private float bulletSpeed = 10.0f;


		private float bulletTimer = 0.0f;

		private void Update()
		{
			Transform transform = this.transform;
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();

			// Rotate
			Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
			Vector2 mousePos = Input.mousePosition;
			Vector2 lookDir = mousePos - screenPos;
			float targetAngle = lookDir.GetAngle() + 90 * Mathf.Deg2Rad;
			body.angularVelocity = 0.0f;
			body.MoveRotation(Mathf.Rad2Deg * targetAngle);

			// Move
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
			Vector2 targetVelocity = targetDir * this.speed;
			Vector2 force = (targetVelocity - body.velocity) * this.acceleration;

			body.AddForce(force * body.mass);

			// Fire
			this.bulletTimer -= Time.deltaTime;
			if (Input.GetMouseButton(0))
			{
				if (this.bulletTimer <= 0.0f)
				{
					this.LaunchBullet();
					this.bulletTimer = this.bulletDelay;
				}
			}
		}

		private void LaunchBullet()
		{
			Rigidbody2D body = this.GetComponent<Rigidbody2D>();

			Vector2 pos = this.transform.position;
			Vector2 dir = this.transform.right;
			Vector2 velocity = dir * this.bulletSpeed + body.velocity;

			Bullet bullet = GameObject.Instantiate<Bullet>(this.bulletPrefab);
			Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
			bullet.transform.position = pos;
			bullet.transform.up = velocity.normalized;
			bullet.Source = this.gameObject;
			bulletBody.velocity = velocity;
		}
	}
}
