using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;

namespace othello7Library
{
    /// <summary>
    /// Writes to a .txt file.
    /// Instansiate a version with the destinatoin file.
    /// </summary>
    public class Write
    {
        public Write()
        {
        }
        public Write(string Destination)
        {
            DestinationFile = Destination;
        }
        /// <summary>
        ///File to write to
        /// </summary>
        public string DestinationFile { get; set; }

        /// <summary>
        ///Writes to a line on (string) DestinationFile.
        ///
        /// </summary>
        ///<param name = "lineNumber" > The line number (starting on 0) to write to.</param>
        public void ToThisTxt(int lineNumber, string value)
        {
            try
            {
                string[] Content = System.IO.File.ReadAllLines(DestinationFile);


                try
                {
                    Content[lineNumber] = value;
                }
                catch (System.IndexOutOfRangeException)
                {
                    //MessageBox.Show("System.IndexOutOfRangeException in Write.ToThisTxt");
                }

                System.IO.File.WriteAllLines(DestinationFile, Content);
            }
            catch (Exception)
            {
                //MessageBox.Show("Write.ToThisTxt " + ex);
            }
        }
    }
}
