using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 originalPosition;
    private float originalSpeed;
    public float brzina = 3f;
    float limit;
    public Animation animation;

    private bool isDay = true;

    public Light directionalLight;

    void Start()
    {
        limit = brzina;
        originalPosition = transform.position;
        originalSpeed = brzina;
    }

    public void Reset()
    {
        transform.position = originalPosition;
        brzina = originalSpeed; // Dodato: Vrati brzinu na originalnu vrednost
    }

    public void SetSpeed(float newSpeed)
    {
        brzina = newSpeed;
        Debug.Log("New speed set: " + brzina);
    }

    void Update()
    {
        if (GameManager.gameState == GameManager.GameState.running)
        {
            int direction = GetInput();
            Move(direction);

            if (Input.GetKeyDown(KeyCode.N))
            {
                ToggleDayNight();
            }


            if (Input.GetKeyDown(KeyCode.M))
            {
                ChangeLightColor(Color.white);
            }




        }
    }

    public int GetInput()
    {
        int direction = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            direction = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            direction = 1;

        return direction;
    }

    private void Move(int dir)
    {
        float posX = transform.position.x + dir * brzina * Time.deltaTime;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }

    public void PlayAnimation()
    {
        animation.Play();
    }

    public void StopAnimation()
    {
        animation.Stop();
    }


    void ToggleDayNight()
    {
        isDay = !isDay;

        ChangeDayNight(isDay);

        if (isDay)
        {
            ChangeLightColor(Color.blue);
        }
        else
        {
            ChangeLightColor(Color.green);
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            ChangeLightColor(Color.white);
        }
    }

    void ChangeDayNight(bool isDay)
    {
    }

    void ChangeLightColor(Color color)
    {
        if (directionalLight != null)
        {
            directionalLight.color = color;
        }
    }
}
