using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Bot : MonoBehaviour
{
    [SerializeField] float timeBetweenMoves;
    [SerializeField] bool isActive;

    Ring myRing;
    GameObject sphere;

    private void Start()
    {
        myRing = GetComponent<Ring>();
        sphere = GameObject.Find("Sphere");

        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (isActive)
        {
            if (transform.position.y < sphere.transform.position.y)
            {
                if (transform.position.x < sphere.transform.position.x)
                {
                    myRing.MoveRight();
                }
                else
                {
                    myRing.MoveLeft();
                }
            }
            yield return new WaitForSeconds(timeBetweenMoves);
        }
    }

    public void ChangeActive(bool newActive)
    {
        isActive = newActive;
        StopAllCoroutines();
        StartCoroutine(Move());
    }
}
