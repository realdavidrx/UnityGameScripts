using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public CinemachineVirtualCamera camera;
    public Transform respawnPoint;
    public GameObject playerPrefab;
    

    private void Awake() {
        instance = this;
        
    }
    public void Respawn () {
        GameObject Player = Instantiate(playerPrefab, respawnPoint.position, Quaternion.identity);
        camera.Follow = Player.transform;
}
}

