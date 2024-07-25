using UnityEngine;
using Assets.Scripts.Variables;

namespace Assets.Scripts.Player
{
    public abstract class Character: MonoBehaviour
    {
        [SerializeField]
        protected Rigidbody2D characterRB;

        [SerializeField]
        protected float jumpForce;

        protected float gameSpeed = MovementVar.GAME_SPEED;
        
        protected readonly byte FORWARDS = 0;
        protected readonly byte UPWARDS = 1;
        protected readonly byte BACKWARDS = 2;
        protected readonly byte DOWNWARDS = 3;

        public abstract void Move( float amount, byte direction );
    }
}