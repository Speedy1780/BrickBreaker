﻿using UnityEngine;

public class FactoryManager : Singleton<FactoryManager>
{
    public FactoryCatalog Catalog;

    public GameObject GetItem(PoolID id)
    {
        //Return an instantiated object from the catalog
        if (Catalog.ContainsKey(id))
        {
            FactoryCategory category = Catalog[id]; //Get the current category
            GameObject item = category.GetRandomIten; //Get a random item

            return Instantiate(item); //Return an instance of this object
        }
        else
        {
            Debug.LogError($"Missing key {id} from factory");
            return null;
        }
    }
}

[System.Serializable]
public class FactoryCatalog : SerializableDictionaryBase<PoolID, FactoryCategory> { }