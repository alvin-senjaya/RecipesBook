using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipesApp
{
    public partial class CategoryForm :Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                lbCategory.Sorted = true;
                lbCategory.DataSource = context.Categories.Select(item => item.Name).ToList();
                
            }
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                string categoryName = lbCategory.SelectedItem.ToString();

                Category categoryToBeDeleted = context.Categories.FirstOrDefault(c => c.Name == categoryName);

                DialogResult result = MessageBox.Show("Are you sure want to delete " + categoryName + " category? Every recipe belong to this category will be removed as well.", "Warning", MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation);

                // Perform delete category on cascade
                if (result == DialogResult.OK)
                {
                    try
                    {
                        context.Categories.Remove(categoryToBeDeleted);
                        context.SaveChanges();

                        MessageBox.Show("Category has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshList();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to delete the category. Category is used by another recipes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            gbCategoryData.Text = "New Data";
            tbCategoryName.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbCategoryData.Text = "Update Data";
            tbCategoryName.Text = lbCategory.SelectedItem.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Add new category
            if (gbCategoryData.Text == "New Data")
            {
                using (RecipesEntities context = new RecipesEntities())
                {
                    // Make sure there is no duplicate category
                    if (context.Categories.FirstOrDefault(c => c.Name == tbCategoryName.Text) == null)
                    {
                        Category newCategory = new Category
                        {
                            Name = tbCategoryName.Text
                        };
                        
                        context.Categories.Add(newCategory);
                        context.SaveChanges();
                        RefreshList();

                        MessageBox.Show("New category has been registered to the system.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Category name has already registered in the system.", "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
            }
            // Update category
            else
            {
                using (RecipesEntities context = new RecipesEntities())
                {
                    Category categoryToBeUpdated = context.Categories.FirstOrDefault(c => c.Name == lbCategory.SelectedItem.ToString());

                    // Make sure there is no duplicate category.
                    if (context.Categories.FirstOrDefault(c => c.Name == tbCategoryName.Text) == null)
                    {
                        categoryToBeUpdated.Name = tbCategoryName.Text;
                        context.SaveChanges();
                        RefreshList();

                        MessageBox.Show("Category has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Category name has already registered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                var searchItems = context.Categories.Where(item => item.Name.ToLower().Contains(tbSearch.Text.ToLower())).Select(item => item.Name).ToList();

                lbCategory.DataSource = searchItems.ToList();

                // Reset the items list if there is no search text.
                if (tbSearch.Text == "")
                {
                    RefreshList();
                }
            }
        }
    }
}
