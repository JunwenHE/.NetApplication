using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{
    // This class is the edior form which can edit the text
    public partial class EditForm : Form
    {
        //Decalre path for saving and opening.
        private string fileNameWithFullPath;

        public EditForm(LogginUser logginUser)
        {
            //Call the logginUser to display the current user who login to the eidtor and identify the edit or view mode.
            InitializeComponent();
            fileNameWithFullPath = "";
            ToolStripLabel1.Text = "Username: " + logginUser.UserName;
            if (logginUser.UserType == "View")
            {
                RichTextBoxEdit.ReadOnly = true;
            }
       
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }

        private void ToolStripButtonBold_Click(object sender, EventArgs e)
        {
            /* Declare an edit feature that can display the stautes. 
             * The button colour will change once the bold effect is active,
             * Then click the button again, the feature and colour will restore to noraml.
             * The following italic and underline both have same effect.
             */
            if (RichTextBoxEdit.SelectionFont != null)
            {
                Font currentFont = RichTextBoxEdit.SelectionFont;
                FontStyle newFontStyle;

                if (RichTextBoxEdit.SelectionFont.Bold == true)
                {
                    newFontStyle = FontStyle.Regular;
                    ToolStripButtonBold.BackColor = default(Color);
                }
                else
                {
                    newFontStyle = FontStyle.Bold;
                    ToolStripButtonBold.BackColor = Color.Gray;

                }

                RichTextBoxEdit.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        private void ToolStripButtonItalic_Click(object sender, EventArgs e)
        {
            if (RichTextBoxEdit.SelectionFont != null)
            {
                Font currentFont = RichTextBoxEdit.SelectionFont;
                FontStyle newFontStyle;

                if (RichTextBoxEdit.SelectionFont.Italic == true)
                {
                    newFontStyle = FontStyle.Regular;
                    ToolStripButtonItalic.BackColor = default(Color);


                }
                else
                {
                    newFontStyle = FontStyle.Italic;
                    ToolStripButtonItalic.BackColor = Color.Gray;

                }

                RichTextBoxEdit.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }

        }

        private void ToolStripButtonUnderline_Click(object sender, EventArgs e)
        {
            if (RichTextBoxEdit.SelectionFont != null)
            {
                Font currentFont = RichTextBoxEdit.SelectionFont;
                FontStyle newFontStyle;

                if (RichTextBoxEdit.SelectionFont.Underline == true)
                {
                    newFontStyle = FontStyle.Regular;
                    ToolStripButtonUnderline.BackColor = default(Color);


                }
                else
                {
                    newFontStyle = FontStyle.Underline;
                    ToolStripButtonUnderline.BackColor = Color.Gray;

                }

                RichTextBoxEdit.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEdit.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEdit.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEdit.Paste();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RichTextBoxEdit.Clear();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open file and provide the path to the initial variable for the saving
            OpenFileDialog openFile = new OpenFileDialog();
            try
            {
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    fileNameWithFullPath = openFile.FileName.ToString();
                    string textOfFile = File.ReadAllText(fileNameWithFullPath);
                    RichTextBoxEdit.Text = textOfFile;
                    MessageBox.Show("Open success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Open failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open the dialog for saving file into the path
            SaveFileDialog saveAsFile = new SaveFileDialog();
            saveAsFile.FileName = "New file";
            saveAsFile.Title = "Save new file";
            saveAsFile.Filter = "Rich Text Format(*.rtf) | *.rtf";
            if(saveAsFile.ShowDialog() == DialogResult.OK)
            {
                string contentOfRichTextBox = RichTextBoxEdit.Text;
                StreamWriter streamWriter = new StreamWriter(Path.Combine(fileNameWithFullPath, saveAsFile.FileName));
                streamWriter.Write(contentOfRichTextBox);
                streamWriter.Close();
                MessageBox.Show("Saved success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fileNameWithFullPath = Path.Combine(fileNameWithFullPath, saveAsFile.FileName).ToString();
            }
        }

        private void ToolStripComboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Using the combo box of the font size to effect the for size in the richtextbox
            if(RichTextBoxEdit.SelectedText.Length > 0)
            {
                RichTextBoxEdit.SelectionFont = new Font(RichTextBoxEdit.Font.FontFamily, Convert.ToInt32(ToolStripComboBoxFontSize.SelectedItem), RichTextBoxEdit.Font.Style);
            }

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save the file without open the save dialog.
            //If the path dones't exist, then open save dialog.
            try
            {
                string contentOfRichTextBox = RichTextBoxEdit.Text;
                StreamWriter streamWriter = new StreamWriter(fileNameWithFullPath);
                streamWriter.Write(contentOfRichTextBox);
                streamWriter.Close();
                MessageBox.Show("Saved success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception error)

            {
                MessageBox.Show("Cannot find the path! Please save as the file.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.FileName = "New file";
                saveFile.Title = "Save new file";
                saveFile.Filter = "Rich Text Format(*.rtf) | *.rtf";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string contentOfRichTextBox = RichTextBoxEdit.Text;
                    StreamWriter sw = new StreamWriter(Path.Combine(fileNameWithFullPath, saveFile.FileName));
                    sw.Write(contentOfRichTextBox);
                    sw.Close();
                    MessageBox.Show("Saved success!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fileNameWithFullPath = Path.Combine(fileNameWithFullPath, saveFile.FileName).ToString();
                }
            }
            
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.Show();
        }
    }
}
