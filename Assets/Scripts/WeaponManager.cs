using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> Weapons;
    public float ChargeSpeed;

    private int _currentIndex;
    private Weapon _currentWeapon;

    private Plane _mousePlane = new Plane(Vector3.back, 0);

    private float Charge = -1;

    private void Start()
    {
        _currentWeapon = GameObject.Instantiate(Weapons[_currentIndex].gameObject).GetComponent<Weapon>();
    }

    private void Update()
    {
        Vector3 mousePosition = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (_mousePlane.Raycast(ray, out float distance))
        {
            mousePosition = ray.GetPoint(distance);
        }


        if (Input.mouseScrollDelta.y != 0)
        {
            ScrollWeapon(Mathf.RoundToInt(Input.mouseScrollDelta.y));
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Charge = -1;
            _currentWeapon.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Charge = Time.deltaTime * ChargeSpeed;
            _currentWeapon.gameObject.SetActive(true);
        }
        _currentWeapon.Preview(mousePosition, Charge > 0 ? Charge : 0);
        if (Charge >= 0 )
        {
            Charge = Mathf.Min(Charge + Time.deltaTime * ChargeSpeed, 1);



            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _currentWeapon.Attack(mousePosition, Charge);
                Charge = -1;
            }
        }
    }

    public void ScrollWeapon(int scroll)
    {
        Debug.Log(scroll);
        Debug.Log(_currentIndex);

        Destroy(_currentWeapon.gameObject);
        _currentIndex = Mathf.Max((Weapons.Count + _currentIndex + scroll) % Weapons.Count, 0);

        _currentWeapon = GameObject.Instantiate(Weapons[_currentIndex].gameObject).GetComponent<Weapon>();
        Debug.Log(_currentWeapon.name);
    }

}
