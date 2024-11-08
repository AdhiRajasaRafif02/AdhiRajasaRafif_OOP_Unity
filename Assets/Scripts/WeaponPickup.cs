using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] private Weapon weaponHolder;  // Referensi ke prefab Weapon yang akan diambil Player
    private Weapon weapon;

    private void Awake()
    {
        // Tidak perlu menginisialisasi weapon langsung di sini karena kita akan menginstansiasinya nanti
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collision detected with: " + other.name); // Log untuk cek collision

        // Periksa apakah objek yang bersentuhan adalah Player
        if (other.CompareTag("Player"))
        {
            PickupWeapon(other.transform);
        }
    }

    private void PickupWeapon(Transform playerTransform)
    {
        if (weaponHolder != null) // Pastikan weaponHolder sudah diassign di Inspector
        {
            // Instansiasi weapon dari prefab weaponHolder ke dalam scene
            weapon = Instantiate(weaponHolder, playerTransform.position, Quaternion.identity);

            // Pindahkan weapon yang baru diinstansiasi ke Player dan atur sebagai child dari Player
            weapon.transform.SetParent(playerTransform);
            weapon.transform.localPosition = Vector3.zero;  // Atur posisi relatif weapon di Player

            weapon.EnableWeapon(true);  // Aktifkan weapon di tangan Player
            Debug.Log("Player picked up the weapon!");

            // Hancurkan atau nonaktifkan pickup setelah diambil
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("WeaponHolder is not assigned in the Inspector!");
        }
    }
}


