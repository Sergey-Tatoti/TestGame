using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float damping;
	[SerializeField] private Vector2 offset;

	public bool faceLeft;
	private int lastX;

	void Start ()
	{
		offset = new Vector2(Mathf.Abs(offset.x), offset.y);
		FindPlayer(faceLeft);
	}

	public void FindPlayer(bool playerFaceLeft)
	{
		lastX = Mathf.RoundToInt(_player.transform.position.x);

		if(playerFaceLeft)
			transform.position = new Vector3(_player.transform.position.x - offset.x, _player.transform.position.y + offset.y, transform.position.z);
		else
			transform.position = new Vector3(_player.transform.position.x + offset.x, _player.transform.position.y + offset.y, transform.position.z);
	}

	void Update () 
	{
		if(_player.transform)
		{
            Vector3 target;
			int currentX = Mathf.RoundToInt(_player.transform.position.x);

			if(currentX > lastX) 
            faceLeft = false; 
            else if(currentX < lastX) 
            faceLeft = true;
			
            lastX = Mathf.RoundToInt(_player.transform.position.x);

			if(faceLeft)
				target = new Vector3(_player.transform.position.x - offset.x, _player.transform.position.y + offset.y, transform.position.z);
			else
				target = new Vector3(_player.transform.position.x + offset.x, _player.transform.position.y + offset.y, transform.position.z);

			Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
			transform.position = currentPosition;
		}
	}
}
