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
    public partial class IngredientForm :Form
    {
        public IngredientForm()
        {
            InitializeComponent();
        }

        private void RefreshList()
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                lbIngredient.Sorted = true;
                lbIngredient.DataSource = context.Ingredients.Select(item => item.Name).ToList();

            }
        }

        private void IngredientForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                string ingredientName = lbIngredient.SelectedItem.ToString();

                Ingredient ingredientToBeDeleted = context.Ingredients.FirstOrDefault(i => i.Name == ingredientName);

                DialogResult result = MessageBox.Show("Are you sure want to delete " + ingredientName + " ingredient? Every recipe that has this ingredient will be removed as well.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                // Perform delete category on cascade
                if (result == DialogResult.OK)
                {
                    try
                    {
                        context.Ingredients.Remove(ingredientToBeDeleted);
                        context.SaveChanges();

                        MessageBox.Show("Ingredient has been deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        RefreshList();
                    }
                    catch
                    {
                        MessageBox.Show("Unable to delete the Ingredients. Ingredients is used in another recipes.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            gbIngredientData.Text = "New Data";
            tbIngredientName.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbIngredientData.Text = "Update Data";
            tbIngredientName.Text = lbIngredient.SelectedItem.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Add new ingredient
            if (gbIngredientData.Text == "New Data")
            {
                using (RecipesEntities context = new RecipesEntities())
                {
                    // Make sure there is no duplicate ingredient
                    if (context.Ingredients.FirstOrDefault(i => i.Name == tbIngredientName.Text) == null)
                    {
                        Ingredient newIngredient = new Ingredient
                        {
                            Name = tbIngredientName.Text
                        };

                        context.Ingredients.Add(newIngredient);
                        context.SaveChanges();
                        RefreshList();

                        MessageBox.Show("New ingredients has been registered to the system.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ingredients name has already registered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            // Update ingredient
            else
            {
                using (RecipesEntities context = new RecipesEntities())
                {
                    Ingredient ingredientToBeUpdated = context.Ingredients.FirstOrDefault(i => i.Name == lbIngredient.SelectedItem.ToString());

                    // Make sure there is no duplicate category.
                    if (context.Categories.FirstOrDefault(c => c.Name == tbIngredientName.Text) == null)
                    {
                        ingredientToBeUpdated.Name = tbIngredientName.Text;
                        context.SaveChanges();
                        RefreshList();

                        MessageBox.Show("Ingredient has been updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ingredient name has already registered in the system.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            using (RecipesEntities context = new RecipesEntities())
            {
                var searchItems = context.Ingredients.Where(item => item.Name.ToLower().Contains(tbSearch.Text.ToLower())).Select(item => item.Name).ToList();

                lbIngredient.DataSource = searchItems.ToList();

                // Reset the items list if there is no search text.
                if (tbSearch.Text == "")
                {
                    RefreshList();
                }
            }
        }
    }
}
