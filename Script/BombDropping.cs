using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class BombDropping : NetworkBehaviour
{

    [SerializeField]
    private GameObject bombPrefab;
    
    public float bombCoolDown = 2f;
    private bool canDrop = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

            if (this.isLocalPlayer && Input.GetKeyDown("space"))
            {
                if (canDrop)
                {
                CmdDropBomb();
                StartCoroutine(coolDown(bombCoolDown));
                }
                
            }
          
       
    }
    [Command]
    void CmdDropBomb()
    {
        if (NetworkServer.active)
        {
            GameObject bomb = Instantiate(bombPrefab, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            NetworkServer.Spawn (bomb);
        }
    }
    public IEnumerator coolDown(float BombCoolDown)
    {
        canDrop = false;
        yield return new WaitForSeconds(BombCoolDown);
        canDrop = true;
    }
}
