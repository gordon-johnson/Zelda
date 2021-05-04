using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	public static GameControl instance;
	public GameObject gameOverScreen;
	public bool gameOver = false;
    public float gridSize = 0.5f;
    public Vector3 playerStartingPosition;
    public Vector3 cameraStartingPosition;
    int resModifier = 3;

    public GameObject particleEffect;

    public GameObject player;

    public Color mindControlColor;
    public Color startingColor;

    private Dictionary<int, RoomController> rooms;
    public int currentRoomX;
    public int currentRoomY;

    public Image mainHandWeapon;

    public Sprite startingMainHandWeapon;

    private string CustomLevel;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else if (instance != this)
		{
			Destroy(gameObject);
		}
        CustomLevel = "CustomLevel";
        //Screen.fullScreen = false;
        Screen.SetResolution(256 * resModifier, 250 * resModifier, true);
	}

    private void Start()
    {
        startingMainHandWeapon = mainHandWeapon.sprite;
        rooms = new Dictionary<int, RoomController>();
        cameraStartingPosition = Camera.main.transform.position;
        RoomController[] getRooms = GetComponentsInChildren<RoomController>();
        for(int i = 0; i < getRooms.Length; i++)
        {
            rooms.Add(getRooms[i].roomId, getRooms[i]);
        }
    }

    void Update()
	{
		if (gameOver)
		{
			Debug.Log("game over: press enter to restart");
		}
		if (gameOver == true && Input.GetKeyDown(KeyCode.Return))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.F))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.G))
        {
            resModifier += 1;
            Screen.SetResolution(256 * resModifier, 250 * resModifier, Screen.fullScreen);
        }
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.H))
        {
            resModifier -= 1;
            Screen.SetResolution(256 * resModifier, 250 * resModifier, Screen.fullScreen);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene(CustomLevel);
        }
    }

	public void PlayerDied()
	{
		gameOverScreen.SetActive(true);
		gameOver = true;
	}
}
