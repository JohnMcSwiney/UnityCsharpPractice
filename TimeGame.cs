using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGame : MonoBehaviour
{
    float roundStartDelayTime = 1;
    float roundStartTime;
    int waitTime;
    bool roundStarted;
    // Start is called before the first frame update
    void Start()
    {
        print("Press the spacebar once you think the allotted time is up.");
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && roundStarted)
        {
           InputReceieved();

        }
    }
    void InputReceieved()
    {
        roundStarted = false;
        float playerWaitTime = Time.time - roundStartTime;
        float error = Mathf.Abs(waitTime - playerWaitTime);

        print("you waitied for " + playerWaitTime + " seconds... That's " + error + " seconds off. " + GenerateMessage(error));
        Invoke("SetNewRandomTime", roundStartDelayTime);
    }
    string GenerateMessage (float error)
    {
        string message = "";

        if (error < .15f)
        {
            message = "Outstanding!";
        }
        else if (error < .75f)
        {
            message = "Exceeds Expectations.";
        }
        else if (error < 1.25f)
        {
            message = "Acceptable.";
        }
        else if (error < 1.75f)
        {
            message = "Poor";
        }
        else
        {
            message = "Dreadful";
        }
        return message;
    }
    void SetNewRandomTime()
    {
        waitTime = Random.Range(5, 21);
        roundStartTime = Time.time;
        roundStarted = true;
        print(waitTime + " seconds");
    }
}
