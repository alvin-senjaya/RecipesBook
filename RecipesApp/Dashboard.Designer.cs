namespace RecipesApp
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCategory = new System.Windows.Forms.Button();
            this.btnIngredient = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCategory
            // 
            this.btnCategory.Location = new System.Drawing.Point(18, 19);
            this.btnCategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCategory.Name = "btnCategory";
            this.btnCategory.Size = new System.Drawing.Size(138, 84);
            this.btnCategory.TabIndex = 0;
            this.btnCategory.Text = "Category";
            this.btnCategory.UseVisualStyleBackColor = true;
            this.btnCategory.Click += new System.EventHandler(this.btnCategory_Click);
            // 
            // btnIngredient
            // 
            this.btnIngredient.Location = new System.Drawing.Point(164, 19);
            this.btnIngredient.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnIngredient.Name = "btnIngredient";
            this.btnIngredient.Size = new System.Drawing.Size(138, 84);
            this.btnIngredient.TabIndex = 0;
            this.btnIngredient.Text = "Ingredient";
            this.btnIngredient.UseVisualStyleBackColor = true;
            // 
            // btnRecipe
            // 
            this.btnRecipe.Location = new System.Drawing.Point(310, 19);
            this.btnRecipe.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(138, 84);
            this.btnRecipe.TabIndex = 0;
            this.btnRecipe.Text = "Recipe";
            this.btnRecipe.UseVisualStyleBackColor = true;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 123);
            this.Controls.Add(this.btnRecipe);
            this.Controls.Add(this.btnIngredient);
            this.Controls.Add(this.btnCategory);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCategory;
        private System.Windows.Forms.Button btnIngredient;
        private System.Windows.Forms.Button btnRecipe;
    }
}

