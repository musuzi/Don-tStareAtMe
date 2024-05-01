using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    public Camera mainCamera;
    public Vector2 playerMousePoint;

    // Update is called once per frame
    void Update()
    {
        playerMousePoint = GetPlayerPosDirection();
    }

    public Vector2 GetPlayerPosDirection()
    {
        Vector3 playerPosition = transform.position;
        Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;
        direction.Normalize();
        return direction;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, mainCamera.ScreenToWorldPoint(Input.mousePosition));
    }
}
