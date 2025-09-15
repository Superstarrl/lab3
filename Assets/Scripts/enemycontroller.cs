using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    GameObject player;
    Transform playerTransform;

    float speed = 1f;          // tied to distance each frame
    Vector2 lastTangent;       // remembers tangent
    bool hasLastTangent = false;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    void Update()
    {
        Vector2 r = playerTransform.position - transform.position;
        if (r.sqrMagnitude < 1e-6f) return;

        // face player
        transform.up = r;

        OrbitPlayer(r);
    }

    void OrbitPlayer(Vector2 r)
    {
        float distance = r.magnitude;
        speed = distance; // proportional to distance

        Vector2 rHat = r / distance;

        // two possible tangents
        Vector2 t1 = new Vector2(-rHat.y, rHat.x);
        Vector2 t2 = -t1;

        // pick the one closest to previous to avoid flipping
        Vector2 tHat;
        if (!hasLastTangent)
        {
            tHat = t1; // initial choice
            hasLastTangent = true;
        }
        else
        {
            tHat = (Vector2.Dot(t1, lastTangent) >= 0f) ? t1 : t2;
        }

        transform.position += (Vector3)(tHat * speed * Time.deltaTime);
        lastTangent = tHat;
    }
}
