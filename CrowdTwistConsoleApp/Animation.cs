using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdTwistConsoleApp
{
    public class Animation
    {



        public List<string> Animate(int speed, string init)
        {
            var result = new List<string>();

            int sizeOfChamber = init.Length;

            var particles = GetParticles(init);

            while(particles.Any())
            {
                result.Add(GetCurrentChamber(particles, sizeOfChamber));
                particles = UpdateParticles(particles, speed, sizeOfChamber);
            }

            result.Add(GetEmptyChamber(sizeOfChamber));

            return result;
        }

        private List<Particle> GetParticles(string init)
        {
            var result = new List<Particle>();
            var charArray = init.ToArray();
            for(int i = 0; i < charArray.Length; i++)
            {
                var current = charArray[i];
                if(current != '.')
                {
                    result.Add(new Particle() { Position = i, Direction = current });
                }
            }

            return result;
        }

        private List<Particle> UpdateParticles(List<Particle> particles, int speed, int sizeOfChamber)
        {
            var result = new List<Particle>();

            foreach(var particle in particles)
            {
                particle.Move(speed);
                if (particle.InChamber(sizeOfChamber))
                    result.Add(particle);
            }

            return result;
        }

        private string GetCurrentChamber(List<Particle> particles, int sizeOfChamber)
        {
            var chamber = new List<char>();
            for(int i =0; i < sizeOfChamber; i++)
            {
                chamber.Add('.');
            }

            foreach(var particle in particles)
            {
                chamber[particle.Position] = 'X';
            }

            return new String(chamber.ToArray());
        }

        private string GetEmptyChamber(int sizeOfChamber)
        {
            string chamber = "";
            for (int i = 0; i < sizeOfChamber; i++)
                chamber += ".";

            return chamber;
        }
        
    }


    public class Particle
    {
        public int Position { get; set; }

        public char Direction { get; set; }

        public void Move(int speed)
        {
            if (Direction == 'R')
                Position += speed;
            else if (Direction == 'L')
                Position -= speed;
            else
                throw new InvalidOperationException("Direction is wrong");
        }

        public bool InChamber(int lengthOfChamber)
        {
            return Position >= 0 && Position < lengthOfChamber;
        }
    }
}
