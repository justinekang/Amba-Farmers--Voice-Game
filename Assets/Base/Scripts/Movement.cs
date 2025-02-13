using UnityEngine;

public class Movement : MonoBehaviour
{
    public FloatReference move_speed;
    private Vector3 rotated;
    private void Awake()
    {
        rotated = new Vector3();
    }
    public void Move(Vector3 direction)
    {
        direction *= move_speed.Value * Time.deltaTime;
        transform.Translate(direction);
    }
    public void Move(Vector2 input, float cameraYangle)
    {
        DetermineMoveVector(input, cameraYangle);
        Move(rotated);
    }
    private void DetermineMoveVector(Vector2 input, float cameraYangle)
    {
        rotated.x = input.x;
        rotated.z = input.y;
        rotated.y = 0;
        rotated = Quaternion.Euler(0, cameraYangle, 0) * rotated;
    }
}
