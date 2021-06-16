using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehaviour : MonoBehaviour
{
    private const float Grid_Move_Timer_Max = 1f;

    private Vector2Int gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;

    // Start is called before the first frame update
    private void Start()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimer = Grid_Move_Timer_Max;
        gridMoveDirection = Vector2Int.up;
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (v > 0)
            gridMoveDirection = Vector2Int.up;
        else if (v < 0)
            gridMoveDirection = Vector2Int.down;
        else if (h > 0)
            gridMoveDirection = Vector2Int.right;
        else if (h < 0)
            gridMoveDirection = Vector2Int.left;

        gridMoveTimer += Time.deltaTime;

        if (gridMoveTimer >= Grid_Move_Timer_Max)
        {
            gridPosition += gridMoveDirection;
            gridMoveTimer -= Grid_Move_Timer_Max;
        }

        transform.position = new Vector2(gridPosition.x, gridPosition.y);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection) - 90);
    }

    private float GetAngleFromVector(Vector2Int dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
