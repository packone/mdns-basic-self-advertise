using Makaretu.Dns;

namespace mdns_basic_self_advertise;

public partial class Form1 : Form
{
    private readonly MulticastService mdns = new MulticastService();
    /// <summary>
    /// z.B. test123.local
    /// </summary>
    string? DomainNameApp;

    public Form1()
    {
        InitializeComponent();
        CheckBoxSwitchState();
    }

    /// <summary>
    /// mDNS Define
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <exception cref="Exception"></exception>
    private void QueryReceivedEvent(object? sender, MessageEventArgs e)
    {
        if (string.IsNullOrEmpty(DomainNameApp))
            throw new Exception("DomainNameApp not set");

        var message = e.Message;

        if (this.CheckBoxLog.Checked && this.CheckBoxLogAll.Checked)
            this.LogMessage(message);

        if (!message.Questions.Any(q => q.Name == DomainNameApp))
            return;

        if (this.CheckBoxLog.Checked)
            this.LogMessage(message);

        var linkLocalAddresses = MulticastService.GetLinkLocalAddresses();
        var response = message.CreateResponse();
        //response.Answers.Add(new ARecord { Name = "app1.local", Address = System.Net.IPAddress.Parse("127.0.0.1") });
        response.Answers.AddRange(linkLocalAddresses.Where(w => w.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToList()
            .ConvertAll(c => new ARecord { Name = DomainNameApp, Address = c }));
        mdns.SendAnswer(response);
        if (this.CheckBoxLog.Checked)
            this.LogMessage(response);
    }

    private void ClickMDNSStart()
    {
        string domainText = this.TextBoxDomain.Text;
        if (string.IsNullOrEmpty(domainText))
        {
            this.CheckBoxSwitch.Checked = false;
            CheckBoxSwitchState();
            LogMessage($"{LabelDomainName.Text} darf nicht leer sein.");
            return;
        }

        DomainNameApp = domainText;
        mdns.QueryReceived += QueryReceivedEvent;
        mdns.Start();
        LogMessage("gestartet");
    }

    private void ClickMDNSStop()
    {
        mdns.Stop();
        LogMessage("gestoppt");
    }

    private void CheckBoxSwitch_CheckedChanged(object sender, EventArgs e)
    {
        CheckBoxSwitchState();

        if (this.CheckBoxSwitch.Checked)
            ClickMDNSStart();
        else
            ClickMDNSStop();
    }

    private void CheckBoxSwitchState()
    {
        this.CheckBoxSwitch.Text = this.CheckBoxSwitch.Checked ? "mDNS stoppen" : "mDNS starten";
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.CheckBoxSwitch.Checked)
            ClickMDNSStop();
    }

    void LogMessage(Makaretu.Dns.Message MDNSMessage)
    {
        this.LogMessage(
            string.Join(" ", new[] {
                "mDNS Message",
                MDNSMessage.CreationTime.ToString(),
                "Questions",
                MDNSMessage.Questions.Count.ToString(),
                string.Join(" ", MDNSMessage.Questions.ConvertAll(c => string.Join(" ", new[]{
                    c.Class.ToString(),
                    c.Type.ToString(),
                    c.CreationTime.ToString(),
                    c.Name.ToString()
                }))),
                "Answers",
                MDNSMessage.Answers.Count.ToString(),
                string.Join(" ", MDNSMessage.Answers.ConvertAll(c => string.Join(" ", new[]{
                    c.Class.ToString(),
                    c.Type.ToString(),
                    c.CreationTime.ToString(),
                    c.Name.ToString()
                }))),
            }));
    }

    void LogMessage(string Message)
    {
        if (InvokeRequired)
        {
            this.Invoke(new Action<string>(LogMessage), new object[] { Message });
            return;
        }

        this.RichTextBoxLog.AppendText(
            string.Join(" ", new[] {
                DateTime.Now.ToString("hh:mm:ss.fff"),
                Message,
                Environment.NewLine
            }));
        this.RichTextBoxLog.ScrollToCaret();

        // TODO UI controlable
        const int LinesKeept = 500;
        int currentLineCount = this.RichTextBoxLog.Lines.Length;
        if (currentLineCount > LinesKeept && !this.CheckBoxKeepLog.Checked)
            this.RichTextBoxLog.Lines = this.RichTextBoxLog.Lines.Skip(currentLineCount - LinesKeept).ToArray();
    }

    private void ButtonClearLog_Click_1(object sender, EventArgs e)
    {
        this.RichTextBoxLog.Clear();
    }
}
