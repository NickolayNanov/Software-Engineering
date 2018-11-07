using Military.Enumss;
using Military.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military.Soldiers
{
    public class Mission : IMission
    {
        private string codeName;
        private State state;

        public Mission(string codeName, State state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get => codeName; set => codeName = value; }
        public State State { get => state; set => state = value; }

        public void CompleteMission()
        {
            this.State = State.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
