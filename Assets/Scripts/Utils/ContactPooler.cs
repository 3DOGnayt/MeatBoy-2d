using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class ContactPooler
    {
        public ContactPoint2D[] _contacts = new ContactPoint2D[10];

        private const float _collTreshold = 0.6f;
        private int _contactCoint;
        private Collider2D _collider2d;

        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider2d = collider;

        }

        public void Update()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;

            _contactCoint = _collider2d.GetContacts(_contacts);

            for (int i = 0; i < _contactCoint; i++)
            {
                if (_contacts[i].normal.y > _collTreshold) IsGrounded = true;
                if (_contacts[i].normal.x > _collTreshold) HasLeftContact = true;
                if (_contacts[i].normal.x > -_collTreshold) HasRightContact = true;
            }

        }
    }
}
