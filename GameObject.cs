using System;
using Utilities;

namespace Console_Game
{
    abstract public class GameObject
    {
        bool isDead;

        public GameObject() {
            isDead = false;
        }

        internal virtual void Update(int delta) { }
        
        internal virtual Point GetGraphicPos() { return new Point(); }

        internal virtual string GetGraphic() { return " "; }
    }
}