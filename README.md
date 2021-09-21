# Navmesh AI Tutorial 30 - NavMeshes on Moving and Rotating Platforms

In this tutorial repository you will learn how to make NavMeshes with Moving and Rotating Platforms that are traversable by NavMeshAgents. This is officially unsupported and comes with some limitations on how it can work.

This is a continuation of AI Series Part 28 where we first implemented Moving Platforms. Visit that GitHub Repository here: https://github.com/llamacademy/ai-series-part-28 and the YouTube Video explaining the initial implementation of the Moving Platform and the limitations and drawbacks in depth here: https://youtu.be/qLckTZ2E1JA

Some highlights are:
* The NavMeshAgent must move faster than the platform or they are unable to walk on the platform as it moves.
* Stutter can occur if the Agent's acceleration is not fast enough for the platform.
* If no movement is required while the platform is moving, using Agent.Warp is a generally more stable solution.
* AI using the platforms requires additional logic to go to "boarding points" since there is no complete path to the platforms unless they're docked.

Watch the video below for full explanation of what's going on here and discussion on the drawbacks and limitations of moving platforms.

[![Youtube Tutorial](./Video%20Screenshot.png)](https://www.youtube.com/watch?v=bcIfaTHdW94)

## Patreon Supporters
Have you been getting value out of these tutorials? Do you believe in LlamAcademy's mission of helping everyone make their game dev dream become a reality? Consider becoming a Patreon supporter and get your name added to this list, as well as other cool perks.
Head over to https://patreon.com/llamacademy to show your support.

### Gold Tier Supporters
* YOUR NAME HERE!

### Silver Tier Supporters
* Raphael
* Andrew Bowen
* YOUR NAME HERE!

### Bronze Tier Supporters
* Bastian
* Jacob Martin
* Trey Briggs
* AudemKay
* YOUR NAME HERE!

## Other Projects
Interested in other AI Topics in Unity, or other tutorials on Unity in general? 

* [Check out the LlamAcademy YouTube Channel](https://youtube.com/c/LlamAcademy)!
* [Check out the LlamAcademy GitHub for more projects](https://github.com/llamacademy)

## Requirements
* Requires Unity 2019.4 LTS or higher. 
* Utilizes the [Navmesh Components](https://github.com/Unity-Technologies/NavMeshComponents) from Unity's Github.