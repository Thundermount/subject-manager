using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Manager
{
    class Work : Subject
    {
        public string name;
        public State state;
        public Work(string name, State state)
        {
            this.name = name;
            this.state = state;
        }
        public Work(string name)
        {
            this.name = name;
            this.state = State.NotReady;
        }
        public void ChangeState(State state)
        {
            this.state = state;
        }
        public static void Delete(int work_id, string path)
        {
            FileIO<Work> fl = new FileIO<Work>();
            fl.RemoveId(path, work_id);
        }

    }
    enum State
    {
        Ready,
        InProgress,
        NotReady
    }

    
}
