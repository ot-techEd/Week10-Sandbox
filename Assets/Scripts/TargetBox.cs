using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBox : ShootableBox
{
	[SerializeField] private Transform targetParent;

	[SerializeField] private Collider randomTargetArea;

	[SerializeField] private float movedistance = 2.0f;
	[SerializeField] private float moveSpeed = 2.0f;


	private Rigidbody targetRb;
	private Vector3 startPosition;
	private bool isWaiting = false;

    private void Start()
    {
		targetRb = GetComponent<Rigidbody>();
		startPosition = targetRb.position;
    }
    public override void Damage(int damageAmount)
	{
		if(isWaiting) { return; }
		StartCoroutine(ChangePosition());
	}


	IEnumerator ChangePosition()
    {
		isWaiting = true;

		yield return new WaitForSeconds(.2f);
		MoveToPosition();
    }

	void MoveToPosition()
    {
		Debug.Log("Moving to new position");
		targetParent.position = GenerateRandomPosition();
		isWaiting = false;
	}

	Vector3 GenerateRandomPosition()
    {
		float z = Random.Range(randomTargetArea.bounds.min.z, randomTargetArea.bounds.max.z);
		float y = Random.Range(randomTargetArea.bounds.min.y, randomTargetArea.bounds.max.y);

		Vector3 randomPosition = new Vector3(targetParent.position.x, y, z);

		return randomPosition;
	}


    private void Update()
    {
		transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, Mathf.PingPong(Time.time, movedistance));
    }
}
