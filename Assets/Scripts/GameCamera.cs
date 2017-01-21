using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    private void Update()
    {
        gameObject.transform.position = new Vector3((player.transform.position.x), gameObject.transform.position.y, player.transform.position.z);
    }
}