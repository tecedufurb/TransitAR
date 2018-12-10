using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    private Transform[] targets;
    public Transform target;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private System.Random random = new System.Random();

    void Start() {
        targets = target.GetComponentsInChildren<Transform>();
        shuffle(targets);
        agent = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement
        // between points (ie, the agent doesn't slow down as it
        // approaches a destination point).
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint() {
        // Returns if no points have been set up
        if (targets.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = targets[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % targets.Length;
    }


    void Update() {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void shuffle(Transform[] targets) {
        for (int i = 0; i < targets.Length; i++) {
            int r = random.Next(0,targets.Length);

            Transform temp = targets[i];
            targets[i] = targets[r];
            targets[r] = temp;
        }
    }
}