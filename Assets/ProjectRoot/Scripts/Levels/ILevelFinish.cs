using System;

namespace Levels
{
    public interface ILevelFinish
    {

        public event Action Finishing;


        public void Lock();

        public void Unlock();
    }
}
