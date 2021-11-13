using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleGame.MenuObjects
{
    public abstract class MenuObject
    {
        public string Title = "Default";
        public string Value = "DefVal";
        public bool quickscroll = false;
        public bool Disabled = false;

        public virtual void Update()
        {
            
        }

        public virtual void OnActivate()
        {
            
        }

        public virtual void OnDeactivate()
        {

        }

        public virtual void ScaleUp()
        {
            
        }

        public virtual void ScaleDown()
        {

        }



        internal bool Toggle(bool Bool, string FalseMsg, string TrueMsg)
        {
            string ReturnMsg;
            if (Bool == true)
            {
                Bool = false;
                ReturnMsg = FalseMsg;
            }
            else
            {
                Bool = true;
                ReturnMsg = TrueMsg;
            }
            Value = ReturnMsg;
            return Bool;
        }

        internal bool Toggle(bool Bool)
        {
            if (Bool == true)
                Bool = false;
            else
                Bool = true;

            return Bool;
        }

    }
}
