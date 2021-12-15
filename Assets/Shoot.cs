using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	public int AmmoCount; //Патронов в обоймах
	public int CurAmmo; //Кол-во патроеов
	public int Ammo; //Кол-во патронов в 1ой обойме
	public AudioClip Fire; // Звук выстрела
	public float ShootSpeed; // Скорострельность
	public float ReloadSpeed; // Скорость Перезарядки
	public AudioClip Reload; // Звук перезарядки
	public float ReloadTimer = 0.0f; // Время перезарядки(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ)
	public float ShootTimer = 0.0f; // Время выстрела(НЕ ТРОГАТЬ|НЕ МЕНЯТЬ
	public Transform bullet; // Патрон
							 // Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetMouseButton(0) & CurAmmo > 0 & ReloadTimer <= 0 & ShootTimer <= 0)
		{
			Transform BulletInstance = (Transform)Instantiate(bullet, GameObject.Find("Spawn").transform.position, Quaternion.Euler(new Vector3(0, 0, 0))) ;
			BulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * 5000);
			CurAmmo = CurAmmo - 1;
			GetComponent<AudioSource>().PlayOneShot(Fire);
			ShootTimer = ShootSpeed;
		}
		if (ShootTimer > 0)
		{
			ShootTimer -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.R))
		{
			ReloadTimer = ReloadSpeed;
			CurAmmo = Ammo;
			GetComponent<AudioSource>().PlayOneShot(Reload);
			{
				if (ShootTimer > 0)
				{
					ShootTimer -= Time.deltaTime;
				}
			}
		}

		if (ReloadTimer > 0)
		{
			ReloadTimer -= Time.deltaTime;
		}
	}
}