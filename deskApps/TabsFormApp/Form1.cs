namespace TabsFormApp;

public partial class Form1 : Form
{
    TabControl tabControlMain;
    public Form1()
    {
        InitializeComponent();

        // Call your custom setup method here to dynamically create the TabControl
        SetupTabControl();
    }

    // 1. Your Custom Setup Method
        private void SetupTabControl()
    {
        // --- 1. Define Constants and Dimensions ---
    const int TabHeight = 25;
    const int ButtonWidth = 25;
    const int PanelWidth = 400;
    const int TabControlTotalWidth = 800; // Must be wider than PanelWidth to require scrolling
    const int NumberOfTabs = 20;

    // --- 2. Create the Viewport Panel ---
    Panel pnlTabViewport = new Panel();
    pnlTabViewport.Name = "pnlTabViewport";
    pnlTabViewport.Location = new Point(10 + ButtonWidth, 10); // Starts after the left button
    pnlTabViewport.Size = new Size(PanelWidth, TabHeight);
    pnlTabViewport.BorderStyle = BorderStyle.FixedSingle;
    pnlTabViewport.AutoScroll = false; // Crucial: Prevents native panel scrollbars

    // --- 3. Create the Scroll Buttons ---
    Button btnScrollLeft = new Button();
    btnScrollLeft.Name = "btnScrollLeft";
    btnScrollLeft.Text = "<";
    btnScrollLeft.Location = new Point(10, 10);
    btnScrollLeft.Size = new Size(ButtonWidth, TabHeight);
        btnScrollLeft.Click += btnScrollLeft_Click; // Wire up custom logic

        Button btnScrollRight = new Button();
btnScrollRight.Name = "btnScrollRight";
btnScrollRight.Text = ">"; // Set the text shown on the button
btnScrollRight.Size = new Size(ButtonWidth, TabHeight);

// Location: Place the button immediately to the right of the viewport panel (pnlTabViewport)
// pnlTabViewport starts at (10 + ButtonWidth)
// Its width is PanelWidth
// So, the button starts at: pnlTabViewport.Location.X + pnlTabViewport.Width
btnScrollRight.Location = new Point(10 + ButtonWidth + PanelWidth, 10);

        // Wire up the custom scrolling logic to the Click event
        btnScrollRight.Click += btnScrollRight_Click;




        // Create the TabControl
        TabControl tabControl = new TabControl();
        tabControlMain = tabControl;

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

        // --- 6. Establish Control Hierarchy ---
    
    // Add TabControl to the Panel (Making the Panel its parent/viewport)
    // pnlTabViewport.Controls.Add(tabControlMain);

    // Add the Panel and Buttons to the Form
    // this.Controls.Add(pnlTabViewport);
    // this.Controls.Add(btnScrollLeft);
    // this.Controls.Add(btnScrollRight);
    }

    // 2. Your Event Handler
    private void LoadButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Data is loading...", "Action Performed");
    }

    private const int TabsPerPage = 4; // Define how many tabs to scroll at once

private void btnScrollRight_Click(object sender, EventArgs e)
{
    // Find the total width of the next 'TabsPerPage' tabs
    int scrollWidth = GetScrollWidth(true);

    if (scrollWidth > 0)
    {
        // Move the TabControl's X location to the LEFT by the scroll width
        tabControlMain.Location = new Point(
            tabControlMain.Location.X - scrollWidth,
            tabControlMain.Location.Y);
    }
}

private void btnScrollLeft_Click(object sender, EventArgs e)
{
    // Find the total width of the previous 'TabsPerPage' tabs
    int scrollWidth = GetScrollWidth(false);

    // If scrollWidth is 0, it means we are already at the far left or close to it
    if (scrollWidth > 0)
    {
        // Move the TabControl's X location to the RIGHT by the scroll width
        int newX = tabControlMain.Location.X + scrollWidth;

        // Ensure we don't move past the starting position (X=0)
        if (newX > 0) 
        {
            newX = 0;
        }

        tabControlMain.Location = new Point(newX, tabControlMain.Location.Y);
    }
}

/// <summary>
/// Calculates the total pixel width of the next/previous set of tabs to scroll.
/// </summary>
private int GetScrollWidth(bool scrollRight)
{
    int totalWidth = 0;
    
    // Find the index of the first tab currently visible/hidden
    int currentX = tabControlMain.Location.X;
    int firstTabIndex = -1;

    // Iterate through tabs to find which one is currently at the panel's left edge
    for (int i = 0; i < tabControlMain.TabPages.Count; i++)
    {
        Rectangle rect = tabControlMain.GetTabRect(i);
        // We look for the tab whose right edge is close to the Panel's left edge (currentX)
        if (rect.X >= Math.Abs(currentX)) 
        {
            firstTabIndex = i;
            break;
        }
    }
    
    // If no tab is perfectly aligned, start approximation from the first tab
    if (firstTabIndex == -1) firstTabIndex = 0; 
    
    // Determine the range of tabs for which to calculate the scroll width
    int startIndex = scrollRight ? firstTabIndex : Math.Max(0, firstTabIndex - TabsPerPage);
    int endIndex = scrollRight ? Math.Min(tabControlMain.TabPages.Count, startIndex + TabsPerPage) : firstTabIndex;
    
    for (int i = startIndex; i < endIndex; i++)
    {
        // Use GetTabRect to get the precise width of the tab header
        totalWidth += tabControlMain.GetTabRect(i).Width;
    }

    return totalWidth;
}
}
