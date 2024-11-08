using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public PlayerMovement playerMovement;
    public Animator animator;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of Player exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Retrieve PlayerMovement and Animator components
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        // Call Move method from PlayerMovement
        playerMovement.Move();
    }

    private void LateUpdate()
    {
        // Set animator's IsMoving parameter based on movement state
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }

    public void EquipWeapon(Weapon weapon)
{
    // Misalnya, tambahkan weapon di depan player
    weapon.transform.SetParent(this.transform);
    weapon.transform.localPosition = new Vector3(0, 1, 0); // Adjust posisi sesuai keinginan
    weapon.gameObject.SetActive(true); // Tampilkan senjata
}

}