using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelChoose : MonoBehaviour {

    List<SkinnedMeshRenderer> headModels = new List<SkinnedMeshRenderer>();

    KeyCode leftRB, rightRB, aButton;

    public bool ready;

    int i;
    // Use this for initialization
    void Start () {
        i = 0;
    }

    private void OnEnable()
    {
        headModels.Add(transform.GetChild(0).gameObject.GetComponent<SkinnedMeshRenderer>());
        headModels.Add(transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>());
        headModels.Add(transform.GetChild(2).gameObject.GetComponent<SkinnedMeshRenderer>());
        headModels.Add(transform.GetChild(3).gameObject.GetComponent<SkinnedMeshRenderer>());

        PlayerInput();

        headModels[0].enabled = true;
        headModels[1].enabled = false;
        headModels[2].enabled = false;
        headModels[3].enabled = false;
    }
    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(rightRB))
        {
            headModels[i].enabled = false;
            if (i == headModels.Count - 1)
            {
                i = -1;
            }
            i++;
            headModels[i].enabled = true;

            AssignHeadModel();

        }
        else if (Input.GetKeyDown(leftRB))
        {
            headModels[i].enabled = false;
            if (i == 0)
            {
                i = headModels.Count;
            }
            i--;
            headModels[i].enabled = true;

            AssignHeadModel();
        }

	}

    void PlayerInput()
    {
        if (gameObject.name == "PlayerPick1")
        {
            leftRB = KeyCode.Joystick1Button4;
            rightRB = KeyCode.Joystick1Button5;
            aButton = KeyCode.Joystick1Button0;
        }
        else if (gameObject.name == "PlayerPick2")
        {
            leftRB = KeyCode.Joystick2Button4;
            rightRB = KeyCode.Joystick2Button5;
            aButton = KeyCode.Joystick2Button0;
        }
        else if (gameObject.name == "PlayerPick3")
        {
            leftRB = KeyCode.Joystick3Button4;
            rightRB = KeyCode.Joystick3Button5;
            aButton = KeyCode.Joystick3Button0;
        }
        else if (gameObject.name == "PlayerPick4")
        {
            leftRB = KeyCode.Joystick4Button4;
            rightRB = KeyCode.Joystick4Button5;
            aButton = KeyCode.Joystick4Button0;
        }
    }

    void AssignHeadModel()
    {
        if (gameObject.name == "PlayerPick1")
        {
            NewPlayerScript.p1HeadModel = i;
        }
        else if (gameObject.name == "PlayerPick2")
        {
            NewPlayerScript.p2HeadModel = i;
        }
        else if (gameObject.name == "PlayerPick3")
        {
            NewPlayerScript.p3HeadModel = i;
        }
        else if (gameObject.name == "PlayerPick4")
        {
            NewPlayerScript.p4HeadModel = i;
        }
    }
}
