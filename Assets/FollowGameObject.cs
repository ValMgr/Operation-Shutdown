using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour {
    public GameObject m_objectToFollow;
	
	void Update () {
        this.transform.position = new Vector3(m_objectToFollow.transform.position.x + 350f, 192f, this.transform.position.z);
	}
}
