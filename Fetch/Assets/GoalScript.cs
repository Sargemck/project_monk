using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour {

    public GameObject victoryText;

    void OnCollisionEnter2D(Collision2D colInfo)
    {
        //Debug.Log(colInfo.relativeVelocity.magnitude);
        Debug.Log("Level Won!");
        victoryText.SetActive(true);
    }
}
