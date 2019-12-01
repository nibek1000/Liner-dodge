using UnityEngine;

public class EndColider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.FindGameObjectWithTag("go").transform.position = GameObject.FindGameObjectWithTag("zz").transform.position;
    }
    
}
