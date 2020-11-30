using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int rows;
    public int cols;
    public Room[,] rooms;
    public Room[,] roomTemplate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GenerateMap()
    {
        //for every row that needs to be created
        for (int currentRow= 0; currentRow < rows; currentRow++) { 
        //for every col that needs to be created
        for(int currentCol = 0; currentCol < cols; currentCol++) {
                //create a new random room
                //GameObject tempRoom = Instantiate(GetRandomRoom().gameObject, Vector3.zero, Quaternion.identity) as GameObject;
            //move the room and put it in the right space

            //save that room in the correct location in the array
            //open the apporptiate doors for that room
        }
        }
    }
    //public Room GetRandomRoom()
    //{
    //    int randomNumber = Random.Range(0, roomTemplate.Length);
    //    return roomTemplate[randomNumber];
    //}
}
