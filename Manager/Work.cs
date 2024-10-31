using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace Manager
{
    // Поскольку я не могу сериализовать в xml класс с аргументами в конструкторе
    // мне приходится заполнять поля напрямую
    public class Work
    {
        public string name;
        public State state;

        public void ChangeState(State state)
        {
            this.state = state;
        }
        public static void Delete(int work_id, string path)
        {
            FileIO<Work> fl = new FileIO<Work>();
            fl.RemoveId(path, work_id);
        }

        // Да потому что если писать эксеншен то это столько мусорного кода что ну его нафиг
        public static readonly string[] StateStrings = {"Не готов", "В работе", "Готов"};
        public static readonly Color[] StateColors = { Color.Red, Color.Yellow, Color.Green };

    }

    public enum State
    {
        NotReady,
        InProgress,
        Ready
    }

    

}
