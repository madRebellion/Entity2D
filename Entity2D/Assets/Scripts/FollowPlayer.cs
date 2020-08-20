using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform player;

    private void LateUpdate()
    {
        transform.position = player.position + new Vector3(0.0f, 0.0f, -10f);
    }
}
