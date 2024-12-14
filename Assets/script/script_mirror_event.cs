using UnityEngine;

public class script_mirror_event : MonoBehaviour
{
    private GameObject bullet;
    public Material Mirror_break;
    public GameObject Mirror;
    public GameObject reflectionProb;

    public int matnb = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bullet = GameObject.FindWithTag("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.CompareTag("Bullet")) {
            reflectionProb.SetActive(false);
            Mirror.GetComponent<mirror_script>().enabled = false;
            if (Mirror.GetComponent<MeshRenderer>().materials.Length > 1) {
                Material[] materials = Mirror.GetComponent<MeshRenderer>().materials;
                materials[matnb] = Mirror_break;
                Mirror.GetComponent<MeshRenderer>().materials = materials;
            } else
                Mirror.GetComponent<MeshRenderer>().material = Mirror_break;
        }
    }
}
