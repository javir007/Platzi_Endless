﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public static LevelManager Instance { set; get; }

    public List<GameObject> tiles = new List<GameObject>();
    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float titleLength = 6f;
    private int amnTiles = 20;
    private float safeZone = 15.0f;
    private int lastTileIndex;

    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnTile(int prefabIndex = -1){
        GameObject go;
        if(prefabIndex == -1){
            go = Instantiate(tiles[0]) as GameObject;
        }else{
            go = Instantiate(tiles[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += titleLength;
        activeTiles.Add(go);

    }
}