using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject Player;
    public Transform pivot;
    public Vector3 offset;
    public float smoothSpeed = .1f;
    public bool IsCustomOffset;

    // Start is called before the first frame update
    void Start()
    {
        if(!IsCustomOffset)
        {
            offset = pivot.position - Player.transform.position;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.position = Player.transform.position + offset;
        Vector3 smoothFollow = Vector3.Lerp(pivot.transform.position,Player.transform.position ,smoothSpeed);

        pivot.transform.position = smoothFollow;

    }
}
