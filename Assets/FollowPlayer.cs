using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    public Transform Player;
    public Camera Camera;
    public LineRenderer line;
    public Vector3 cameraOffset;
    
    private readonly float smoothFactor = 1f;

    public float rotationSpeedHor = 5f;

    //CursorLockMode cursorLock;
    public float rotationSpeedVert = 5f;

    // Use this for initialization
    void Start () {
        cameraOffset = transform.position - Player.position;
        /*Cursor.lockState = cursorLock;
        Cursor.visible = false;*/
        Quaternion camTurnAngleVert = Quaternion.AngleAxis(-4f, Vector3.left);
        cameraOffset = camTurnAngleVert * cameraOffset;
    }

    private void OnMouseDown()
    {
        /*Cursor.lockState = cursorLock;
        Cursor.visible = false;*/
    }

    private void OnMouseEnter()
    {
        /*Cursor.lockState = cursorLock;
        Cursor.visible = false;*/
    }

    void LateUpdate () {
        Quaternion camTurnAngleHor = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotationSpeedHor, Vector3.up);
        cameraOffset = camTurnAngleHor * cameraOffset;

        Vector3 newPos = Player.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);

        transform.LookAt(Player);
	}
}
