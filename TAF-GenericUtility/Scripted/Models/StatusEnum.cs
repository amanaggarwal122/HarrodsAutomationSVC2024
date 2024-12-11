namespace TAF_GenericUtility.Scripted.Models
{ 
    public static class StatusEnum
    {
        public static string Pass { get { return "Passed"; } }
        public static string Fail { get { return "Failed"; } }
        public static string WIP { get { return "WIP"; } }
        public static string Blocked { get { return "Blocked"; } }
        public static string UnExecuted { get { return "UnExecuted"; } }
    }
}