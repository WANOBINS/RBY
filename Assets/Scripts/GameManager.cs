using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject ActivePlayer;
    public GameObject BluePlayer;
    public GameObject RedPlayer;
    public GameObject YellowPlayer;

    public bool REnter = false;
    public bool BEnter = false;
    public bool YEnter = false;

    public GameObject GetActiveGameObject()
    {
        return ActivePlayer;
    }

    public Player GetActivePlayer()
    {
        return ActivePlayer.GetComponent<Player>();
    }

    public void SetActive(Player P)
    {
        ActivePlayer = P.gameObject;
    }

    public void SetActive(GameObject G)
    {
        ActivePlayer = G;
    }

    // Use this for initialization
    private void Awake()
    {
        RedPlayer = GameObject.FindGameObjectWithTag("Red");
        BluePlayer = GameObject.FindGameObjectWithTag("Blue");
        YellowPlayer = GameObject.FindGameObjectWithTag("Yellow");
        ActivePlayer = RedPlayer;
    }

    // Update is called once per frame
    private void Update()
    {


    }

    void OnTriggerEnter(Collider aCol)
    {
        if(aCol.tag.Equals("Red"))
        {
            print("Red has entered!");
            REnter = true;
        }

        if (aCol.tag.Equals("Blue"))
        {
            print("Blue has entered!");
            BEnter = true;
        }

        if (aCol.tag.Equals("Yellow"))
        {
            print("Yellow has entered!");
            YEnter = true;
        }

        if (REnter == true && BEnter == true && YEnter == true)
        {
            SceneManager.LoadScene(2);
        }
    }

    void OnTriggerExit(Collider aCol)
    {
        if (aCol.tag.Equals("Red"))
        {
            print("Red has left!");
            REnter = false;
        }

        if (aCol.tag.Equals("Blue"))
        {
            print("Blue has left!");
            BEnter = false;
        }

        if (aCol.tag.Equals("Yellow"))
        {
            print("Yellow has left!");
            YEnter = false;
        }
    }
}