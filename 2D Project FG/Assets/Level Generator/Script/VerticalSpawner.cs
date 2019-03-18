using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LeftorRight
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}
public class VerticalSpawner : MonoBehaviour
{
    public LeftorRight VerticalDirection = LeftorRight.RIGHT;
    public float SpawnInterval = 1f;
    public float WhentoStartSpawn = 0f;
    public GameObject SpawnObject;
    public float SpeedofEnemy = 1f;

    private bool CanSpawn = true;
    private Vector3 Direction;

    void Start()
    {
        if (VerticalDirection == LeftorRight.RIGHT)
        {
            Direction = new Vector3(1, 0, 0);
        }
        else if(VerticalDirection == LeftorRight.LEFT)
        {
            Direction = new Vector3(-1, 0, 0);
        }
        else if (VerticalDirection == LeftorRight.UP)
        {
            Direction = new Vector3(0, 1, 0);
        }
        else if (VerticalDirection == LeftorRight.DOWN)
        {
            Direction = new Vector3(0, -1, 0);
        }
        InvokeRepeating("Spawner", WhentoStartSpawn, SpawnInterval);
        if(SpawnObject == null)
        {
            Debug.Log("Object to spawn in:" + transform.name + "is currently null");
            CanSpawn = false;
        }
    }
    void Spawner()
    {
        GameObject tempObject;
       if(CanSpawn)
        { 
                tempObject = Instantiate(SpawnObject, transform.position, transform.rotation,transform);
                tempObject.GetComponent<MovingEnemy>().Direction = Direction;
                tempObject.GetComponent<MovingEnemy>().Speed = SpeedofEnemy;
            Destroy(tempObject, 20/SpeedofEnemy);
        }
    }

}
