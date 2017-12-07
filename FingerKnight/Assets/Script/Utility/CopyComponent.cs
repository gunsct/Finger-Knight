using UnityEngine;
using System.Collections;

public static class CopyWriteComponent {

    static public T CopyComponent<T>(T original, GameObject destination) where T : Component {
        System.Type type = original.GetType();
        Component copy = destination.AddComponent(type);
        System.Reflection.FieldInfo[] fields = type.GetFields();
        foreach (System.Reflection.FieldInfo field in fields) {
            field.SetValue(copy, field.GetValue(original));
        }
        
        return copy as T;
    }
}
