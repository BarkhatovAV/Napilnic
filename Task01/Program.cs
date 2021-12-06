using System;

namespace NapilnicTask01
{
    class Weapon
    {
        private int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage < 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (bullets < 0)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _damage = damage;
            _bullets = bullets;

        }

        public void Fire(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            if (_bullets > 0)
            {
                player.TakeDamage(_damage);
                _bullets--;
            }
            else
            {
                throw new Exception("кончились патроны");
            }
        }
    }

    class Player
    {
        private int _health;

        public event Action Died;

        public Player(int health)
        {
            if (health <= 0)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            _health -= damage;

            if (_health <= 0)
            {
                Died?.Invoke();
            }
        }
    }

    class Bot
    {
        private Weapon _weapon;

        public Bot(Weapon weapon)
        {
            if (weapon == null)
                throw new ArgumentNullException(nameof(weapon));

            _weapon = weapon;
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            _weapon.Fire(player);
        }
    }
}
