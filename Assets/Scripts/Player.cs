using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour
{
	/*public GameObject bulletPrefab;
	public float bulletForce = 500f;
	public float timeBetweenProjectile = 0.5f;*/

	//public float moveSpeed = 10f;
	public GameObject explosionPrefab;
	public float upwardsForce = 600f;

	private float _currentProjectileTime;
	private Rigidbody _rigidbody;

	private ParticleSystem _explosion;
	private MeshRenderer _renderer;

	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody> ();
		_renderer = GetComponent<MeshRenderer> ();

		var exp = (GameObject)Instantiate (explosionPrefab, transform.position, Quaternion.identity);
		exp.transform.SetParent (transform, true);
		_explosion = exp.GetComponent<ParticleSystem> ();
		//_explosion.startColor = GetComponent<Material> ().color;
	}

	// Update is called once per frame
	void Update ()
	{

		if (Input.anyKeyDown) {
			_rigidbody.isKinematic = false;

			_rigidbody.AddForce (Vector3.up * upwardsForce);
		}//var input = Input.GetAxis ("Vertical");

		//transform.Translate (new Vector3 (0, input * moveSpeed * Time.deltaTime, 0f), Space.World);

		/*_currentProjectileTime += Time.deltaTime;

		if (Input.GetKey (KeyCode.E) && _currentProjectileTime >= timeBetweenProjectile) {
			Shoot ();
			_currentProjectileTime = 0f;
		}*/
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Wall")) {
			_renderer.enabled = false;
			_explosion.Emit (100);
			StartCoroutine (Destroy ());
		}
	}

	private IEnumerator Destroy ()
	{
		yield return new WaitForSeconds (1.5f);
		Destroy (gameObject);
	}

/*	private void Shoot ()
	{
		var bullet = (GameObject)Instantiate (bulletPrefab, transform.position, Quaternion.identity);
		bullet.GetComponent<Rigidbody> ().AddForce (Vector3.right * bulletForce);
	}*/
}
