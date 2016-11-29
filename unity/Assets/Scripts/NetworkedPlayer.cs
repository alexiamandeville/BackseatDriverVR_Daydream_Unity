using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NetworkedPlayer : Photon.MonoBehaviour
{
	public GameObject avatar;

	public Transform playerGlobal;
	public Transform playerLocal;

	void Start ()
	{
		if (photonView.isMine) {

			playerGlobal = GameObject.Find ("NetworkedPlayer").transform;
			playerLocal = GameObject.Find ("DriverPlayer/MainCamera").transform;


			this.transform.SetParent (playerLocal);
			//this.transform.localPosition = Vector3.zero;

			//avatar.SetActive(false);

		}
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
		{
			stream.SendNext(playerGlobal.position);
			stream.SendNext(playerGlobal.rotation);
			stream.SendNext(playerLocal.localPosition);
			stream.SendNext(playerLocal.localRotation);
		}
		else
		{
			this.transform.position = (Vector3)stream.ReceiveNext();
			this.transform.rotation = (Quaternion)stream.ReceiveNext();
			avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
			avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
		}
	}
}