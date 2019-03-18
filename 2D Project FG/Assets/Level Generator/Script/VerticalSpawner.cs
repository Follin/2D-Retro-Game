using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LeftorRight
{
    LEFT,
    RIGHT
}
public class VerticalSpawner : MonoBehaviour
{
    public LeftorRight VerticalDirection = LeftorRight.RIGHT;
    public float SpawnInterval = 1f;
    public float WhentoStartSpawn = 0f;
    public GameObject SpawnObject;
    public float SpeedofEnemy = 1f;

    private Vector3 Direction;

    void Start()
    {
        if (VerticalDirection == LeftorRight.RIGHT)
        {
            Direction = new Vector3(1, 0, 0);
        }
        else
        {
            Direction = new Vector3(-1, 0, 0);
        }
        InvokeRepeating("Spawner", WhentoStartSpawn, SpawnInterval);
    }
    void Spawner()
    {
        GameObject tempObject;
        if (VerticalDirection == LeftorRight.RIGHT)
        {
                tempObject = Instantiate(SpawnObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation,transform);
                tempObject.GetComponent<MovingEnemy>().Direction = Direction;
                tempObject.GetComponent<MovingEnemy>().Speed = SpeedofEnemy;         
        }
        if (VerticalDirection == LeftorRight.LEFT)
        {
                tempObject = Instantiate(SpawnObject, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation, transform);
                tempObject.GetComponent<MovingEnemy>().Direction = Direction;
                tempObject.GetComponent<MovingEnemy>().Speed = SpeedofEnemy;         
        }
    }

}
