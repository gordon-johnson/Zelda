using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour
{

    private List<GameObject> enemies;
    public bool dropKeyOnFinish;
    public Vector3 keyDropPosition;
    public int roomId;
    public GameObject key;
    private bool keyDropped;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>();
        keyDropped = false;
        Health[] getEnemies = GetComponentsInChildren<Health>();
        Debug.Log("Found " + getEnemies.Length + " enemies in room " + roomId);
        for(int i = 0; i < getEnemies.Length; i++)
        {
            enemies.Add(getEnemies[i].gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dropKeyOnFinish && !keyDropped)
        {
            bool allDead = true;
            foreach(GameObject enemy in enemies)
            {
                if (enemy.active)
                {
                    allDead = false;
                }
            }
            if (allDead)
            {
                keyDropped = true;
                Instantiate(key, keyDropPosition, Quaternion.identity);
            }
        }
    }
}
