using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed=5f,_jumpHeight=20,_gravity=1;
    private float _yvelocity;
    private CharacterController _controller;
    [SerializeField]
    private GameObject _gun,_muzzleFlesh;
    [SerializeField]
    private GameObject _hitpoint;
    [SerializeField]
    public static  int coin=0;
    [SerializeField]
    private bool hasgun = false;
    // [SerializeField]
    public int score = 0, currentAmmo = 0;
    public static int _bestScore=0;
    private UIMAnager _uim;
    //  private UIManager2 _uiman;
    // Start is called before the first frame update
    
    void Start()

    {

       _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _uim = GameObject.Find("Canvas").GetComponent<UIMAnager>();
      //  _uiman = GameObject.Find("Canvas").GetComponent<UIMAnager2>();
        _bestScore = PlayerPrefs.GetInt("highscore", _bestScore);
        coin=PlayerPrefs.GetInt("coin", coin);
        if (_uim != null)
        {
            _uim.updateScore(score);
            _uim.updateCoin(coin);
            _uim.updateAmmmo(currentAmmo);
           // _uim.HighScore(_bestScore);
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
        movement();
        
        if (transform.position.y <= -1)
        {
            SceneManager.LoadScene(1);
        }
        score = ((int)transform.position.z)+50;
        if (_uim != null)
        {
            _uim.updateScore(score);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        if ((Input.GetMouseButtonDown(0)||/*CrossPlatformInputManager.GetButtonDown("fire"))&&*/ hasgun==true && currentAmmo>0)
        {
            currentAmmo--;
            _uim.updateAmmmo(currentAmmo);
            _muzzleFlesh.SetActive(true);
            Ray _rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitinfo;
            if(Physics.Raycast(_rayOrigin,out hitinfo))
            {
                Debug.Log("You hitted : " + hitinfo);
                Instantiate(_hitpoint, hitinfo.point, Quaternion.identity);
                if (hitinfo.transform.name == "Obstacles")
                {
                    Destroy(hitinfo.transform.gameObject);
                }
            }
        }
        else
        {
           
            _muzzleFlesh.SetActive(false);
        }
        if (currentAmmo == 0)
        {
            _gun.SetActive(false);
        }
        if (_bestScore <score)
        {
            _bestScore = score;
            PlayerPrefs.SetInt("highscore", _bestScore);
           //_uim.bestScore(_bestScore);
            Debug.Log(_bestScore);
        }
    }
    void movement()
    {
        float Hi = /*CrossPlatformInputManager.GetAxis("Horizontal"); */ Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(Hi, 0, 0);
        Vector3 velocity = direction * _speed; 
        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _yvelocity = _jumpHeight;
            }
        }
        else
        {
            _yvelocity -= _gravity;
        }
        velocity.y = _yvelocity;
        float mouseX = Input.GetAxis("Mouse X");//Input.GetAxis("Mouse X");
       // float mouseY = Input.GetAxis("Mouse Y");

        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y + mouseX, transform.localEulerAngles.z);


        _controller.Move(velocity * Time.deltaTime);
        transform.Translate(Vector3.forward * Time.deltaTime * _speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Gun")
        {
            _gun.SetActive(true);
            hasgun = true;
            currentAmmo = 15;
            _uim.updateAmmmo(currentAmmo);
        }
        if (other.tag == "coin")
        {
            Destroy(other.gameObject);
            coin++;
            PlayerPrefs.SetInt("coin", coin);
            _uim.updateCoin(coin);
        }
    }
}
