using System.Collections;
using System.Collections.Generic;

public interface IInteractable
{
    float MaxRange {get;}
    List<int> Inventory {get;set;}

    void OnStartHover();
    void OnInteract();
    void OnEndHover();
}
