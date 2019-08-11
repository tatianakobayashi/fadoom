using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public bool dropsKey;
    public int keyNumber;
//    public int healthPackSize;
//    public int ammoPackSize;

    public GameObject key;
//    public GameObject healPack;
 //  public GameObject ammoPack;

    //public int healPercentage;
    //public int ammoPercentage;

    private void OnDestroy()
    {
   //     System.Random rnd = new System.Random();

        if (dropsKey)
        {
            GameObject instKey =  Instantiate(key, transform.position, Quaternion.identity);
            instKey.GetComponent<Pack>().value = keyNumber;

            Debug.Log("Dropping key");
        }

 //       int healProb = rnd.Next(1, 101);
//        int ammoProb = rnd.Next(1, 101);

   //     if(healProb >= healPercentage)
  //      {
 //           GameObject heal = Instantiate(healPack, transform.position, Quaternion.identity);
//            heal.GetComponent<Pack>().value = healthPackSize;

       //     Debug.Log("Dropping heal");
      //  }
      //  if(ammoProb >= ammoPercentage)
    //    {
  //          GameObject ammo = Instantiate(ammoPack, transform.position, Quaternion.identity);
//            ammo.GetComponent<Pack>().value = ammoPackSize;

         //   Debug.Log("Dropping ammo");
        //}
    }
}
