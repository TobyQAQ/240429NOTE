using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _240429NOTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnOpen_Click(object sender, EventArgs e)
        {
            // 設置對話方塊標題
            openFileDialog1.Title = "選擇檔案";
            // 設置對話方塊篩選器，限制使用者只能選擇特定類型的檔案
            openFileDialog1.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";
            // 如果希望預設開啟的檔案類型是文字檔案，可以這樣設置
            openFileDialog1.FilterIndex = 1;
            // 如果希望對話方塊在開啟時顯示的初始目錄，可以設置 InitialDirectory
            openFileDialog1.InitialDirectory = "C:\\";
            // 允許使用者選擇多個檔案
            openFileDialog1.Multiselect = true;

            // 顯示對話方塊，並等待使用者選擇檔案
            DialogResult result = openFileDialog1.ShowDialog();

            // 檢查使用者是否選擇了檔案
            if (result == DialogResult.OK)
            {
                try
                {
                    // 使用者在OpenFileDialog選擇的檔案
                    string selectedFileName = openFileDialog1.FileName;

                    //// 使用 FileStream 打開檔案
                    //// 建立一個檔案資料流，並且設定檔案名稱與檔案開啟模式為「開啟檔案」
                    //FileStream fileStream = new FileStream(selectedFileName, FileMode.Open, FileAccess.Read);
                    //// 讀取資料流
                    //StreamReader streamReader = new StreamReader(fileStream);
                    //// 將檔案內容顯示到 RichTextBox 中
                    //rtbText.Text = streamReader.ReadToEnd();
                    //// 關閉資料流與讀取資料流
                    //fileStream.Close();
                    //streamReader.Close();

                    // 使用 using 與 FileStream 打開檔案
                    using (FileStream fileStream = new FileStream(selectedFileName, FileMode.Open, FileAccess.Read))
                    {
                        // 使用 StreamReader 讀取檔案內容
                        using (StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8))
                        {
                            // 將檔案內容顯示到 RichTextBox 中
                            richTextBox1.Text = streamReader.ReadToEnd();
                        }
                    }
                    //// 更為簡單的做法，將檔案內容顯示到 RichTextBox 中
                    //string fileContent = File.ReadAllText(selectedFileName);
                    //rtbText.Text = fileContent;
                }
                catch (Exception ex)
                {
                    // 如果發生錯誤，用MessageBox顯示錯誤訊息
                    MessageBox.Show("讀取檔案時發生錯誤: " + ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("使用者取消了選擇檔案操作。", "訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 建立 SaveFileDialog 物件
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // 設置對話方塊標題
            saveFileDialog1.Title = "儲存檔案";

            // 設置對話方塊篩選器，限制使用者只能儲存特定類型的檔案
            saveFileDialog1.Filter = "文字檔案 (*.txt)|*.txt|所有檔案 (*.*)|*.*";

            // 如果希望預設儲存的檔案類型是文字檔案，可以這樣設置
            saveFileDialog1.FilterIndex = 1;

            // 如果希望對話方塊在儲存時顯示的初始目錄，可以設置 InitialDirectory
            saveFileDialog1.InitialDirectory = "C:\\";

            // 顯示對話方塊，並等待使用者指定儲存的檔案位置
            DialogResult result = saveFileDialog1.ShowDialog();

            // 檢查使用者是否確定儲存檔案
            if (result == DialogResult.OK)
            {
                try
                {
                    // 取得使用者指定的儲存檔案路徑
                    string saveFileName = saveFileDialog1.FileName;

                    // 將 RichTextBox 中的內容寫入到檔案中
                    File.WriteAllText(saveFileName, richTextBox1.Text);

                    // 顯示儲存成功的訊息框
                    MessageBox.Show("檔案已成功儲存。", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // 如果發生錯誤，用 MessageBox 顯示錯誤訊息
                    MessageBox.Show("儲存檔案時發生錯誤: " + ex.Message, "錯誤訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 使用者取消了儲存檔案操作，顯示訊息框
                MessageBox.Show("使用者取消了儲存檔案操作。", "訊息", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}

