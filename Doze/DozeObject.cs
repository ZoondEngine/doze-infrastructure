using Doze.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doze
{
    public class DozeObject
    {
        private List<DozeComponent> ObjectComponents = new List<DozeComponent>();

        private string Tag { get; set; }

        public DozeObject()
        {
            Tag = GetType().FullName + "__" + Guid.NewGuid().ToString();
        }

        public DozeObject(string tag)
        {
            Tag = tag;
        }

        public static T Create<T>() where T : DozeObject, new()
            => DozeObjectManager.Create<T>();

        public static T Create<T>(string tag = "") where T : DozeObject
            => DozeObjectManager.Create<T>(tag);

        public static T GetObjectByTag<T>(string tag) where T : DozeObject
            => DozeObjectManager.GetObjectByTag<T>(tag);

        public static T FindObjectOfType<T>() where T : DozeObject
            => DozeObjectManager.GetObjectByType<T>();

        public static T[] FindObjectsOfType<T>() where T : DozeObject
            => DozeObjectManager.GetAllObjectsByType<T>();

        public static T ReinterpretObject<T>(DozeObject obj) where T : DozeObject
            => obj.ReinterpretObject<T>();

        /// <summary>
        /// Method must be implemented in child classes
        /// </summary>
        public virtual void Destroy()
            => throw new NotImplementedException("Method must be implemented in child classes");

        /// <summary>
        /// Add the component to object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T AddComponent<T>() where T : DozeComponent, new()
        {
            var obj = new T
            {
                ParentObject = this
            };
            obj.Awake();

            ObjectComponents.Add(obj);

            return obj;
        }

        /// <summary>
        /// Get component from object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : DozeComponent
            => (T)ObjectComponents.FirstOrDefault((x) => x.GetType() == typeof(T));

        /// <summary>
        /// Get all components from object by type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T[] GetAllComponents<T>() where T : DozeComponent
        {
            List<T> premade = new List<T>();
            var components = GetObjectComponents();

            for (var i = 0; i < components.Count; i++)
            {
                if (components[i].GetType() == typeof(T))
                    premade.Add((T)components[i]);
            }

            return premade.Count > 0 ? premade.ToArray() : null;
        }

        /// <summary>
        /// Remove component from object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void RemoveComponent<T>() where T : DozeComponent
        {
            var obj = GetComponent<T>();
            if(obj != null)
            {
                obj.BeforeDestroy();
                obj.Destroy();

                ObjectComponents.Remove(obj);
            }
        }

        public T ReinterpretObject<T>() where T : DozeObject
            => (T)this;

        public List<DozeComponent> GetObjectComponents()
            => ObjectComponents;

        public string GetTag()
            => Tag;
    }
}
