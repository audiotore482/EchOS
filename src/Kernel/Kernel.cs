﻿using System.Threading;
using Sys = Cosmos.System;
using System;
using Cosmos.System.FileSystem.VFS;

/* 
* EchOS 2022 This is the base of the operating system
* and where most of the Operating system spends its time.
* Note that you can do anything with this system. Republish it with or without credit,
* modify it, Make it goofy ahh, Go crazy bro!
* 
* Also if you are planning to modify the code MAKE SURE that you DO have Cosmos AND Vmware Installed. Otherwise there will be build errors when compiling this.
* Go figure this out yourself as I will most likely not be providing any documentation on how to do this. If you have some experience in coding editing the source code should be fairly easy.
* as this used super basic code.
* 
*/

namespace EchOS
{


    public class Kernel : Cosmos.System.Kernel
    {

        

        // Variables to pass to fileSystem class.
        public static string filemake;
        public static string filedelete;

        public static string dirmake;
        public static string dirdelete;

        public static string fileread;

        protected override void BeforeRun()
        {

            var fs = new Sys.FileSystem.CosmosVFS();
            VFSManager.RegisterVFS(fs);

            Cmdman.RedScreenOfDeath();

            Console.Clear(); //

            Console.WriteLine("Kernel loaded..");
            Thread.Sleep(1000);
            Console.Clear();




            for (int index = 0; index < 2; index += 1)
            {

                Console.WriteLine("Booting.");
                Thread.Sleep(1000);

                Console.WriteLine("Booting..");
                Thread.Sleep(1000);

                Console.WriteLine("Booting...");
                Thread.Sleep(1000);

                Console.Clear();

            }

            // Ascii Logo.
            Console.WriteLine(@"

					:~7Y5PPPP5YJ?!^.                          
				:75GBBBBBBBGGGPP55J7^.				    ^7777777777~
			:JG#BBB###BBBBBBBBBG5YY?~.				    P@@@@@@@@@@5   
			!G#BB##BBBBBBBBGGGGBBBG5JJ7:			    #@@&5YYYYY5~   
			7B#B##BBBBBBBBBBBBBGGGGG#P???:			    @@@5           
			~BBB##BBBB#BPY?77?YPBBGGGG#P??7.		    7@@@J.:::::.    
			YBBB#BBBB#GY!.    :!JBBPPGG#J??^		    5@@@@@@@@@@Y    
			5BGB#BBGB#P?.      :7P#GPGG#Y??~		    B@@&BBBBBBB!    
			JGGG#BBBB#GJ!.    .~JBBPGGG#J??^ :		    @@@P            
			^PGPB#BBGGBB5J7!!7J5BBPPGG#P??7.		    7@@@?            
			!PPPB#BGGGGBBBBBBBBGPPGG#P???:			    5@@@7:::::^.     
			~YP5PBBBGGGGGGGPPPGGBBGY??7:			    #@@@@@@@@@@?     
			.7YYY5PGBBBGGGBBBGG5J??7^:G     
				.~7?JJJYYY55YYJJ??7!:                        
					.:~!!777777!~^:.    


			");

            Console.Beep();
            Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("===========================================");
            Console.WriteLine("||########################################||");
            Console.WriteLine("||               EchOS 1.4                ||");
            Console.WriteLine("||########################################||");
            Console.WriteLine("===========================================");
            Console.WriteLine("Type \"Help();\" to get a list of commands.");
            Console.WriteLine("Or type \"Open.Tour();\" to take a tour to learn how to use EchOS.");

            

        }

        protected override void Run() // While loop by default.
        {

            while (true)
            {

                Console.Write(@"[0:\]: ");
                string input_cmd = Console.ReadLine();
                switch (input_cmd)
                {

                    case "Help();":
                        Cmdman.Help();
                        break;

                    case "System.Shutdown();":
                        Cmdman.Shutdown();
                        break;

                    case "System.Reboot();":
                        Cmdman.Reboot();
                        break;

                    case "CMD.Clear();":
                        Cmdman.Clear_Src();
                        break;

                    case "BackgroundColor.Change();":
                        Cmdman.BackgroundColor_Change();
                        break;

                    case "Open.Calculator();":
                        Calculator.Main(null);
                        break;

                    case "System.About();":
                        Cmdman.About();
                        break;

                    case "Open.Tour();":
                        Tour.Main(null);
                        break;

                    case "Open.TextPad();":
                        Textpad.textpad();
                        break;

                    case "Disk.GetInformation();":
                        Cmdman.DiskGetInformation();
                        break;

                    case "Disk.ListDir();":
                        Filesystem.listdir();
                        break;

                    case "File.create ":
                        Console.WriteLine("1");
                        break;

                    default:
                        Console.WriteLine("'" + input_cmd + "' Is not a vaild command.");
                        Console.WriteLine("NOTE: Every command has a capital at the beginning and a '();' at the end.");
                        break;

                }

                if (input_cmd.StartsWith("File.create "))
                {

                    if (!input_cmd.Contains("();"))
                    {

                        Console.WriteLine("ERROR: Missing a \"();\"");

                    }

                    else
                    {

                        string toremove = input_cmd.Replace("();", "");
                        string parse = toremove.Remove(0, 12); // Remove "File.create" as a way to parse.     
                        filemake = parse.ToString();
                        Cmdman.Clear_Src();
                        Filesystem.Filemake();

                    }
                    
                }


                if (input_cmd.StartsWith("File.delete "))
                {

                    if (!input_cmd.Contains("();"))
                    {

                        Console.WriteLine("ERROR: Missing a \"();\"");

                    }

                    else
                    {

                        string toremove = input_cmd.Replace("();", "");
                        string parse = toremove.Remove(0, 12); // Remove "File.create" as a way to parse.     
                        filedelete = parse.ToString();
                        Cmdman.Clear_Src();
                        Filesystem.Filedelete();

                    }

                }

                if (input_cmd.StartsWith("Directory.create "))
                {
                    
                    if (!input_cmd.Contains("();"))
                    {

                        Console.WriteLine("ERROR: Missing a \"();\"");

                    }
                    else
                    {

                        string toremove = input_cmd.Replace("();", "");
                        string parse = toremove.Remove(0, 17); // Remove "File.create" as a way to parse.     
                        dirmake = parse.ToString();
                        Cmdman.Clear_Src();
                        Filesystem.Dirmake();

                    }

                }

                if (input_cmd.StartsWith("Directory.delete "))
                {

                    if (!input_cmd.Contains("();"))
                    {

                        Console.WriteLine("ERROR: Missing a \"();\"");

                    }
                    else
                    {

                        string toremove = input_cmd.Replace("();", "");
                        string parse = toremove.Remove(0, 17); // Remove "File.create" as a way to parse.     
                        dirdelete = parse.ToString();
                        Cmdman.Clear_Src();
                        Filesystem.Dirdelete();

                    }

                }

                if (input_cmd.StartsWith("File.read "))
                {

                    if (!input_cmd.Contains("();"))
                    {

                        Console.WriteLine("ERROR: Missing a \"();\"");

                    }
                    else
                    {

                        string toremove = input_cmd.Replace("();", "");
                        string parse = toremove.Remove(0, 10); // Remove "File.create" as a way to parse.     
                        fileread = parse.ToString();
                        Cmdman.Clear_Src();
                        Filesystem.Fileread();

                    }

                }



                // If input has no characters.
                if (string.ReferenceEquals(input_cmd, null) || input_cmd.Length == 0)
                {

                    Console.WriteLine("Command cannot be empty or null.");

                }


            }

        }


    }

}












