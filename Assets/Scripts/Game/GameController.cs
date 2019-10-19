using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameController : MonoBehaviour
{
    [SerializeField]List<int>listapuntos;
    [SerializeField]Text[] puntajes;
    [SerializeField]Text texttoclone;
    [SerializeField] Text textposition;
    [SerializeField] GameController gameController;
    [SerializeField] GameObject ganador;
    [SerializeField] Text spawnerwinnertext;
    
    [SerializeField] Text textoganador;
    [SerializeField]int tagmaximo;
    GameObject[] puntuaciontext;
    GameObject[] textosgo;
    GameObject[] textos;
    [SerializeField]GameObject[] puntosgo;
    [SerializeField]GameObject[] players;
    [SerializeField] GameObject objetoainstanciar;
    [SerializeField] GameObject powerSpawner1;
    [SerializeField] GameObject powerSpawner2;
    [SerializeField]List<string> resultados;
    [SerializeField]int c;

    public delegate void OnTaggedChange(string newTagged);

    public event OnTaggedChange onTaggedChange;

    [SerializeField]
    private float playTime;

    [SerializeField]
    private int playerCount;

    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]Canvas canvas;

    [SerializeField]
    private bool instantiateHumanPlayer = true;
    Vector3 cambio;
    private Dictionary<string, int> taggedScore = new Dictionary<string, int>();

    public int PlayerCount { get => playerCount; set => playerCount = value; }
  

    public string GetWinner()
    {
        return string.Empty;
    }

    // Start is called before the first frame update
    private void Start()
    {
       

        for (int i = 0; i < 2; i++)
        {
            Vector3 positionSp1 = new Vector3(Random.Range(-40, 40), 1.5f, Random.Range(-40, 40));
            Vector3 positionSp2 = new Vector3(Random.Range(-40, 40), 1.5f, Random.Range(-40, 40));
            GameObject sp1Instance1 = Instantiate(powerSpawner1, positionSp1, Quaternion.identity);
            GameObject sp1Instance2 = Instantiate(powerSpawner2, positionSp2, Quaternion.identity);
        }
        
        cambio = textposition.transform.position;
        onTaggedChange += UpdateTaggedScore;

        taggedScore.Clear();
        for( int i =0; i < PlayerCount; i++)
        {
            Text textinstance = Instantiate(texttoclone, textposition.transform.position, textposition.transform.rotation);
            textinstance.transform.SetParent(canvas.transform, false);
            textinstance.transform.position = cambio;
            cambio = cambio + new Vector3(0, -15, 0);
            
        }

        for (int i = 0; i < PlayerCount; i++)
        {
            string prefabPath = i == 0 && instantiateHumanPlayer ? "HumanPlayer" : "AIPlayer";
            Vector3 position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            GameObject playerInstance = Instantiate(objetoainstanciar,position,Quaternion.identity);
            
            playerInstance.name = string.Format("Player{0}", i + 1);


            taggedScore.Add(playerInstance.name, 0);
        }

        players = GameObject.FindGameObjectsWithTag("Player");
        int random = Random.Range(0, players.Length);

        for (int i = 0; i < PlayerCount; i++)
        {
            players[random].GetComponent<AIController>().IsTagged = true;
            players[random].GetComponent<HumanController>().IsTagged = true;
        }

        
    }
    private void Update()
    {
        playTime += Time.deltaTime;
        {
            if (playTime >= 25)
            {
                playTime = 0;
                EndGame();
                
            }
        }
        
        if (c >= playerCount)
        {
            c = playerCount;
        }
       

        textosgo = GameObject.FindGameObjectsWithTag("Player");
        textos = GameObject.FindGameObjectsWithTag("nameP");
        puntuaciontext = GameObject.FindGameObjectsWithTag("puntuacion");
        playerCount = textosgo.Length;

        if (c < playerCount)
        {
            foreach (var v in taggedScore)
            {

                resultados.Add(v.Value.ToString());
                
            }

        }
        for (int i = 0; i < gameController.PlayerCount; i++)
        {
            textos[i].GetComponent<Text>().text = textosgo[i].name;
            puntuaciontext[i].GetComponent<Text>().text = textosgo[i].GetComponent<PlayerController>().taggedscore.ToString();
            c++;

        }
       

    }

    private void EndGame()
    {
        puntosgo = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject go in puntosgo)
        {
            listapuntos.Add(go.GetComponent<PlayerController>().taggedscore);
        }
       
        
        tagmaximo = listapuntos.Min();
        for (int i = 0; i < gameController.PlayerCount; i++)
        {
            if(puntosgo[i].GetComponent<PlayerController>().taggedscore == tagmaximo)
            {
                ganador = puntosgo[i];
            }
            
        }
        Text instanciatextoganador = Instantiate(textoganador, spawnerwinnertext.transform.position, spawnerwinnertext.transform.rotation);
        instanciatextoganador.transform.SetParent(canvas.transform, false);
        instanciatextoganador.transform.position = spawnerwinnertext.transform.position;
        instanciatextoganador.text = "el ganador es" +ganador.name;
    }
    private void AsignarTag()
    {

    }

    public void UpdateTaggedScore(string newTaggedPlayer)
    {
        taggedScore[newTaggedPlayer] += 1;
    }
}