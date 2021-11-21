using System;

namespace NapilnicTask01
{
    class Weapon
    {
        private int _damage;
        private int _bulletCount;

        public Weapon(int damage, int bulletCount)
        {
            if(damage > 0 && bulletCount > 0)
            {
                _damage = damage;
                _bulletCount = bulletCount;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Fire(Player player)
        {
            if (_bulletCount > 0)
            {
                player.TakeDamage(_damage);
                _bulletCount--;
            }
        }
    }

    class Player
    {
        private int _health;

        public Player(int health)
        {
            if(health > 0)
                _health = health;
            else
                throw new ArgumentOutOfRangeException();

        }

        public void TakeDamage(int damage)
        {
            if (damage > 0)
            {
                _health -= damage;

                if (_health <= 0)
                {
                    Dead();
                }
            }
        }

        private void Dead()
        {
            //логика смерти игрока
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            _weapon.Fire(player);
        }
    }
}
