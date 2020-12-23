using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using TMPro;

public class PokemonAPIController : MonoBehaviour
{
    public GameObject imagen;
    public GameObject texto;
    public Texture2D texture;

    private readonly string basePokeURL1 = "https://pokeapi.co/api/v2/";
    void Start()
    {
        texto.GetComponent<TextMeshPro>().SetText("Mario");
        imagen.GetComponent<Renderer>().material.mainTexture= texture;
    }

    // Update is called once per frame
    public void obternerNombre()
    {
        
        int randomPokeIndex = Random.Range(1, 808);
        StartCoroutine(GetPokemonAtIndex(randomPokeIndex));


    }

    IEnumerator GetPokemonAtIndex(int pokemonIndex)
    {

        
        string pokemonURL = basePokeURL1 + "pokemon/" + pokemonIndex.ToString();

        UnityWebRequest pokeInfoRequest = UnityWebRequest.Get(pokemonURL);

        yield return pokeInfoRequest.SendWebRequest();

        if (pokeInfoRequest.isNetworkError || pokeInfoRequest.isHttpError)
        {
            Debug.LogError(pokeInfoRequest.error);
            yield break;
        }

        JSONNode pokeInfo = JSON.Parse(pokeInfoRequest.downloadHandler.text);

        string pokeName = pokeInfo["name"];
        string pokeSpriteURL = pokeInfo["sprites"]["front_default"];
        texto.GetComponent<TextMeshPro>().SetText(CapitalizeFirstLetter(pokeName));




        UnityWebRequest pokeSpriteRequest = UnityWebRequestTexture.GetTexture(pokeSpriteURL);
        yield return pokeSpriteRequest.SendWebRequest();
        if (pokeSpriteRequest.isNetworkError || pokeSpriteRequest.isHttpError)
        {
            Debug.LogError(pokeSpriteRequest.error);
            yield break;
        }

        imagen.GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(pokeSpriteRequest);
        
    }

    private string CapitalizeFirstLetter(string str)
    {
        return char.ToUpper(str[0]) + str.Substring(1);
    }



}
