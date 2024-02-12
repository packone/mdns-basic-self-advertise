using Makaretu.Dns;
using Microsoft.VisualBasic;
using System.Globalization;

namespace mdns_basic_self_advertise;

public partial class MainForm : Form
{
    private readonly MulticastService mdns = new MulticastService();
    /// <summary>
    /// z.B. test123.local
    /// </summary>
    string? DomainNameApp;

    public MainForm()
    {
        // test languages
        //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
        InitializeComponent();
        CheckBoxSwitchState();

        //load Translations
        CheckBoxLogAll.Text = Resources.LogAll;
        CheckBoxKeepLog.Text = Resources.KeepLog;
        ButtonClearLog.Text = Resources.ClearLog;

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
            throw new Exception($"{nameof(DomainNameApp)}{Resources.exceptionPropNotSet}");

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
            LogMessage($"{LabelDomainName.Text}{Resources.inputNotEmpty}");
            return;
        }

        DomainNameApp = domainText;
        mdns.QueryReceived += QueryReceivedEvent;
        mdns.Start();
        LogMessage(Resources.started);
    }

    private void ClickMDNSStop()
    {
        mdns.Stop();
        LogMessage(Resources.stopped);
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
        this.CheckBoxSwitch.Text = this.CheckBoxSwitch.Checked ? Resources.checkBoxSwitchMDNSStop : Resources.checkBoxSwitchMDNSStart;
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (this.CheckBoxSwitch.Checked)
            ClickMDNSStop();
    }

    void LogMessage(Makaretu.Dns.Message MDNSMessage)
    {
        this.LogMessage(
            string.Join(Resources.spaceChar, new[] {
                Resources.mDNSMessage,
                MDNSMessage.CreationTime.ToString(),
                nameof(MDNSMessage.Questions),
                MDNSMessage.Questions.Count.ToString(),
                string.Join(Resources.spaceChar, MDNSMessage.Questions.ConvertAll(c => string.Join(Resources.spaceChar, new[]{
                    c.Class.ToString(),
                    c.Type.ToString(),
                    c.CreationTime.ToString(),
                    c.Name.ToString()
                }))),
                nameof(MDNSMessage.Answers),
                MDNSMessage.Answers.Count.ToString(),
                string.Join(Resources.spaceChar, MDNSMessage.Answers.ConvertAll(c => string.Join(Resources.spaceChar, new[]{
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
            string.Join(Resources.spaceChar, new[] {
                DateTime.Now.ToString(Resources.dateTimeStringFormat),
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
