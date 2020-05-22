using UnityEngine;

namespace Doze.Hurtworld
{
    public static class Loader
    {
        public static GameObject JirniyGameObject;

        public static void Load()
        {
            Debug.Log("Loader.Load called!");

            JirniyGameObject = new GameObject();
            JirniyGameObject.AddComponent<AnticheatJirniyPlugin>();
            Object.DontDestroyOnLoad(JirniyGameObject);
        }

        public static void Unload()
        {
            Object.DestroyImmediate(JirniyGameObject);
        }
    }
}
