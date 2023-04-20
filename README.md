# Simple Snow

This is an experimental Unity script that generates snowflakes using primitive spheres instead of particles. It was created as an exercise in out-of-the-box thinking and is not intended for use in production.

## How it works

The `Snow` script generates snowflakes at a specified interval and location within a certain range. Each snowflake is represented by a sphere game object with a rigidbody component added to it, which makes it fall downwards due to gravity. The snowflake size, count, range, and generation interval can be set through public variables in the Unity editor.

In addition to generating the snowflakes, this script also adds a random delay between the generation of each snowflake, which creates a more natural-looking snowfall effect. The delay is determined by a random float value between 0 and 0.1, generated using the `Random.Range` method.

The script also gets a reference to the player's `Transform` component in the `Start` method, which is used to set the initial position of the snowflakes relative to the player.

## Installation

To use this script, simply copy the code below and paste it into a new C# script file in your Unity project. Alternatively, you can create a new script file in Unity and copy and paste the code there.

```csharp
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
