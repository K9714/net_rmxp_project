using System.Windows.Forms;

namespace DB_Manager
{
    class Console
    {
        static private RichTextBox consoleBox;
        static public void setup(object _consoleBox)
        {
            consoleBox = _consoleBox as RichTextBox;
        }

        static public void write(string text)
        {
            consoleBox.Text = text + "\n" + consoleBox.Text;
        }
        static public void warning(string text)
        {
            consoleBox.Text = "[경고] " + text + "\n" + consoleBox.Text;
        }
        static public void info(string text)
        {
            consoleBox.Text = "[알림] " + text + "\n" + consoleBox.Text;
        }
        static public void clear()
        {
            consoleBox.Clear();
        }
    }
}
