using System;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class ShoppingListForm : Form
    {
        private string item = "";

        public ShoppingListForm()
        {
            InitializeComponent();
        }
                
        private bool IsNotEqualItem
        {
            get
            {
                DeleteSpacebar();
                return item.Length > 0 && ItemCheckedListBox.FindStringExact(item) == -1;
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            ItemCheckedListBox.Items.Add(item);
            buttonAdd.Enabled = false;
            ItemTextBox.Clear();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            ItemCheckedListBox.Items.RemoveAt(ItemCheckedListBox.SelectedIndex);
            buttonDelete.Enabled = false;            
            FindSimilarItems();
        }

        private void ItemCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonDelete.Enabled = true;
        }

        private void ItemTextBox_TextChanged(object sender, EventArgs e)
        {
            FindSimilarItems();
            buttonAdd.Enabled = IsNotEqualItem;
        }

        private void DeleteSpacebar()
        {
            char[] symbol = { ' ' };
            string[] words = ItemTextBox.Text.Split(symbol, StringSplitOptions.RemoveEmptyEntries);
            item = string.Join(" ", words);
        }

        private void FindSimilarItems()
        {
            string similarItem = ItemTextBox.Text;
            similarItem = similarItem.Trim();
            foreach (object clone in ItemCheckedListBox.Items)
            {
                string cloneElement = clone.ToString();
                if (cloneElement == similarItem)
                {
                    buttonAdd.Enabled = false;
                    break;
                }
                else
                {
                    buttonAdd.Enabled = true;
                }
            }

            if (ItemTextBox.Text.Length == 0)
            {
                buttonAdd.Enabled = false;
            }
        }
    }
}