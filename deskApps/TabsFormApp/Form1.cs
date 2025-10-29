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
        tabControl.Dock = DockStyle.Fill;
        tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;

        // Create and add TabPages and their contents...
        TabPage dataTab = new TabPage("Data View");
        Button loadButton = new Button { Text = "Load Data", Location = new Point(20, 20) };
        loadButton.Click += LoadButton_Click;
        dataTab.Controls.Add(loadButton);

        tabControl.TabPages.Add(dataTab);

        // Add the TabControl to the Form
        this.Controls.Add(tabControl);

        int numberOfTabs = 20;

        // 2. Loop 'n' times to create and configure each TabPage
        for (int i = 1; i <= numberOfTabs; i++)
        {
            int labelNumber = i;
            // a. Create a new TabPage object
            TabPage newPage = new TabPage();

            // b. Set the tab's Text (what the user sees on the tab header)
            newPage.Text = $"Tab {i}";

            // c. Set the tab's Name (useful for code reference)
            newPage.Name = $"tabPage_{i}";

            Panel coloredRectPanel = new Panel();
    coloredRectPanel.Name = $"panelRect_{labelNumber}";
    coloredRectPanel.Location = new Point(50, 50 + (1 * 80)); // Position each panel below the last
    coloredRectPanel.Size = new Size(250, 60); // Set the size of your rectangle
    coloredRectPanel.BackColor = Color.LightSkyBlue; // Set the fill color for the rectangle
    coloredRectPanel.BorderStyle = BorderStyle.FixedSingle;

            // d. OPTIONAL: Add some content to the TabPage
            Label label = new Label();
            label.Text = $"Content for {newPage.Text}";
            label.Location = new System.Drawing.Point(10, 10);
            label.Size = new System.Drawing.Size(600, 20);
            label.Dock = DockStyle.Fill;
            label.AutoSize = false;

            coloredRectPanel.Controls.Add(label);
            newPage.Controls.Add(coloredRectPanel);

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
