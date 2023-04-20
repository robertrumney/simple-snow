# Simple Snow

This is an experimental Unity script that generates snowflakes using primitive spheres instead of particles. It was created as an exercise in out-of-the-box thinking and is not intended for use in production.

## How it works

The `Snow` script generates snowflakes at a specified interval and location within a certain range. Each snowflake is represented by a sphere game object with a rigidbody component added to it, which makes it fall downwards due to gravity. The snowflake size, count, range, and generation interval can be set through public variables in the Unity editor.

In addition to generating the snowflakes, this script also adds a random delay between the generation of each snowflake, which creates a more natural-looking snowfall effect. The delay is determined by a random float value between 0 and 0.1, generated using the `Random.Range` method.

The script also gets a reference to the player's `Transform` component in the `Start` method, which is used to set the initial position of the snowflakes relative to the player.
