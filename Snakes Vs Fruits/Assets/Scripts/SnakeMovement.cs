using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float steerSpeed = 100f;
    public int bodyParts;
    public List<GameObject> BodyParts = new List<GameObject>();
    private List<Vector3> Pos_History = new List<Vector3>();
    public GameObject BodyPrefab;
    public GameObject TailPrefab;
    public int gap = 10;
    public float BodySpeed = 5f;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        GrowSnake();
        //bodyParts = BodyParts.Count;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;

        float SteerDir = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * SteerDir * steerSpeed * Time.deltaTime);

        Pos_History.Insert(0,transform.position);

        int index = 0;
        foreach(var body in BodyParts)
        {
            Vector3 point = Pos_History[Mathf.Min(index * gap,Pos_History.Count-1)];
            Vector3 move_Dir = point - body.transform.position;
            Vector3 smoothMove = Vector3.Lerp(body.transform.position,move_Dir,BodySpeed);
            body.transform.position += move_Dir * BodySpeed * Time.deltaTime;
            body.transform.LookAt(point);
            index++;
        }
    }

    public void GrowSnake()
    {
        GameObject body = Instantiate(BodyPrefab);
        BodyParts.Add(body);
        body.transform.SetParent(parent);   
    }
}
