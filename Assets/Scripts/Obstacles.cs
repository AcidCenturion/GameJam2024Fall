using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] public float longevity;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * -1 * Time.deltaTime * speed);

        Destroy(this.gameObject, longevity);
    }
}
