using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstacle1;
    [SerializeField] private GameObject obstacle2;
    [SerializeField] private GameObject obstacle3;
    [SerializeField] private GameObject obstacle4;
    [SerializeField] private GameObject obstacle5;
    [SerializeField] private GameObject obstacle6;
    [SerializeField] private float heightShift;
    [SerializeField] private float wait;
    
    private float timer;
    int randNum;
    float randHeight;
    Vector2 position;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer > wait)
        {
            //randomize which obstacle to generate
            randNum = (int) UnityEngine.Random.Range(1, 7); //max exclusive

            //randomize height within bounds
            randHeight = UnityEngine.Random.Range(-heightShift, heightShift);

            //create the object
            if(randNum == 1)
            {
                position = new Vector2(obstacle1.transform.position.x, obstacle1.transform.position.y + randHeight);
                Instantiate(obstacle1, position, Quaternion.identity);
            }
            else if(randNum == 2)
            {
                position = new Vector2(obstacle2.transform.position.x, obstacle2.transform.position.y + randHeight);
                Instantiate(obstacle2, position, Quaternion.identity);
            }
            else if(randNum == 3)
            {
                position = new Vector2(obstacle3.transform.position.x, obstacle3.transform.position.y + randHeight);
                Instantiate(obstacle3, position, Quaternion.identity);
            }
            else if(randNum == 4)
            {
                position = new Vector2(obstacle4.transform.position.x, obstacle4.transform.position.y + randHeight);
                Instantiate(obstacle4, position, Quaternion.identity);
            }
            else if(randNum == 5)
            {
                position = new Vector2(obstacle5.transform.position.x, obstacle5.transform.position.y + randHeight);
                Instantiate(obstacle5, position, Quaternion.identity);
            }
            else
            {
                position = new Vector2(obstacle6.transform.position.x, obstacle6.transform.position.y + randHeight);
                Instantiate(obstacle6, position, Quaternion.identity);
            }

            //reset timer -- according to api, subtracting is better than setting 0
            timer -= wait;
        }
    }
}
