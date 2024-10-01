using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;

	private Vector3 movement;
	private Vector2 moveInput;

	private Animator anim;
	private int id_walking = Animator.StringToHash("IsWalking");

	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;



	void Awake()
	{
		StaticInputMap.Input.Player.Enable();
		StaticInputMap.Input.Player.Movement.performed += MoveInput;
		StaticInputMap.Input.Player.Movement.canceled += MoveInput;

		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		Move(moveInput.x, moveInput.y);
		Turning();
		Animating(moveInput.x, moveInput.y);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition(transform.position + movement);
	}

	void MoveInput(InputAction.CallbackContext ctx)
	{
		moveInput = ctx.ReadValue<Vector2>();

		if (ctx.canceled)
			moveInput = Vector2.zero;
	}

	void Turning()
	{
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;

		if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool(id_walking, walking);
	}
}
