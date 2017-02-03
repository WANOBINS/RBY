using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] PlayerBrakes = new GameObject[3];
    public bool Sprinting = false;
    private float BaseSpeed = 10f;
    private Library.Facing Direction;
    private GameManager Manager;
    private Player P;
    private Rigidbody Rb;
    private float Speed;
    private float SprintModifier = 2f;

    // Use this for initialization
    private void Awake()
    { 
        print("Player code has awakened");
    }

    private void GetInput()
    {
        foreach (GameObject Object in PlayerBrakes)
        {
            Object.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            Manager.SetActive(Manager.RedPlayer);
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            Manager.SetActive(Manager.BluePlayer);
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            Manager.SetActive(Manager.YellowPlayer);
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            Speed = SprintModifier * BaseSpeed;
            Sprinting = true;
        }
        else
        {
            Speed = BaseSpeed;
            Sprinting = false;
        }
        if (Input.GetKey(KeyCode.W))
        {
            print("Up");
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);
            Direction.F = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            print("Down");
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);

            Direction.D = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("Left");
            //transform.position = new Vector3(transform.position.x - Speed, transform.position.y, transform.position.z);

            Direction.L = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("Right");
            //transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);

            Direction.R = true;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void Movement()
    {
        if (Direction.Cardinal())
        {
            if (Direction.D == true)
            {
                Rb.velocity = Vector3.back * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, 180, 0));
            }
            else if (Direction.R == true)
            {
                Rb.velocity = Vector3.right * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, 90, 0));
            }
            else if (Direction.L == true)
            {
                Rb.velocity = Vector3.left * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, -90, 0));
            }
            else if (Direction.F == true)
            {
                Rb.velocity = Vector3.forward * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, 0, 0));
            }
        }
        else if (Direction.Secondary())
        {
            if (Direction.D == true & Direction.R == true)
            {
                Rb.velocity = (Vector3.back + Vector3.right) * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, 135, 0));
            }
            else if (Direction.D == true & Direction.L)
            {
                Rb.velocity = (Vector3.back + Vector3.left) * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, -135, 0));
            }
            else if (Direction.F == true & Direction.L)
            {
                Rb.velocity = (Vector3.forward + Vector3.left) * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, -45, 0));
            }
            else if (Direction.F == true & Direction.R)
            {
                Rb.velocity = (Vector3.forward + Vector3.right) * Speed;
                P.gameObject.transform.rotation = (Quaternion.Euler(0, 45, 0));
            }
        }
    }

    private void Start()
    {
        Manager = FindObjectOfType<GameManager>();
        PlayerBrakes[0] = Manager.RedPlayer;
        PlayerBrakes[1] = Manager.BluePlayer;
        PlayerBrakes[2] = Manager.YellowPlayer;
    }

    // Update is called once per frame
    private void Update()
    {
        P = Manager.GetActivePlayer();
        Rb = P.GetComponent<Rigidbody>();
        Direction = new Library.Facing();
        GetInput();
        Movement();
    }
}