using UnityEngine;

public abstract class ParentClass : MonoBehaviour
{
    public abstract void Method();
}

public class StudySealed : ParentClass
{
    public sealed override void Method()
    {
        Debug.Log("Override Method");
    }
}
 

