using UnityEngine;

public class Player : MonoBehaviour
{
    private Facing Direction;
    private float BaseSpeed = 3f;
    private float Speed;
    private float SprintModifier = 2f;
    public bool Sprinting = false;

    // Use this for initialization
    private void Awake()
    {
        print("Player code has awakened");
    }

    // Update is called once per frame
    private void Update()
    {
        Direction = new Facing();
        Movement();
        Rotation();
    }

    public class Facing
    {
        public bool F;
        public bool L;
        public bool R;
        public bool D;

        public Facing()
        {
            F = L = R = D = false;
        }

        public bool Cardinal()
        {
            if (F & D)
            {
                F = D = false;
            }
            if (L & R)
            {
                L = R = false;
            }
            if ((F == true ^ L == true) ^ (R == true ^ D == true))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Secondary()
        {
            if (((F == true & L == true) ^ (F == true & R == true)) ^ ((D == true & L == true) ^ (D == true & R == true)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void Movement()
    {
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
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);
            Direction.F = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            print("Down");
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);
            Direction.D = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            print("Left");
            transform.position = new Vector3(transform.position.x - Speed, transform.position.y, transform.position.z);
            Direction.L = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            print("Right");
            transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
            Direction.R = true;
        }
    }

    private void Rotation()
    {
        if (Direction.Cardinal())
        {
            if (Direction.D == true)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, 0, 0));
            }
            else if (Direction.R == true)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, -90, 0));
            }
            else if (Direction.L == true)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, 90, 0));
            }
            else if (Direction.F == true)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, 180, 0));
            }
        }
        else if (Direction.Secondary())
        {
            if (Direction.D == true & Direction.R == true)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, -45, 0));
            }
            else if (Direction.D == true & Direction.L)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, 45, 0));
            }
            else if (Direction.F == true & Direction.L)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, 135, 0));
            }
            else if (Direction.F == true & Direction.R)
            {
                gameObject.transform.rotation = (Quaternion.Euler(0, -135, 0));
            }
        }
    }
}