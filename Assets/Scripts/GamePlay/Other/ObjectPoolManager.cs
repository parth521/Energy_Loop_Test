using System.Collections.Generic;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{

    private Dictionary<string, Queue<GameElement>> poolDictionary = new Dictionary<string, Queue<GameElement>>();

    public GameElement GetObject(GameElement prefab)
    {
        string key = prefab.name;

        if (poolDictionary.ContainsKey(key) && poolDictionary[key].Count > 0)
        {
            GameElement pooledObject = poolDictionary[key].Dequeue();
            pooledObject.gameObject.SetActive(true);
            return pooledObject;
        }
        else
        {
            GameElement newObject = Instantiate(prefab);
            newObject.name = key;
            return newObject;
        }
    }

    public void ReturnObject(GameElement obj)
    {
        string key = obj.name;

        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new Queue<GameElement>();
        }
        obj.gameObject.SetActive(false);
        poolDictionary[key].Enqueue(obj);
    }
}
