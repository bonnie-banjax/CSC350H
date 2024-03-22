using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ROUGH_ELEVENS
{

    public struct State
    {
        // [GIANT COMMENTARY BLOCK] given living documentation note

        private Object[] state_cache;
        public LinkedList<Object> active_state; 
        private Stack <LinkedList<Object>> dormant_states;

        
        public void addField(object arg)
        { active_state.AddLast(arg); }

        public void Cache() { state_cache = active_state.ToArray(); }

        public object[] Status() 
        {
            if (state_cache != null)
                return state_cache;
            else { Cache(); return state_cache; }
             
        } // return dormant_states.Peek().ToArray();

        public LinkedList<object> Check()
        { return dormant_states.Peek(); }


        public State() { active_state = new(); dormant_states = new(); }
        public State(LinkedList<object>? seed)
        {
            dormant_states = new();
            if (seed != null) { 
                active_state = seed;
                dormant_states.Push(active_state);
            }
            else { active_state = new(); }
        } // END_CONSTRUCTOR


        public void Dorm() { dormant_states.Push(active_state); }
        public void Wake() { active_state = dormant_states.Pop(); }
        public void Dust() { state_cache = []; }
        public void Sweep() { active_state.Clear(); }
        public void Scrub() { dormant_states.Clear(); }

        public void Clean() { Dust(); Sweep(); Scrub(); }

        
        public string Signature()
        {
            string ID = "[::]";

            foreach (var item in active_state)
            { ID += " | " + item.GetHashCode().ToString() + " | "; }

            return ID+"[::]";
        }
        public string Dump()
        {
            if (dormant_states.Count == 0)
                return "[::{::}::][::{::}::]";

            string ID = "\n[::{::}::]";

            do
            {
                Wake();
                ID += "\n[::]";
                foreach (var item in active_state)
                ID += "| " + item.GetHashCode().ToString() + " |";
                ID += "[::]";
            }
            while (dormant_states.Count != 0);


            return ID + "\n[::{::}::]";
        }

        public static bool operator == (State a, State b)
        {
            List<object> aVal = a.active_state.ToList();
            List<object> bVal = b.active_state.ToList();

            if (a.active_state.Count() != b.active_state.Count)
                return false;

            for (int i = 0; i < aVal.Count; i++)
                if (aVal[i].GetHashCode() != bVal[i].GetHashCode())
                    return false;

            return true;
        } // END_OPERATOR

        public static bool operator != (State a, State b)
        {
            List<object> aVal = a.active_state.ToList();
            List<object> bVal = b.active_state.ToList();

            if (a.active_state.Count() != b.active_state.Count)
                return true;

            for (int i = 0; i < aVal.Count; i++)
                if (aVal[i].GetHashCode() != bVal[i].GetHashCode())
                    return true;
            
            return false;
        } // END_OPERATOR

        public static State operator +(State a, Object b)
        {
            a.addField(b);
            return a;
        }

        public static State operator --(State a)
        {
            a.active_state.RemoveLast();
            return a;
        }

    } //END_STRUCT

    public struct LOGGER
    {
        private string loggerID;
        private int logCount;
        private SortedDictionary<int, LOG> logs;

        public string ID { get { return loggerID; } }
        public int LogCount { get { return logCount; } }
        public LOG GetLog(int i) { return logs[i]; }
        public LOG Last { get { return logs[LogCount]; } }
        public SortedDictionary<int, LOG> LogDump()
        { return logs; }

        public LOGGER()
        {
            logs = new();
            loggerID = this.GetHashCode().ToString();
            logCount = 0;
            logs[0] = MakeLog(this);

        } // END_CONSTRUCTOR

        public struct LOG(string logger, string actionID, Object action)
        {
            public string loggerID = logger;
            public string actionID = actionID;
            public Object action = action; // a weak pointer in the future (?)

        } // END_STRUCT

        public void AddLog(object target)
        { logs.Add(++logCount, MakeLog(target)); }

        private LOG MakeLog(object obj)
        { return new(ID, obj.GetHashCode().ToString(), obj); }



    } // END_STRUCT

    public struct RULESET
    {
        public Dictionary<string, object> rule;

        public RULESET()
        { rule = new(); } // END_CONSTRUCTOR

        public RULESET(Dictionary<string, object> seed)
        { rule = seed; } // END_CONSTRUCTOR

        public void dictInit(Dictionary<string, object> seed)
        { rule = seed; } // END_CONSTRUCTOR

        public void Elevens()
        {
            rule.Clear();

            rule["rulesID"] = (string)"[ELEVENS]";
            rule["tableHandSize"] = (int)9;

            rule["pairCheck"] = (int)11;
            rule["triadCheck"] = (int)36;
            rule["triadTuple"] = ((int)11, (int)12, (int)13);
            rule["triadCheckArray"] = new int[] { 11, 12, 13 }; 

            rule["VictoryState"] = new State();
            rule["FailureState"] = new State();
        }

        public void Elevens_52()
        {
            rule.Clear();

            rule["rulesID"] = (string)"[ELEVENS]";
            rule["tableHandSize"] = (int)52;

            rule["pairCheck"] = (int)11;
            rule["triadCheck"] = (int)36;
            rule["triadTuple"] = ((int)11, (int)12, (int)13);
            rule["triadCheckArray"] = new int[] { 11, 12, 13 };

            rule["VictoryState"] = new State();
            rule["FailureState"] = new State();
        }

        public void Elevens_02()
        {
            rule.Clear();

            rule["rulesID"] = (string)"[ELEVENS]";
            rule["tableHandSize"] = (int)2;

            rule["pairCheck"] = (int)11;
            rule["triadCheck"] = (int)36;
            rule["triadTuple"] = ((int)11, (int)12, (int)13);
            rule["triadCheckArray"] = new int[] { 11, 12, 13 };

            rule["VictoryState"] = new State();
            rule["FailureState"] = new State();
        }



    } // END STRUCT

    public struct ELEVENS // const version ? figure out how do
    {
        public string rulesID; // = "[ELEVENS]"
        public int tableHandSize; // = 9

        public int pairCheck; // = 11
        public int triadCheck; // = 36
        public (int a, int b, int c) triadTuple; // = (11, 12, 13)
        public int[] triadCheckArray; // = [11, 12, 13]

        State VictoryState; // validMoveExists == false && tableHandCount == 0
        State FailureState; // validMoveExists == false && tableHandCount != 0

        public int deckSize;// = 52
        public int tokenFieldsCount; // = 2
        public (int, int) tokenEnumRanges; // (4, 13) (rank, suit) // this doesn't work right
        public int[,] tokenRanges;

        public ELEVENS(string code)
        {
            rulesID = "[ELEVENS]";
            tableHandSize = 9;

            pairCheck = 11; // 10
            triadCheck = 36;
            triadTuple = (11, 12, 13);
            triadCheckArray = new int[] { 11, 12, 13}; // [11, 12, 13];

            VictoryState = new();
            FailureState = new();

            deckSize = 52;
            tokenFieldsCount = 2;
            tokenEnumRanges = (4, 13);
            tokenRanges = new int[4, 13]; // issue of conversion to the actual enums
        } // END_CONSTRUCTOR
    }

}

