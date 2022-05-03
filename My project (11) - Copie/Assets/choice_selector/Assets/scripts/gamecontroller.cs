using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//to add list 
using UnityEngine.SceneManagement;

public class gamecontroller : MonoBehaviour

{   
    [SerializeField]
    private Sprite bg;// arriere plan de chaque carte
    public Sprite[] puzzles;//images des cartes tournantes 
    public List<Sprite> gamepuzzles = new List<Sprite>();// les references qu'on va creer des images dans une liste
    public List<Button> btns = new List<Button>();//listes des boutons 
    private bool firstguess,secondguess;// chacun des deux premiers choix 
    private int countguesses,countcorrectguesses,gameguesses;
    private string firstguesspuzzle,secondguesspuzzle;// les noms des deux cartes choisies 
    private int firstguessindex , secondguessindex;// l'indice de bouttons choisies 
    public string  scenename ;
    [SerializeField] public string nextlevel ; 
    [SerializeField] public string retrylevel ;
    public static int score ; 
    float currenttime =0;
    [SerializeField] public float startingtime;
    [SerializeField] Text counttext ; 
    [SerializeField] Text scoretext ;
    [SerializeField] string path ;

    void Update()
    {
        CheckIfTheGameIsFinished();
        currenttime -= 1* Time.deltaTime ;
        counttext.text = currenttime.ToString("0");
        if (currenttime<=0){
            currenttime=0;
        }
        
    }
    
    
    void Awake(){
        puzzles = Resources.LoadAll<Sprite> (path);// l'importation des images 
    }
   
   
    void Start(){
        GetButtons();
        AddListeners();// appliquer des fcts de scripts aux boutons
        AddGamePuzzles();
        Shuffle(gamepuzzles);// rendre les images random 
        gameguesses=gamepuzzles.Count ;// ici 12 images et 6 guesses
        score=0;
        currenttime = startingtime;
    }
    
    
    void GetButtons(){
        GameObject[] objects = GameObject.FindGameObjectsWithTag("puzzlebutton");//un tabeau de bouttons a partir de tagname
        for(int i=0;i<objects.Length;i++){
            btns.Add(objects[i].GetComponent<Button>());//notre liste va etre remplies 
            btns[i].image.sprite = bg;// to change background of all buttons 
        }
    }
    
    
    void AddGamePuzzles(){
        int index =0;
        for (int i=0; i<btns.Count ;i++){// puisque chaque image va etre dupliquée 
            if (index == (btns.Count) / 2){
                index = 0;
            }
            gamepuzzles.Add(puzzles[index]);
            index++;
        }
    }
    
    
    
    void AddListeners(){
        // to add function to a button
        for(int i=0;i<btns.Count;i++){
            btns[i].onClick.AddListener(() => PickAPuzzle());}
        
        

    }
    
    
    public void PickAPuzzle(){
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;// nom du boutton selectionné
        Debug.Log("click button named " +name);
        if(!firstguess){
            firstguess=true;
            firstguessindex=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);// rendre un entier 
            firstguesspuzzle=gamepuzzles[firstguessindex].name;// nom de l'image du bouton selectionné
            btns[firstguessindex].image.sprite = gamepuzzles[firstguessindex];


        }
        else if(!secondguess){
            secondguess=true;
            secondguessindex=int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondguesspuzzle=gamepuzzles[secondguessindex].name;
            btns[secondguessindex].image.sprite = gamepuzzles[secondguessindex];
            countguesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
            if((firstguesspuzzle == secondguesspuzzle) && (firstguessindex != secondguessindex)){
                Debug.Log("the puzzles match");
                
            }
            else {
                Debug.Log("the puzzles don't match");

            }

        }

    }
    
    
    
    IEnumerator CheckIfThePuzzlesMatch(){
        yield return new WaitForSeconds(1f);
        if((firstguesspuzzle == secondguesspuzzle )&& (firstguessindex != secondguessindex)){
            score++;
            scoretext.text = score.ToString()+"/"+((btns.Count) / 2).ToString();
            countcorrectguesses++;
            CheckIfTheGameIsFinished();
            yield return new WaitForSeconds(.5f);
            btns[firstguessindex].interactable = false;// stoper les boutons correctes choisis 
            btns[secondguessindex].interactable = false; 
            btns[firstguessindex].image.color = new Color (0,0,0,0);// les rendres invisibles 
            btns[secondguessindex].image.color = new Color (0,0,0,0);
            CheckIfTheGameIsFinished();}
        else {
            btns [firstguessindex].image.sprite= bg;// s'ils ne sont pas correct les tourner (changer en bg)
            btns [secondguessindex].image.sprite = bg;
            

        }
        yield return new WaitForSeconds(.5f);
        firstguess = secondguess =false;

        

        }


    
    
    
    void CheckIfTheGameIsFinished(){
        if (((btns.Count) / 2) == countcorrectguesses){
            if((score == ((btns.Count) / 2)) && (currenttime > 0) ){
            Debug.Log("game finished");
            LoadScene(nextlevel);}
            else {
                if (currenttime == 0){
                    LoadScene(retrylevel);
                }
            }
        }
        else {
            if((score != ((btns.Count) / 2)) && (currenttime <= 0)){
                Debug.Log("gameover");
                LoadScene(retrylevel);
            }

        } 
    }
           
        
        
           

    
        
            
            

        

    
    
    
    
    
    void Shuffle (List<Sprite> list){// rendre les images aleatoires 
        for (int i=0; i<list.Count ;i++){
            Sprite tem = list[i];
            int randomindex = Random.Range(i,list.Count);
            list[i]=list[randomindex];
            list[randomindex]=tem;

        }

    }
    public void LoadScene(string scenename){
      SceneManager.LoadScene(scenename);
  }

}
