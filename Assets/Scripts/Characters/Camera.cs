using UnityEngine;
using Assets.Scripts.Player;
using Unity.VisualScripting;

public class Camera : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private float playerOffset;

    // Update is called once per frame
    void Update()
    {
        if ( ! player.IsDestroyed() )
        {
            this.transform.position = new Vector3( player.position.x + playerOffset, this.transform.position.y, -10);
        }
    }
}