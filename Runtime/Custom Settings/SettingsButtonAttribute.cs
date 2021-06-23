using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class SettingsButtonAttribute : Attribute
{
    public string contextTitle;
    public string headerContainer;

    public SettingsButtonAttribute(string contextTitle, string headerContainer) {
        this.contextTitle = contextTitle;
        this.headerContainer = headerContainer;
    }
}
