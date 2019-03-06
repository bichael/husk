using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator _animator;
    public RuntimeAnimatorController[] _controllers;

    int _id = 0;
    // Start is called before the first frame update
    void Start()
    {
        
        if (_animator == null)
            _animator = gameObject.GetComponent<Animator>();
        
    }
    
    public void setAnimator(int id) {        
        if (_controllers == null ||  _controllers.Length == 0)
            return;

        _id = (id < 0) ? _controllers.Length - 1 : (id > _controllers.Length - 1) ? 0 : id;

        if(_animator!=null)
            _animator.runtimeAnimatorController = _controllers[_id];
    }
}
