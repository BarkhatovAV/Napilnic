using System;

namespace Weapon
{
    class Weapon
    {
        private int _damage;
        private int _bulletCount;

        public void Fire(Player player)
        {
            if(_bulletCount > 0)
            {
                player.TakeDamage(_damage);
                _bulletCount -= 1;
            }
        }
    }

    class Player
    {
        private int _health;

        public void TakeDamage(int damage)
        {
            if(damage > 0)
            {
                _health -= damage;
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
