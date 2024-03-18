/*Name: Aythan Pao
 * Date: 1-19-24
 * Desc: Stopgap solution to reenable spikes
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManagerScript : MonoBehaviour
{
    public PlayerCollisionWithEnemyScript PCES;
    // gameobject child spike
    public GameObject spike;

    // Update is called once per frame
    void Update()
    {
        // if the player dies, the spikes become active again
        if (PCES != null && PCES.reset == true)
        {
            spike.SetActive(true);
        }
    }
}
