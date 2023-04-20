using System.Collections;
using UnityEngine;

public class Snow : MonoBehaviour
{
    public int snowflakeCount = 100; // the number of snowflakes to generate
    public float snowflakeSize = 0.1f; // the size of each snowflake
    public float snowflakeRange = 10f; // the range within which to generate snowflakes
    public float generationInterval = 1f; // the interval at which to generate snowflakes

    private Transform player;

    void Start()
    {
        // start generating snowflakes at the specified interval
        StartCoroutine(GenerateSnowflakes());
        player = Game.instance.player.transform;
    }

    IEnumerator GenerateSnowflakes()
    {
        // create a loop that generates snowflakes at the specified interval
        while (true)
        {
            // wait for the specified interval before generating snowflakes
            //yield return new WaitForSeconds(generationInterval);

            // generate snowflakes
            for (int i = 0; i < snowflakeCount; i++)
            {
                // create a snowflake game object
                GameObject snowflake = GameObject.CreatePrimitive(PrimitiveType.Sphere);

                // set the snowflake's position to a random position within the specified range
                snowflake.transform.position = player.transform.position + (Vector3.up*5) + new Vector3(Random.Range(-snowflakeRange, snowflakeRange), snowflakeRange, Random.Range(-snowflakeRange, snowflakeRange));

                // set the snowflake's scale to the specified size
                snowflake.transform.localScale = Vector3.one * snowflakeSize;

                // add a rigidbody component to the snowflake and freeze its rotation
                Rigidbody rb = snowflake.AddComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.FreezeRotation;

                // add a falling force to the snowflake
                rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);

                float r = Random.Range(0.000f, 0.100f);

                yield return new WaitForSeconds(r);
            }
        }
    }
}
