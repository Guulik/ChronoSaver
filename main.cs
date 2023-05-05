using Chrono;

namespace App{
    class Program
    {
        static int SlotIndex = 0;
        static string userChoice = "";

        static string SourceChrono = @"P:\Games\The legend of Zelda\mlc01\usr\save\00050000\101c9500\user\80000001";
        static string PathChrono = @"P:\Games\The legend of Zelda\ChronoSaver\usrSaves\unAllocated";
        
        static string TestChrono = @"P:\Games\The legend of Zelda\ChronoSaver\test\destination";
        static void ChooseSlot()
        {
            userChoice = Console.ReadLine();
            if (userChoice == "1" || userChoice == "2" || userChoice == "3"){
                SlotIndex = Convert.ToInt32(userChoice);
                PathChrono = @$"P:\Games\The legend of Zelda\ChronoSaver\usrSaves\{SlotIndex}";
            }
            else {
                PathChrono = @"P:\Games\The legend of Zelda\ChronoSaver\usrSaves\unAllocated";
                throw new Exception("Chosen slot does not exist, so 'unAllocated' now is active folder\n"+
                 "Be sure to choose correct slot, because data in unAllocated folder will be rewrited during next Save");
            }
            
        }
        //src - stands for "source"
        //dst - stands for "destination"
        public static void Save(string src, string dst) //save FROM src TO dst
        {
            FileMethods.CopyDirectory(src, dst);
        }
        public static void Load(string src, string dst) // load FROM src TO dst
        {
            FileMethods.CopyDirectory(src, dst);
        }
        static void Main(string[] args)
        {
            try {
                Console.WriteLine("Please choose slot number");
                ChooseSlot();
            }
            catch (Exception exception){
                Console.WriteLine(exception.Message);
            }
            Console.WriteLine("What do you want to do? 1 - load, 2 - save");
            userChoice = Console.ReadLine();
            switch (userChoice){
                    case "1":
                        Load(PathChrono,TestChrono);
                        Console.WriteLine("Loaded Successfully");
                    break;
                    case "2":
                        Save(SourceChrono, PathChrono);
                        Console.WriteLine("Saved Successfully");
                    break;
                }
        }
    }
}