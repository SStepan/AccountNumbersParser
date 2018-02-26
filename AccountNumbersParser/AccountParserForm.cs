using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AccountNumbersParser
{
    public partial class AccountParserForm : Form
    {
        private string filePath;
        private string errorMessage = "File is not valid. Choose another file.";

        public AccountParserForm()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            openFileDialog1.InitialDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK) {
                filePath = openFileDialog1.FileName;
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(filePath)) {
                StreamReader streamReader = new StreamReader(filePath);
                var text = streamReader.ReadToEnd();

                Regex regex = new Regex(@"[^\s_|]");
                if (regex.IsMatch(text)) {
                    MessageBox.Show(errorMessage);
                    button2.Enabled = false;
                    return;
                }

                List<string> faxNumbers = new List<string>();
                var lines = text.Split(new string[] { "\r", "\n", "\r\n" }, StringSplitOptions.None).ToList();
                lines.RemoveAll(t => string.IsNullOrEmpty(t));

                if (lines.Count % 3 != 0) {
                    MessageBox.Show(errorMessage);
                    button2.Enabled = false;
                    return;
                }
                else
                {
                    for (int i = 0; i < lines.Count; i = i + 3) 
                    {
                        string number = string.Empty;
                        for (int j = 0; j < 9; j++) {
                            var faxNumber = string.Empty;
                            int skipCount = 0;
                            if (j != 0) {
                                skipCount = j * 3;
                            }

                            faxNumber = lines[i].Substring(skipCount, 3);
                            faxNumber += lines[i + 1].Substring(skipCount, 3);
                            faxNumber += lines[i + 2].Substring(skipCount, 3);
                            number += FaxNumbers.GetNumber(faxNumber);
                        }
                        faxNumbers.Add(number);
                    }
                }

                textBox1.Text = String.Join("\r\n", faxNumbers);
            }
        }
    }
}
