using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;

public class Candy : MonoBehaviour
{
    private float _suckTime = .5f;
    private float _suckTimer;

    private bool _isBeingSuckedUp = false;
    private bool _pickUpSound = false;

    public void SuckUpIntoPlayer()
    {
        _isBeingSuckedUp = true;
        _suckTimer = _suckTime;

        if (_pickUpSound == false)
        {
            AudioController.candyPickup.Play();
        }

        _pickUpSound = true;
    }

    private void Update()
    {
        if(_isBeingSuckedUp)
        {
            _suckTimer -= Time.deltaTime;
            if(_suckTimer <= 0f)
            {
                // Add Candy to Player...
                Player.PlayerInstance.AddCandy(1);
                Destroy(this.gameObject);
                _pickUpSound = false;
            }

            this.transform.position = Vector3.Slerp(Player.PlayerInstance.transform.position, this.transform.position, _suckTimer / _suckTime);
            //Vector3 dir = (Player.PlayerInstance.transform.position - this.transform.position).normalized;
            //this.transform.Translate(dir)
        }
    }
}
