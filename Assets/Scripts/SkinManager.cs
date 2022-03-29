using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public Sprite[] Icons; // icons array
    public Sprite[] AccelIcons; // icons array
    public Sprite[] HandlingIcons; // icons array
    public SpriteRenderer sr;
    public SpriteRenderer barSr;
    public SpriteRenderer handSr;
    private int selectedSkin = 0;
    public GameObject playerskin;
    // Start is called before the first frame update
    void Start()
    {
        LoadIcons();
        for(int i = 0; i < Icons.Length; i++){
            if(sr.sprite == Icons[i])
                selectedSkin = i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextOption(){
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == Icons.Length){ //Icons.Length
            selectedSkin = 0;
        }
        sr.sprite = Icons[selectedSkin];
        barSr.sprite = AccelIcons[selectedSkin];
        handSr.sprite = HandlingIcons[selectedSkin];
    }
    public void BackOption(){
        selectedSkin = selectedSkin - 1;
        if(selectedSkin < 0){
            selectedSkin = Icons.Length - 1;
        }
        sr.sprite = Icons[selectedSkin];
        barSr.sprite = AccelIcons[selectedSkin];
        handSr.sprite = HandlingIcons[selectedSkin];
    }
    void LoadIcons(){
        object[] loadedIcons = Resources.LoadAll ("CarIcons",typeof(Sprite)) ;
        object[] loadedAccelIcons = Resources.LoadAll ("Acceleration",typeof(Sprite)) ;
        object[] loadedHandIcons = Resources.LoadAll ("Handling",typeof(Sprite));
        HandlingIcons = new Sprite[loadedHandIcons.Length];
        AccelIcons = new Sprite[loadedAccelIcons.Length];
        Icons = new Sprite[loadedIcons.Length];
        for(int x = 0; x< loadedIcons.Length;x++){
        Icons [x] = (Sprite)loadedIcons [x];
        }
        for(int x = 0; x< loadedAccelIcons.Length;x++){
        AccelIcons [x] = (Sprite)loadedAccelIcons [x];
        }
        for(int x = 0; x< loadedHandIcons.Length;x++){
        HandlingIcons [x] = (Sprite)loadedHandIcons [x];
        }
    }

    public void PlayGame(){
        PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedskin.prefab");
        SceneManager.LoadScene("MapSelect");
    }

    public void BackMenu(){
        SceneManager.LoadScene("PlayerDetails");
    }
}
