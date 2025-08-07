using System;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocator : MonoBehaviour
{
    private Dictionary<Type, object> services = new Dictionary<Type, object>();

    public T GetService<T>() where T : class
    {
        if (services.TryGetValue(typeof(T), out var service))
        {
            return service as T;
        }
        else
            return null;
    }

    public void RegisterService<T>(T param_service)
    {
        this.services[typeof(T)] = param_service;
    }

    public void UnRegisterService<T>()
    {
        this.services.Remove(typeof(T));
    }

}