using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<Weapon> Weapons;
    public float ChargeSpeed;

    private int _currentIndex;
    private Weapon _currentWeapon;

    private Plane _mousePlane = new Plane(Vector3.back, 0);

    private float _charge = -1;

    private void Start()
    {
        _currentWeapon = GameObject.Instantiate(Weapons[_currentIndex].gameObject).GetComponent<Weapon>();
        _currentWeapon.AttachTo(Character.Current);
    }

    private void Update()
    {
        if(Input.mouseScrollDelta.y != 0)
        {
            ScrollWeapon(Mathf.RoundToInt(Input.mouseScrollDelta.y));
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            _charge = -1;
            _currentWeapon.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _charge = Time.deltaTime * ChargeSpeed;
            _currentWeapon.gameObject.SetActive(true);
        }
        if(_charge >= 0 )
        {
            _charge = Mathf.Min(_charge + Time.deltaTime * ChargeSpeed, 1);

            Vector3 mousePosition = Vector3.zero;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (_mousePlane.Raycast(ray, out float distance))
            {
                mousePosition = ray.GetPoint(distance);
            }

            _currentWeapon.Preview(mousePosition, _charge);

            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                _currentWeapon.Attack(mousePosition, _charge);
                _charge = -1;
            }
        }
    }

    public void ScrollWeapon(int scroll)
    {
        Destroy(_currentWeapon);
        _currentIndex = Mathf.Max((_currentIndex + scroll) % Weapons.Count, 0);

        _currentWeapon = GameObject.Instantiate(Weapons[_currentIndex].gameObject).GetComponent<Weapon>();
        _currentWeapon.AttachTo(Character.Current);
    }

}