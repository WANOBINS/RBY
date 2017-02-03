using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Player player;
    private GameManager Manager;

    private void Start()
    {
        Manager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        player = Manager.GetActivePlayer();
        gameObject.transform.position = new Vector3((player.transform.position.x), gameObject.transform.position.y, player.transform.position.z);
    }
}