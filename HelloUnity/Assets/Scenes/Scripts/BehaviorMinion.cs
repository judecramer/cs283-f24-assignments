using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using BTAI;
using System;
using System.Diagnostics;

public class WanderMinion : MonoBehaviour
{
    public Transform wanderRange;  // Set to a sphere
    public Transform home;
    private Root m_btRoot = BT.Root();

    void Start()
    {
        BTNode goHome = BT.RunCoroutine(MoveToHome);
        BTNode moveTo = BT.RunCoroutine(MoveToRandom);

        Sequence sequence = BT.Sequence();
        sequence.OpenBranch(moveTo, goHome);

        m_btRoot.OpenBranch(sequence);
    }

    void Update()
    {
        m_btRoot.Tick();
    }

    IEnumerator<BTState> MoveToRandom()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        Vector3 target;
        if (RandomPoint(wanderRange.position, wanderRange.localScale.x, out target)) //this fails every other call. don't know why
        {
            agent.SetDestination(target);
        }

        // wait for agent to reach destination
        while (agent.remainingDistance > 0.1f)
        {
            yield return BTState.Continue;
        }

        yield return BTState.Success;
    }

    IEnumerator<BTState> MoveToHome()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();

        Vector3 target = home.position;

        agent.SetDestination(target);

        // wait for agent to reach destination
        while (agent.remainingDistance > 0.1f)
        {
            yield return BTState.Continue;
        }

        yield return BTState.Success;
    }


    //code source: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;

    }
}