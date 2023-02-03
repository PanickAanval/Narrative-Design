using UnityEngine;

public class CutsceneTrigger : MonoBehaviour
{
    public GameObject Timeline;
    public GameObject ShadowFriend;
    public GameObject Breathing;
    public GameObject Player;

    void Start()
    {
        Timeline.SetActive(false);
    }
    
    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.name == "PlayerCapsule")
        {
            Debug.Log("Collision");
            Timeline.SetActive(true);
            Breathing.SetActive(false);
        }

    }

}
