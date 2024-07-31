using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatientAi : MonoBehaviour
{
    public Patient patient;
    private NavMeshAgent agent;
    public Animation Door;
    public Transform ChairSide;
    bool DoorAnimState = false;
    int target = 0;

    Vector3 DoorFront;
    Vector3 DoorBack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        DoorFront = new Vector3(Door.transform.position.x - 2, Door.transform.position.y, Door.transform.position.z - 2);
        DoorBack = new Vector3(Door.transform.position.x, Door.transform.position.y, Door.transform.position.z + 5);
    }

    void SwitchDoorAnimations()
    {
        Door.Play("Door" + (DoorAnimState ? "Close" : "Open"));
        DoorAnimState = !DoorAnimState;
    }

    public void RoomEnter()
    {
        agent.isStopped = false;
        agent.SetDestination(DoorFront);
        target = 1;
    }
    public void RoomLeave()
    {
        patient.pppm.gameObject.SetActive(false);
        agent.isStopped = false;
        agent.SetDestination(ChairSide.position);
        target = 5;
    }

    void Update()
    {
        if (agent.destination != null && agent.remainingDistance <= 0)
        {
            switch (target)
            {
                // Enter room
                case 1:
                    SwitchDoorAnimations();
                    agent.SetDestination(DoorBack);
                    target++;
                    break;
                case 2:
                    SwitchDoorAnimations();
                    agent.SetDestination(ChairSide.position);
                    target++;
                    break;
                case 3:
                    Debug.Log("Sit");
                    patient.pppm.gameObject.SetActive(true);
                    patient.pppm.FillLabels(patient);
                    agent.isStopped = true;
                    agent.transform.rotation = Quaternion.LookRotation(ChairSide.forward);
                    target++;
                    break;
                // leave room
                case 5:
                    Debug.Log("Stand up");
                    target++;
                    break;
                case 6:
                    agent.SetDestination(new Vector3(Door.transform.position.x - 4, Door.transform.position.y, Door.transform.position.z + 5));
                    target++;
                    break;
                case 7:
                    SwitchDoorAnimations();
                    agent.SetDestination(DoorFront);
                    target++;
                    break;
                case 8:
                    SwitchDoorAnimations();
                    Debug.Log("Patient left");
                    agent.SetDestination(new Vector3(Door.transform.position.x - 4, Door.transform.position.y, Door.transform.position.z - 10));
                    target++;
                    break;
                case 9:
                    patient.DestroyPatient();
                    target++;
                    break;
            }
        }

        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     RoomEnter();
        // }
        // if (Input.GetKeyDown(KeyCode.V))
        // {
        //     RoomLeave();
        // }
    }
}
