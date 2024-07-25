using UnityEngine;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Player;
using UnityEngine.Events;


public class Player : Character, IMortal
{

    [SerializeField]
    UnityEvent gameOver;
    
    [SerializeField]
    UnityEvent incrementScore;

    private void Start() {
        Move( jumpForce, UPWARDS );
    }

    private void Update()
    {
        if (characterRB != null)
        {
            if ( Input.GetKeyDown( KeyCode.Space ) || Input.GetKeyDown( KeyCode.Mouse0 ) ){
                Move( jumpForce, UPWARDS );
            }

            Move( gameSpeed, FORWARDS );
        }
    }

    public override void Move( float amount, byte direction )
    {
        if ( direction == UPWARDS )
        {
            characterRB.velocity = new Vector2( characterRB.velocity.x, jumpForce );
        }
        else if ( direction == FORWARDS )
        {
            characterRB.velocity = new Vector2( gameSpeed, characterRB.velocity.y );
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
        if ( collision.gameObject.CompareTag( "Obstacle" ) )
        {
            Die();
        }
        
    }

    private void OnTriggerExit2D(Collider2D trigger) {
        if ( trigger.gameObject.CompareTag( "Score" ) )
        {
            IncrementScore();
        }
    }
    public void Die()
    {
        Destroy( gameObject, 0.7f );
        gameOver?.Invoke();
    }

    private void IncrementScore()
    {
        incrementScore?.Invoke();
    }

}
