using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board : MonoBehaviour
{
    public static GameObject[] players;
    public static GameObject[] diseases;
    GameObject _camera;
    GameObject particle;
    int currentPlayerID;
    public static Dictionary<string, GameObject> _positionMarkers = new Dictionary<string, GameObject>();
    public static List<string> _positionNames = new List<string>();

    bool turnOneDone = false;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        diseases = GameObject.FindGameObjectsWithTag("Disease");
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
        particle = GameObject.FindGameObjectWithTag("Cured");
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var disease in diseases)
        {
            if (disease.activeSelf == true)
            {
                if (disease.GetComponent<DiseaseCubes>().currentPosition == players[currentPlayerID].GetComponent<Player>().currentPosition)
                {
                    GameObject.FindGameObjectWithTag("PressEnter").GetComponent<Text>().text = "Press [Enter] to cure!";
                    break;
                }
            }
            else
            {
                GameObject.FindGameObjectWithTag("PressEnter").GetComponent<Text>().text = "Press [Space] to move!";
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            players[currentPlayerID].GetComponent<Player>().currentPosition = "Miami";
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            foreach (var disease in diseases)
            {
                if (disease.GetComponent<DiseaseCubes>().currentPosition == players[currentPlayerID].GetComponent<Player>().currentPosition)
                {
                    particle.SetActive (true);
                    disease.SetActive(false);
                    turnOneDone = true;
                }
            }
        } 

        _camera.transform.position = new Vector3(players[currentPlayerID].transform.position.x, players[currentPlayerID].transform.position.y, -10);
    }
}
