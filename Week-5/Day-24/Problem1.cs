////problem 1 – level 1
////scenario:
////a small organization wants to store simple log messages into a text file using a c# console application.
////requirements:
////1.accept a message from the user.
////2. write the message into a file using filestream.
////3.append multiple messages to the same file.
////4. display confirmation after writing the data.
////technical constraints:
////• use filestream class.
////• use appropriate filemode and fileaccess.
////• implement exception handling for file access errors.
////expectations:
////the application should successfully write user messages to the file and allow multiple entries.
////learning outcome:
////students will learn how to create and write data into files using filestream.

//using system;
//using system.io;
//using system.text;
//namespace ConsoleApp1
//{




//class program
//{
//    static void main(string[] args)
//    {
//        string filepath = "application_log.txt";

//        console.writeline("log message application");
//        console.writeline("-------------------------");

//        while (true)
//        {
//            console.write("enter a message to log (or type 'exit' to quit): ");
//            string message = console.readline();

//            if (message.tolower() == "exit")
//            {
//                break;
//            }

//            if (string.isnullorwhitespace(message))
//            {
//                console.writeline("message cannot be empty. please try again.");
//                continue;
//            }

//            // add a timestamp to the message
//            string logentry = $"{datetime.now}: {message}\n";

//            try
//            {
//                // use filestream to open the file in append mode
//                // filemode.append opens the file if it exists and seeks to the end,
//                // or creates a new file if it doesn't 
//                // fileaccess.write specifies that the file is opened for writing data 
//                using (filestream fs = new filestream(filepath, filemode.append, fileaccess.write))
//                {
//                    // convert the string message to a byte array
//                    byte[] info = new utf8encoding(true).getbytes(logentry);

//                    // write the data to the file
//                    fs.write(info, 0, info.length);
//                }

//                console.writeline($"\n[success] message successfully written to {filepath}\n");
//            }
//            catch (ioexception ex)
//            {
//                // handle potential file i/o errors
//                console.writeline($"\n[error] an i/o exception occurred: {ex.message}\n");
//            }
//            catch (exception ex)
//            {
//                // handle other potential errors
//                console.writeline($"\n[error] an unexpected error occurred: {ex.message}\n");
//            }
//        }
//    }
//}
//}
