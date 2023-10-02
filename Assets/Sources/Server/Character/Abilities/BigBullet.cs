using Server.CharacterLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BigBullet : FightTargetAbility, IPointerClickHandler
{

    private float _damage = 50f;

    public override void UseAbility()
    {
        if (!_reload)
        {
            Debug.Log("Способность пременена");
            _active = true;
        }
        else
        {
            Debug.Log("Перезарядка");
        }
    }
    protected override void UseOnTarget(BattleCharacter target)
    {
        target.TakeDamage(_damage);
        Debug.Log("BigBullet применен на  " + target);
        _reload = true;
    }

    protected override IEnumerator Reload()
    {
        yield return new WaitForSeconds(_cooldown);
        _reload = false;
    }

    private void OnMouseDown()
    {
        Debug.Log("JOPA");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("IPointerClick");
        if (_active)
        {
            Debug.Log("IPointerClick and active");
            if (eventData.pointerClick.TryGetComponent(out BattleCharacter component))
            {
                Debug.Log(component.name);
                if(_inFirstTeam)
                UseOnTarget(component);
            }
            else
            {
                _active = false;
            }
        }
    }
}
