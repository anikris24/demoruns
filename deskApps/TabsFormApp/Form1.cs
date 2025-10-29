namespace TabsFormApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();

        // Call your custom setup method here to dynamically create the TabControl
        SetupTabControl();
    }

    // 1. Your Custom Setup Method
        private void SetupTabControl()
    {
        // Create the TabControl
        TabControl tabControl = new TabControl();
        tabControl.Name = "mainTabControl";
        tabControl.Location = new Point(10, 10);
        tabControl.Size = new Size(400, 300);

        // Create and add TabPages and their contents...
        TabPage dataTab = new TabPage("Data View");
        Button loadButton = new Button { Text = "Load Data", Location = new Point(20, 20) };
        loadButton.Click += LoadButton_Click;
        dataTab.Controls.Add(loadButton);

        tabControl.TabPages.Add(dataTab);

        // Add the TabControl to the Form
        this.Controls.Add(tabControl);

        // 2. Loop 'n' times to create and configure each TabPage
        for (int i = 1; i <= numberOfTabs; i++)
        {
            // a. Create a new TabPage object
            TabPage newPage = new TabPage();

            // b. Set the tab's Text (what the user sees on the tab header)
            newPage.Text = $"Tab {i}";

            // c. Set the tab's Name (useful for code reference)
            newPage.Name = $"tabPage_{i}";

            // d. OPTIONAL: Add some content to the TabPage
            Label label = new Label();
            label.Text = $"Content for {newPage.Text}";
            label.Location = new System.Drawing.Point(10, 10);
            newPage.Controls.Add(label);

            // e. Add the new TabPage to the TabControl's collection
            tabControl.TabPages.Add(newPage);
        }
    }

    // 2. Your Event Handler
    private void LoadButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Data is loading...", "Action Performed");
        }
}
