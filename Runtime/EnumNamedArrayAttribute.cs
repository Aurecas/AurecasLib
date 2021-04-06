using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumNamedArrayAttribute : PropertyAttribute {
    public string[] names;
    public EnumNamedArrayAttribute(System.Type names_enum_type) {
        names = System.Enum.GetNames(names_enum_type);
    }
}