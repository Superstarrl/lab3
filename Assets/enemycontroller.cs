using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class enemycontroller : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;

    float speed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
        speed = 1; //make tied to distance later
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = playerTransform.position - transform.position;
        //Quaternion rotation = Quaternion.LookRotation(playerTransform.position - transform.position, transform.TransformDirection(Vector3.up));
        //transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blueViolet;
        Gizmos.DrawRay(transform.position, transform.up);
    }

}
