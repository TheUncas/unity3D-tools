using UnityEngine;
using System;
using System.Reflection;
using System.Linq;

/*
*   Gameobject Class Extension
*/
namespace Utilities.Extension
{
    public static class GameObjectExtension
    {
        /// 
        /// Check it the gameobject has the specified component
        /// 
        public static bool HasComponent(this GameObject go) where T : Component
        {
            return go.GetComponentsInChildren().FirstOrDefault() != null;
        }

        /// 
        /// Return a copy of the component
        /// 
        public static T GetCopyOf(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();

            if (type != other.GetType()) return null; // type mis-match
            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);
            foreach (var pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            FieldInfo[] finfos = type.GetFields(flags);
            foreach (var finfo in finfos)
            {
                finfo.SetValue(comp, finfo.GetValue(other));
            }
            return comp as T;
        }

        /// 
        /// Copy the component
        /// 
        public static T AddComponent(this GameObject go, T toAdd) where T : Component
        {
            return go.AddComponent().GetCopyOf(toAdd) as T;
        }
    }
}