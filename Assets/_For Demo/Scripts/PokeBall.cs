using System.Collections.Generic;
using UnityEngine;

public class PokeBall : MonoBehaviour
{
    public Animator anim;
    public List<GameObject> pokemons;
    public int randomPokemonIndex;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("tagged");
        if (collision.collider.tag == "Ground")
        {
            anim.Play("BallOpen");
            randomPokemonIndex = Random.Range(0, pokemons.Count);
            GameObject spawnedPokemon = GameObject.Instantiate(pokemons[randomPokemonIndex]);
            spawnedPokemon.transform.position= this.transform.position;
            GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject,2f);
            Destroy(spawnedPokemon,6f);
        }
    }
}