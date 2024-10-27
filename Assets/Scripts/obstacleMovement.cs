using UnityEngine;

public class obstacleMovement : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * -1 * Time.deltaTime * speed);
    }
}
