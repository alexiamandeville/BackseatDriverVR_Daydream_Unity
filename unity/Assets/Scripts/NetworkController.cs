using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviour
{
	string _room = "backseatDriver";

	public GameObject myCam;

	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");

	}

	void OnJoinedLobby()
	{

		RoomOptions roomOptions = new RoomOptions() { };
		PhotonNetwork.JoinOrCreateRoom(_room, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{

			//myPosition = GameObject.Find ("PassengerSeat");
			 PhotonNetwork.Instantiate ("NetworkedPlayer", myCam.transform.position, Quaternion.identity, 0);

	}
}