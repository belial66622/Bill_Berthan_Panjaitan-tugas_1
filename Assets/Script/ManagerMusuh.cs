using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;


public class ManagerMusuh : MonoBehaviour
{
    public GameObject nyawa;
    [SerializeField]
    public List<GameObject> tipe;
    [SerializeField]
    private List<GameObject> spawner;
    public int level = 0 , nyawaa;
    int jlhmusuh,musuh_habis,ikena,ilewat;
    float Spawnspeed,spawn,istirahat;
    public Text tlevel,tkena, tlewat ,Fatal;
    public GameObject spawnpos , button;
    public bool fatal;

    // Start is called before the first frame update
    void Start()
    {

        nyawaa = 3;
        fatal = false;
        level = 0;
        CheckWave();
        istirahat = 5f;
        tkena.text = "Kena " + ikena;
        tlewat.text = "Lewat " + ilewat;
    }

    // Update is called once per frame
    void Update()
    {
        if (nyawaa == 0)
        { kalah(); }
        if (fatal == true)
        { }
        else if (Spawnspeed > 0 && jlhmusuh > 0)
        { Spawnspeed -= Time.deltaTime; }
        else if (Spawnspeed <= 0 && jlhmusuh > 0)
            spawnenemies();
        else if (musuh_habis == 0)
        {
            if (istirahat > 0)
            {
                istirahat -= Time.deltaTime;
            }

            else
                CheckWave();
        }

        
    }

    void CheckWave()
    {
        level += 1;
        tlevel.text = "Wave " + level.ToString();
        jlhmusuh = level + 10;
        musuh_habis = jlhmusuh;
        Spawnspeed = 2 - (level/20);
        if (Spawnspeed <= 0.2f)
            Spawnspeed = 0.2f;
        spawn = Spawnspeed;
        istirahat = 5f;
    }

    void spawnenemies()
    {

        int randomIndex = Random.Range(0, tipe.Count);

        GameObject Klon = Instantiate(tipe[randomIndex], new Vector3(Random.RandomRange(spawnpos.transform.position.x-8, spawnpos.transform.position.x + 8), spawnpos.transform.position.y, tipe[randomIndex].transform.position.z), Quaternion.identity,transform);
        Klon.SetActive(true);

        spawner.Add(Klon);
        jlhmusuh -= 1;
        Spawnspeed = spawn;
    }

    public void hancur(GameObject pencet)
    {

        musuh_habis -= 1;
        ikena += 1;
        tkena.text = "Kena " + ikena.ToString();
        spawner.Remove(pencet);
        Destroy(pencet);
    }
    public void lewat(GameObject pencet)
    {

        musuh_habis -= 1;
        ilewat += 1;
        tlewat.text = "Lewat " + ilewat.ToString();
        spawner.Remove(pencet);
        Destroy(pencet);
        nyawa.transform.GetChild(3-nyawaa).GetComponent<SpriteShapeRenderer>().color = Color.black;
        nyawaa -= 1;
    }

    public void mlewat(GameObject pencet)
    {

        musuh_habis -= 1;
        ilewat += 1;
        tlewat.text = "Lewat " + ilewat.ToString();
        spawner.Remove(pencet);
        Destroy(pencet);
    }

    public void mSalah(GameObject pencet)
    {

        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        tlewat.text = "Fatal!!!";
        tkena.text = "Fatal!!!";
        tlevel.text = "Fatal!!!";
        Fatal.enabled = true;
        fatal = true;
        button.SetActive(true);
        spawner.Remove(pencet);
        Destroy(pencet);
        
    }


    public void kalah()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }

        Fatal.enabled = true;
        Fatal.text = "Game Over !!";
        fatal = true;
        button.SetActive(true);

    }

    public void reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
