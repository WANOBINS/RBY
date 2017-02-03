using UnityEngine;

public class Library : MonoBehaviour
{
    public class Facing
    {
        public bool D;
        public bool F;
        public bool L;
        public bool R;

        public Facing()
        {
            F = L = R = D = false;
        }

        public Facing Zero
        {
            get
            {
                return new Facing();
            }
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
}