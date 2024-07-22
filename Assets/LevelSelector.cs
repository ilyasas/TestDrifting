using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LoadLobby(string name)
    {
        LobbyManager.levelChoice = name;
        SceneManager.LoadScene("lobby");
    }

}
