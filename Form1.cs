using System;
using System.IO;
using System.Threading;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace FastXMLtoCSV {
    public partial class Form1 : Form {
        public Form1() { InitializeComponent(); }

        // Class who contains global stuff
        public static class Global {
            private static string _cDir             = Directory.GetCurrentDirectory() + "\\";

            public static string LogFilePath        = _cDir + "log.txt";
            public static string ConfigFilePath     = _cDir + "configuration.xml";
            public static string XMLNodesDirPath    = _cDir + "Nodes_Filter";
            public static string XMLSuccessPath     = "";
            public static string XMLBadPath         = "";

            public static bool   XMLNodeAliasEmpty  = false; // We need this to know when the 'Node Alias' textbox looses the focus if the textbox was empty or not
            public static bool   XMLScanningAbort   = false;
            public static bool   XMLConversionAbort = false;

            public static bool   MonitoringAbort    = false;

            public static bool   ToolStartedNow     = true;

            public static class GUI {
                public static bool XMLPathChanged           = false;
                public static bool CSVPathChanged           = false;
                public static bool CSVFileNameChanged       = false;
                public static bool CSVFileNamePrefixChanged = false;
                public static bool CSVFileNameSuffixChanged = false;
                public static bool MonitoringHrsChanged     = false;
                public static bool MonitoringMinChanged     = false;
                public static bool MonitoringSecChanged     = false;
                public static bool MonitoringCsvBadChanged  = false;
            }

            // We need this to retrieve the node values from the listview
            public static string[] GetNodeValues(Form1 _frm) {
                // Initialize the Node Values
                string[] _nodeValue = new string[3];
                // Loads the node values from the listview
                _nodeValue[0] = _frm.xmlNodesFilter_listview.SelectedItems[0].Text;
                _nodeValue[1] = _frm.xmlNodesFilter_listview.SelectedItems[0].SubItems[1].Text;
                _nodeValue[2] = _frm.xmlNodesFilter_listview.SelectedItems[0].Checked.ToString();

                return _nodeValue;
            }
            
            // We will call this when the tool is closing
            public static void Cleanup(Form1 _frm) {
                XMLScanningAbort   = true;
                MonitoringAbort    = true;
                XMLConversionAbort = true;

                Log._File.Write(Log._File.MessageType.TOOL_STOPPED);
            }

            // We need this function to can get if a XML is locked or not
            public static bool FileIsLocked(string FilePath) {
                FileStream _stream = null;

                try {
                    _stream = (new FileInfo(FilePath)).Open(FileMode.Open, FileAccess.Read, FileShare.None);
                } catch (IOException) {
                    return true;
                } finally {
                    if (_stream != null)
                        _stream.Close();
                }

                return false;
            }
        }

        #region [LOG]
        // Log class to better manage the log file
        public static class Log {
            public static class _File {
                public static class MessageType {
                    public static string TOOL_STARTED         { get { return "TOOL_STARTED"; } }
                    public static string TOOL_STOPPED         { get { return "TOOL_STOPPED"; } }
                    public static string XML_SCANNING_STARTED { get { return "XML_SCANNING_STARTED"; } }
                    public static string XML_SCANNING_CORRUPT { get { return "XML_SCANNING_ABORTED_NODE_CORRUPTED"; } }
                    public static string XML_SCANNING_ENDED   { get { return "XML_SCANNING_ENDED"; } }
                    public static string MONITORING_STARTED   { get { return "MONITORING_STARTED"; } }
                    public static string MONITORING_STOPPED   { get { return "MONITORING_STOPPED"; } }
                    public static string CONVERSION_STARTED   { get { return "CONVERSION_STARTED"; } }
                    public static string CONVERSION_SUCCESS   { get { return "CONVERSION_SUCCESS"; } }
                    public static string CONVERSION_FAILED    { get { return "CONVERSION_FAILED"; } }
                    public static string CONVERSION_ABORTED   { get { return "CONVERSION_ABORTED"; } }
                }

                public static void Write(string MessageType, string Message = "") {
                    try {
                        File.AppendAllText(Global.LogFilePath,
                            String.Format("<{0} |-> [{1}]>  {2}\n", DateTime.Now, MessageType, Message));
                    } catch { }
                }
            }
        }
        #endregion

        #region [THREADS]
        // Thread where the scanning of the XML nodes occurs
        #region [XML_NODE_AUTO_SCAN]
        public void XMLNodesAutoScan(object XMLPath) {
            // Starts reading the XML file
            using (FileStream _fs = File.OpenRead((string)XMLPath)) { // We need the FileStream to can calculate the percentage for the progress bar
                // XML Reader Settings
                XmlReaderSettings _xmlReaderSettings            = new XmlReaderSettings();
                _xmlReaderSettings.IgnoreProcessingInstructions = true;
                _xmlReaderSettings.IgnoreComments               = true;
                _xmlReaderSettings.IgnoreWhitespace             = true;

                using (XmlReader _xmlReader = XmlReader.Create(_fs, _xmlReaderSettings)) {
                    long _lastPos = 0; // Used to calculate the percentage for the progress bar

                    // Writing to the log the (start) scanning event
                    Log._File.Write(Log._File.MessageType.XML_SCANNING_STARTED);
                    // Initialize and start the timing benchmark
                    Stopwatch _timingTest = new Stopwatch();
                    _timingTest.Start();

                    // We need to get all the node names in a List because using directly 'xmlNodesFilter_listview.Items.Contains(NODE_ITEM)' doesn't works
                    List<string> _nodesList = new List<string>();
                    try {
                        Invoke((MethodInvoker)delegate () {
                            foreach (ListViewItem _node in xmlNodesFilter_listview.Items)
                                _nodesList.Add(_node.Text);
                        });
                    } catch { }

                    try {
                        while (_xmlReader.Read()) {
                            if (Global.XMLScanningAbort == true) {
                                // Re-enable the "Select XML" button
                                try {
                                    Invoke((MethodInvoker)delegate () {
                                        xmlScanStructure_btn.Enabled = true;
                                        tool_progressbar.Value = 0;
                                        toolProgressPercent_lbl.Text = "0%";
                                    });
                                } catch { }

                                Global.XMLScanningAbort = false;
                                break;
                            }

                            // Process node
                            if (_xmlReader.NodeType == XmlNodeType.Element) {
                                if (_xmlReader.Name != "repfeed" && _xmlReader.Name != "reputations" && _xmlReader.Name != "reputation") {
                                    if (!_nodesList.Contains(_xmlReader.Name)) {
                                        try {
                                            Invoke((MethodInvoker)delegate () {
                                                // Preparing the node values
                                                string[] _nodeValue    = new string[2];
                                                         _nodeValue[0] = _xmlReader.Name;
                                                _nodesList.Add(_xmlReader.Name); // Adding the node also to our temp list

                                                // Initializing the node
                                                ListViewItem _node = new ListViewItem(_nodeValue) { Checked = true, Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular) };
                                                // Adding the node to the list
                                                xmlNodesFilter_listview.Items.Add(_node);
                                                xmlNodesFilter_listview.SelectedItems[0].Selected = false;
                                                // Saving the node to the 'Nodes_Filter' directory
                                                Configuration.XMLNodes.Add(_xmlReader.Name, "", true);
                                            });
                                        } catch { }
                                    }
                                }
                            }

                            // If we are reading a new chunck of data, we will update the progress bar
                            if (_lastPos != _fs.Position) {
                                _lastPos = _fs.Position;

                                // Updating the progress bar
                                try {
                                    BeginInvoke((MethodInvoker)delegate() {
                                        tool_progressbar.Value       = (int)(100.0 * _lastPos / _fs.Length);
                                        toolProgressPercent_lbl.Text = String.Format("{0}%", 100 * _lastPos / _fs.Length);
                                    });
                                } catch { }
                            }
                        }
                    } catch {
                        Invoke((MethodInvoker)delegate () {
                            Log._File.Write(Log._File.MessageType.XML_SCANNING_CORRUPT);

                            toolVisualFeedback_lbl.BackColor = Color.Red;
                            toolVisualFeedback_lbl.Text      = "Some nodes are corrupted...";

                            // Disables the controls
                            xmlScanStructure_btn.Enabled    = false;
                            toolAction_btn.Enabled          = false;
                            xmlNodesFilter_listview.Enabled = false;
                            xmlNodeName_txtbox.Enabled      = false;
                            xmlNodeAlias_txtbox.Enabled     = false;
                            xmlEditAlias_btn.Enabled        = false;
                        });
                        // Freeze the thread for 1,5 seconds
                        Thread.Sleep(1500);
                    }
                    // Resets the controls
                    try {
                        Invoke((MethodInvoker)delegate() {
                            xmlScanStructure_btn.Text        = "Select XML";
                            tool_progressbar.Value           = 0;
                            toolProgressPercent_lbl.Text     = "0%";

                            // Change the visual feedback
                            toolVisualFeedback_lbl.BackColor = Color.PowderBlue;
                            toolVisualFeedback_lbl.Text      = "Tool not running";

                            // Re-enables the controls
                            xmlScanStructure_btn.Enabled     = true;
                            if (xmlNodesFilter_listview.CheckedItems.Count > 0 && xmlInputPath_txtbox.TextLength > 0 && csvOutputPath_txtbox.TextLength > 0)
                                toolAction_btn.Enabled       = true;

                            xmlNodesFilter_listview.Enabled  = true;
                            xmlNodeName_txtbox.Enabled       = true;
                            xmlNodeAlias_txtbox.Enabled      = true;
                            xmlEditAlias_btn.Enabled         = true;
                        });
                    } catch { }

                    // Writing to the log the (end) scanning event
                    Log._File.Write(Log._File.MessageType.XML_SCANNING_ENDED);
                    // Stops and updates the timing benchmark
                    _timingTest.Stop();

                    try { BeginInvoke((MethodInvoker)(() => xmlNodesScanningTiming_lbl.Text = _timingTest.Elapsed.ToString())); } catch { }
                }
            }
        }
        #endregion
        // Thread where the conversion of the XML to CSV occurs
        #region [XML_CONVERSION_MONITORING]
        public void XMLMonitoring() {
            int      _timer             = 0; // In milliseconds
            string   _xmlDirPath        = "";
            string   _xmlSuccessDirPath = "";
            string   _xmlFailDirPath    = "";
            string   _csvDirPath        = "";
            string   _csvFileName       = "_";
            string[] _csvNodeName       = null;
            string[] _csvNodeValue      = null;
            string[] _csvNodeAlias      = null;

            Invoke((MethodInvoker)delegate () {
                _timer += (int)monitoringIntervalHrs_numeric.Value * 3600000;
                _timer += (int)monitoringIntervalMin_numeric.Value * 60000;
                _timer += (int)monitoringIntervalSec_numeric.Value * 1000;

                _xmlDirPath        = xmlInputPath_txtbox.Text;
                _xmlSuccessDirPath = String.Format("{0}\\{1}", _xmlDirPath, "Success");
                _xmlFailDirPath    = String.Format("{0}\\{1}", _xmlDirPath, "Fail");
                _csvDirPath        = csvOutputPath_txtbox.Text;

                // Initialize the arrays who will create the CSV structure and gets the active XML nodes from the listview
                // We use two arrays to achieve this
                // NODE_NAME, NODE_VALUE
                // example:
                // "category" (_csvNodeName or _csvNodeAlias)
                // "darknet"  (_csvNodeValue)
                _csvNodeName  = new string[xmlNodesFilter_listview.CheckedItems.Count];
                _csvNodeValue = new string[_csvNodeName.Length];
                _csvNodeAlias = new string[_csvNodeName.Length];
                for (int i = 0; i < _csvNodeName.Length; i++) {
                    // Gets the node names
                    _csvNodeName[i] = xmlNodesFilter_listview.CheckedItems[i].Text;

                    // We check if the node has an alias or not
                    if (xmlNodesFilter_listview.CheckedItems[i].SubItems[1].Text != "")
                        _csvNodeAlias[i] = xmlNodesFilter_listview.CheckedItems[i].SubItems[1].Text;
                }

                #region  [CSV_FILE_NAME]
                // CSV File Name
                if (csvFileName_txtbox.ForeColor   == Color.Black)
                    _csvFileName += csvFileName_txtbox.Text + "_";
                if (csvFilePrefix_txtbox.ForeColor == Color.Black)
                    _csvFileName = _csvFileName.Insert(0, csvFilePrefix_txtbox.Text);
                if (csvFileSuffix_txtbox.ForeColor == Color.Black)
                    _csvFileName = _csvFileName.Insert(_csvFileName.Length, csvFileSuffix_txtbox.Text + "_");
                if (_csvFileName == "_")
                    _csvFileName += "repfeed_";
                #endregion
            });

            // XML Reader Settings
            XmlReaderSettings _xmlReaderSettings            = new XmlReaderSettings();
            _xmlReaderSettings.IgnoreProcessingInstructions = true;
            _xmlReaderSettings.IgnoreComments               = true;

            while (true) {
                // If the "STOP" button was pressed or if the form was closed, we stop the monitoring process
                if (Global.MonitoringAbort || !Visible) {
                    Global.MonitoringAbort = false;
                    break;
                }

                // Retrieves all the XML files in the input folder
                foreach (string _xmlFile in Directory.GetFiles(_xmlDirPath)) {
                    if (Global.MonitoringAbort || !Visible) {
                        Global.MonitoringAbort = false;

                        if (csvBadOutputDelete_chbox.Checked) {
                            if (File.Exists(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName)))
                                File.Delete(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName));
                        }

                        break;
                    }

                    bool _conversionSuccess = false;

                    // If we found a XML file and is not locked
                    if (!Global.FileIsLocked(_xmlFile)) {
                        Log._File.Write(Log._File.MessageType.CONVERSION_STARTED, String.Format("XML File: {0}", _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1)));

                        // Updating the CSV file name
                        //_csvFileName  = _csvFileNameCopy;
                        _csvFileName += String.Format("{0:yyyy_MM_dd_HH_mm_ss}", DateTime.Now);

                        #region [CSV_STREAM_WRITER]
                        // Initializes a StreamWriter
                        StreamWriter _csvFileStream = null;
                        try {
                            _csvFileStream = new StreamWriter(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName), true);
                        } catch {
                            Log._File.Write(Log._File.MessageType.CONVERSION_FAILED, String.Format("| [ERROR] : Unable to initialize the 'CSV StreamWriter' <|> XML File Path -> [{0}]", _xmlFile));

                            try {
                                Invoke((MethodInvoker)delegate () {
                                    // Change the visual feedback
                                    toolVisualFeedback_lbl.BackColor = Color.Red;
                                    toolVisualFeedback_lbl.Text      = "ERROR: Conversion aborted! (See log file)";
                                });
                            } catch { }
                            // Waits 5 seconds before aborting
                            Thread.Sleep(5000);

                            break;
                        }
                        #endregion

                        #region [GUI_CONTROLS]
                        try {
                            Invoke((MethodInvoker)delegate () {
                                toolVisualFeedback_lbl.Font      = new Font(toolVisualFeedback_lbl.Font, FontStyle.Italic | FontStyle.Bold);
                                toolVisualFeedback_lbl.BackColor = Color.GreenYellow;
                                toolVisualFeedback_lbl.Text      = "Converting XML...";
                                xmlConversionAbort_btn.Enabled   = true;
                            });
                        } catch { }
                        #endregion
                        // Starts reading the XML file
                        using (FileStream _fs = File.OpenRead(_xmlFile)) { // We need the FileStream to can calculate the percentage for the progress bar
                            using (XmlReader _xmlReader = XmlReader.Create(_fs, _xmlReaderSettings)) {
                                long _lastPos = 0; // Used to calculate the percentage for the progress bar

                                // Initialize and start the timing benchmark
                                Stopwatch _timingTest = new Stopwatch();
                                _timingTest.Start();

                                #region [COLUMNS]
                                // Writing the (the nodes names or the aliases) columns of the CSV file
                                StringBuilder _csvColumns = new StringBuilder();
                                for (int i = 0; i < _csvNodeName.Length; i++) {
                                    if (!String.IsNullOrEmpty(_csvNodeAlias[i]))
                                        _csvColumns.Append(String.Format(@"""{0}"",", _csvNodeAlias[i]));
                                    else
                                        _csvColumns.Append(String.Format(@"""{0}"",", _csvNodeName[i]));
                                }
                                // Flush the columns to the file
                                _csvFileStream.WriteLine(_csvColumns.ToString().TrimEnd(','));
                                _csvFileStream.Flush();
                                #endregion

                                try {
                                    string _currentNodeName = "";

                                    while (_xmlReader.Read()) {
                                        #region [ABORT_CONVERSION]
                                        if (Global.XMLConversionAbort || !Visible) {
                                            _csvFileStream.Close();
                                            Log._File.Write(Log._File.MessageType.CONVERSION_ABORTED, String.Format("XML File: {0}", _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1)));

                                            try {
                                                Invoke((MethodInvoker)delegate () {
                                                    tool_progressbar.Value           = 0;
                                                    toolProgressPercent_lbl.Text     = "0%";

                                                    // Change the visual feedback
                                                    toolVisualFeedback_lbl.Font      = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);
                                                    toolVisualFeedback_lbl.BackColor = Color.Gold;
                                                    toolVisualFeedback_lbl.Text      = "Aborting the conversion, please wait...";

                                                    // If 'Delete Bad CSV' checkbox is checked
                                                    if (csvBadOutputDelete_chbox.Checked) {
                                                        if (File.Exists(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName)))
                                                            File.Delete(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName));
                                                    }
                                                });
                                            } catch { }

                                            break;
                                        }
                                        #endregion

                                        #region [CONVERSION_PROCESS]
                                        // Writing the data
                                        switch (_xmlReader.NodeType) {
                                            case XmlNodeType.Element:
                                            _currentNodeName = _xmlReader.Name;
                                            break;

                                            case XmlNodeType.Text:
                                            // If the current node exists also in the _csvNodeName array we get the position index
                                            int i = Array.IndexOf(_csvNodeName, _currentNodeName);
                                            // If the returned value is -1 means that the _csvNodeName array doesn't not contains the node
                                            if (i != -1)
                                                _csvNodeValue[i] = _xmlReader.Value;
                                            break;

                                            case XmlNodeType.EndElement:
                                            if (_xmlReader.Name == "reputation") {
                                                // Now that we have the right order of the values, we write them to the CSV file
                                                _csvFileStream.WriteLine(String.Format("{1}{0}{1}", string.Join(@""",""", _csvNodeValue), @""""));
                                                // Cleans the _csvNodeValue array for the next row
                                                Array.Clear(_csvNodeValue, 0, _csvNodeValue.Length);
                                            }
                                            break;
                                        }
                                        #endregion

                                        #region [PROGRESS_BAR]
                                        // If we are reading a new chunck of data, we will update the progress bar
                                        if (_lastPos != _fs.Position) {
                                            _lastPos = _fs.Position;

                                            // Updating the progress bar
                                            try {
                                                BeginInvoke((MethodInvoker)delegate () {
                                                    tool_progressbar.Value       = (int)(100.0 * _lastPos / _fs.Length);
                                                    toolProgressPercent_lbl.Text = String.Format("{0}%", 100 * _lastPos / _fs.Length);
                                                });
                                            } catch { }
                                        }
                                        #endregion
                                    }
                                } catch {
                                    // This will happen when the XML structure is corrupted
                                    try {
                                        Invoke((MethodInvoker)delegate() {
                                            // If 'Delete Bad CSV' checkbox is checked
                                            if (csvBadOutputDelete_chbox.Checked) {
                                                _csvFileStream.Close();

                                                if (File.Exists(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName)))
                                                    File.Delete(String.Format("{0}\\{1}.csv", _csvDirPath, _csvFileName));
                                            }

                                            tool_progressbar.Value           = 0;
                                            toolProgressPercent_lbl.Text     = "0%";

                                            toolVisualFeedback_lbl.Font      = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);
                                            toolVisualFeedback_lbl.BackColor = Color.Red;
                                            toolVisualFeedback_lbl.Text      = "XML Conversion failed!";

                                            Log._File.Write(Log._File.MessageType.CONVERSION_FAILED, String.Format("XML File: {0}", _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1)));
                                        });
                                        // We stop the thread for 5 seconds to can show the 'XML Conversion failed' error
                                        long _tNow = DateTime.Now.Ticks;
                                        while (!Global.XMLConversionAbort && Visible) {
                                            if ((DateTime.Now.Ticks - _tNow) > 5 * TimeSpan.TicksPerSecond)
                                                break;

                                            // We need this 'Sleep' to lower the CPU utilization in the loop
                                            Thread.Sleep(100);
                                        }
                                    } catch { }
                                }

                                // Stops the timing benchmark
                                _timingTest.Stop();
                                if (!Global.XMLConversionAbort) {
                                    #region [GUI_CONTROLS]
                                    // Resets the controls
                                    try {
                                        Invoke((MethodInvoker)delegate() {
                                            if (tool_progressbar.Value >= 100)
                                                _conversionSuccess = true;

                                            tool_progressbar.Value       = 0;
                                            toolProgressPercent_lbl.Text = "0%";

                                            // Change the visual feedback
                                            if (_conversionSuccess) {
                                                xmlToCsvConversionTiming_lbl.Text = _timingTest.Elapsed.ToString();

                                                Log._File.Write(Log._File.MessageType.CONVERSION_SUCCESS, String.Format("XML File: {0}", _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1)));
                                            }
                                        });
                                    } catch { }
                                    #endregion
                                }
                            }
                        }
                        
                        _csvFileStream.Close();
                    } else {
                        if (!Global.XMLConversionAbort) {
                            try {
                                Invoke((MethodInvoker)delegate () {
                                    toolVisualFeedback_lbl.Font      = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);
                                    toolVisualFeedback_lbl.BackColor = Color.Gold;
                                    toolVisualFeedback_lbl.Text      = "XML Locked, waiting...";
                                });
                            } catch { }
                        }
                    }
                    

                    // If the conversion was a success we move the XML file to the 'Success' folder, otherwise to the 'Fail' folder
                    if (_conversionSuccess) {
                        if (!Directory.Exists(_xmlSuccessDirPath))
                            Directory.CreateDirectory(_xmlSuccessDirPath);

                        try { File.Move(_xmlFile, String.Format("{0}\\{1}", _xmlSuccessDirPath, _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1))); } catch { }
                    } else {
                        if (!Global.FileIsLocked(_xmlFile) && !Global.XMLConversionAbort) {
                            if (!Directory.Exists(_xmlFailDirPath))
                                Directory.CreateDirectory(_xmlFailDirPath);

                            try { File.Move(_xmlFile, String.Format("{0}\\{1}", _xmlFailDirPath, _xmlFile.Substring(_xmlFile.LastIndexOf('\\') + 1))); } catch { }
                        }
                    }
                }

                // Scanning/Conversion of the XML (folder) finished or aborted
                // We reset the controls
                try {
                    Invoke((MethodInvoker)delegate () {
                        Global.XMLConversionAbort      = false;
                        xmlConversionAbort_btn.Enabled = false;
                        toolVisualFeedback_lbl.Font    = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);

                        if (toolVisualFeedback_lbl.Text != "XML Locked, waiting...") {
                            if (toolAction_btn.Text == "STOP") {
                                toolVisualFeedback_lbl.BackColor      = Color.GreenYellow;
                                toolVisualFeedback_lbl.Text           = "Tool successfully running...";
                            } else {
                                toolVisualFeedback_lbl.BackColor      = Color.PowderBlue;
                                toolVisualFeedback_lbl.Text           = "Tool not running";

                                #region [CONTROLS]
                                // Enables the XML node filter controls
                                xmlNodeName_txtbox.Enabled            = true;
                                xmlScanStructure_btn.Enabled          = true;
                                xmlNodeAlias_txtbox.Enabled           = true;
                                xmlEditAlias_btn.Enabled              = true;
                                xmlNodesFilter_listview.Enabled       = true;
                                // Enables monitoring controls
                                xmlInputPath_btn.Enabled              = true;
                                csvOutputPath_btn.Enabled             = true;
                                csvFileName_txtbox.Enabled            = true;
                                csvFilePrefix_txtbox.Enabled          = true;
                                csvFileSuffix_txtbox.Enabled          = true;
                                monitoringIntervalHrs_numeric.Enabled = true;
                                monitoringIntervalMin_numeric.Enabled = true;
                                monitoringIntervalSec_numeric.Enabled = true;
                                csvBadOutputDelete_chbox.Enabled      = true;
                                toolAction_btn.Enabled                = true;
                                #endregion
                            }
                        }
                    });
                } catch { }

                #region [MONITORING_TIMER]
                long _dateTimeStart = DateTime.Now.Ticks;
                while (!Global.MonitoringAbort && Visible) {
                    if ((DateTime.Now.Ticks - _dateTimeStart) > _timer * TimeSpan.TicksPerMillisecond)
                        break;

                    // We need this 'Sleep' to lower the CPU utilization in the loop
                    Thread.Sleep(100);
                }
                #endregion
            }
        }
        #endregion
        #endregion

        #region [CONFIGURATION]
        public static class Configuration {
            #region [MAIN]
            public static class Main {
                // Initialize the XML Document class
                private static XmlDocument xmlDoc = new XmlDocument();

                public static void Create(Form1 _frm) {
                    // Defines the root node of the XML file
                    XmlNode _root = xmlDoc.CreateElement("Configuration_File");
                    xmlDoc.AppendChild(_root);

                    // Defines the 'XML/CSV Directory' node
                    XmlNode _xml_csvDirPath = xmlDoc.CreateElement("XML_CSV_Directory");
                    _root.AppendChild(_xml_csvDirPath);
                    // Defines the 'CSV Output File' node
                    XmlNode _csvOutputFile  = xmlDoc.CreateElement("CSV_Output_File");
                    _root.AppendChild(_csvOutputFile);
                    // Defines the 'Monitoring' node
                    XmlNode _monitoring     = xmlDoc.CreateElement("Monitoring");
                    _root.AppendChild(_monitoring);
                    // Defines the 'Monitoring/Interval' node
                    XmlNode _mInterval      = xmlDoc.CreateElement("Interval");
                    _monitoring.AppendChild(_mInterval);

                    // Child-nodes
                    #region [XML/CSV_DIRECTORY]
                    // XML Directory Path
                    XmlNode _xmlDirPath                   = xmlDoc.CreateElement("XML_Path");
                            _xmlDirPath.InnerText         = _frm.xmlInputPath_txtbox.Text;
                    _xml_csvDirPath.AppendChild(_xmlDirPath);
                    // CSV Directory Path
                    XmlNode _csvDirPath                   = xmlDoc.CreateElement("CSV_Path");
                            _csvDirPath.InnerText         = _frm.csvOutputPath_txtbox.Text;
                    _xml_csvDirPath.AppendChild(_csvDirPath);
                    #endregion

                    #region [CSV_OUTPUT]
                    // CSV File Name
                    XmlNode _csvFileName                  = xmlDoc.CreateElement("File_Name");
                    if (_frm.csvFileName_txtbox.ForeColor != Color.Gray)
                        _csvFileName.InnerText            = _frm.csvFileName_txtbox.Text;
                    _csvOutputFile.AppendChild(_csvFileName);
                    // CSV File Name Prefix
                    XmlNode _csvFileNamePrefix            = xmlDoc.CreateElement("File_Name_Prefix");
                    if (_frm.csvFilePrefix_txtbox.ForeColor != Color.Gray)
                        _csvFileNamePrefix.InnerText      = _frm.csvFilePrefix_txtbox.Text;
                    _csvOutputFile.AppendChild(_csvFileNamePrefix);
                    // CSV File Name Suffix
                    XmlNode _csvFileNameSuffix            = xmlDoc.CreateElement("File_Name_Suffix");
                    if (_frm.csvFileSuffix_txtbox.ForeColor != Color.Gray)
                        _csvFileNameSuffix.InnerText      = _frm.csvFileSuffix_txtbox.Text;
                    _csvOutputFile.AppendChild(_csvFileNameSuffix);
                    // Delete Bad CSV Checkbox
                    XmlNode _mDeleteBadCsv                = xmlDoc.CreateElement("Delete_Bad_CSV");
                    _mDeleteBadCsv.InnerText              = _frm.csvBadOutputDelete_chbox.Checked.ToString();
                    _csvOutputFile.AppendChild(_mDeleteBadCsv);
                    #endregion

                    #region [MONITORING]
                    // Monitoring Interval
                    // Hours
                    XmlNode _mIntervalHrs    = xmlDoc.CreateElement("Hours");
                    _mIntervalHrs.InnerText  = _frm.monitoringIntervalHrs_numeric.Value.ToString();
                    _mInterval.AppendChild(_mIntervalHrs);
                    // Minutes
                    XmlNode _mIntervalMin    = xmlDoc.CreateElement("Minutes");
                    _mIntervalMin.InnerText  = _frm.monitoringIntervalMin_numeric.Value.ToString();
                    _mInterval.AppendChild(_mIntervalMin);
                    // Seconds
                    XmlNode _mIntervalSec    = xmlDoc.CreateElement("Seconds");
                    _mIntervalSec.InnerText  = _frm.monitoringIntervalSec_numeric.Value.ToString();
                    _mInterval.AppendChild(_mIntervalSec);
                    #endregion

                    // Creates/Edit the XML file
                    xmlDoc.Save(Global.ConfigFilePath);
                }

                public static void Load(Form1 _frm) {
                    // Loads the XML
                    xmlDoc.Load(Global.ConfigFilePath);

                    #region [XML/CSV_DIRECTORY]
                    // Get the XML Directory Path
                    XmlNode _xmlDirPath                      = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/XML_CSV_Directory/XML_Path");
                    _frm.xmlInputPath_txtbox.Text            = _xmlDirPath.InnerText;
                    // Get the CSV Directory Path
                    XmlNode _csvDirPath                      = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/XML_CSV_Directory/CSV_Path");
                    _frm.csvOutputPath_txtbox.Text           = _csvDirPath.InnerText;
                    #endregion

                    #region [CSV_OUTPUT]
                    // Get the File Name
                    XmlNode _csvFileName                     = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/CSV_Output_File/File_Name");
                    if (_csvFileName.InnerText.Length > 0) {
                        _frm.csvFileName_txtbox.ForeColor    = Color.Black;
                        _frm.csvFileName_txtbox.Text         = _csvFileName.InnerText;
                    }
                    // Get the File Name Prefix
                    XmlNode _csvFileNamePrefix               = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/CSV_Output_File/File_Name_Prefix");
                    if (_csvFileNamePrefix.InnerText.Length > 0) {
                        _frm.csvFilePrefix_txtbox.ForeColor  = Color.Black;
                        _frm.csvFilePrefix_txtbox.Text       = _csvFileNamePrefix.InnerText;
                    }
                    // Get the File Name Suffix
                    XmlNode _csvFileNameSuffix               = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/CSV_Output_File/File_Name_Suffix");
                    if (_csvFileNameSuffix.InnerText.Length > 0) {
                        _frm.csvFileSuffix_txtbox.ForeColor  = Color.Black;
                        _frm.csvFileSuffix_txtbox.Text       = _csvFileNameSuffix.InnerText;
                    }
                    // Get the status of the 'Delete Bad CSV' checkbox
                    XmlNode _mDeleteBadCsv                   = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/CSV_Output_File/Delete_Bad_CSV");
                    _frm.csvBadOutputDelete_chbox.Checked    = Convert.ToBoolean(_mDeleteBadCsv.InnerText);
                    #endregion

                    #region [MONITORING]
                    // Get the Hours Interval
                    XmlNode _mIntervalHrs                    = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/Monitoring/Interval/Hours");
                    _frm.monitoringIntervalHrs_numeric.Value = Convert.ToInt32(_mIntervalHrs.InnerText);
                    // Get the Minutes Interval
                    XmlNode _mIntervalMin                    = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/Monitoring/Interval/Minutes");
                    _frm.monitoringIntervalMin_numeric.Value = Convert.ToInt32(_mIntervalMin.InnerText);
                    // Get the Seconds Interval
                    XmlNode _mIntervalSec                    = xmlDoc.DocumentElement.SelectSingleNode("/Configuration_File/Monitoring/Interval/Seconds");
                    _frm.monitoringIntervalSec_numeric.Value = Convert.ToInt32(_mIntervalSec.InnerText);
                    #endregion
                }
            }
            #endregion

            #region [XML_NODE_FILTER]
            public static class XMLNodes {
                public static void Add(string NodeName, string NodeAlias, bool Enabled) {
                    if (!Directory.Exists(Global.XMLNodesDirPath))
                        Directory.CreateDirectory(Global.XMLNodesDirPath);

                    // Node settings
                    string[] _value = new string[3];
                    
                    // Node (from XML) Name
                    _value[0] = NodeName;
                    // Node Alias (in the CSV)
                    _value[1] = NodeAlias;
                    // Is enabled? (in the CSV)
                    _value[2] = Enabled.ToString();

                    // Creates the node filter file
                    File.WriteAllLines(String.Format("{0}\\{1}", Global.XMLNodesDirPath, NodeName), _value);
                }

                public static void Edit(string OldNodeName, string NewNodeName, string NodeAlias, bool Enabled) {
                    string _filePath = String.Format("{0}\\{1}", Global.XMLNodesDirPath, OldNodeName);

                    if (File.Exists(_filePath)) {
                        File.Delete(_filePath);

                        Add(NewNodeName, NodeAlias, Enabled);
                    }
                }

                public static void Delete(string NodeName) {
                    string _filePath = String.Format("{0}\\{1}", Global.XMLNodesDirPath, NodeName);

                    if (File.Exists(_filePath))
                        File.Delete(_filePath);
                }

                public static void LoadAll(Form1 _frm) {
                    _frm.xmlNodesFilter_listview.Columns[0].Width = 138;
                    _frm.xmlNodesFilter_listview.Columns[1].Width = 145;

                    if (Directory.Exists(Global.XMLNodesDirPath)) {
                        _frm.xmlNodesFilter_listview.Items.Clear();

                        foreach (string _f in Directory.GetFiles(Global.XMLNodesDirPath + "\\")) {
                            // Read the node value from the filter file
                            string[] _value   = File.ReadAllLines(_f);
                            // We need this array to create the item structure for the listview
                            string[] _lviRow  = new string[2];

                            _lviRow[0]        = _value[0]; // Node Name
                            _lviRow[1]        = _value[1]; // CSV Node Alias

                            // Initialize the item structure
                            ListViewItem _lvi = new ListViewItem(_lviRow);
                            // Add the item to the listview
                            _frm.xmlNodesFilter_listview.Items.Add(_lvi);
                            // If the node is enabled, check the checkbox of the item
                            foreach (ListViewItem _i in _frm.xmlNodesFilter_listview.Items) {
                                if (_i.Text == _value[0]) {
                                    _i.Font = (new Font(_i.Font.FontFamily, 8.25f, FontStyle.Regular));

                                    if (Convert.ToBoolean(_value[2]) == true)
                                        _i.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e) {
            // Writes to the log file the stamp when the program starts
            Log._File.Write(Log._File.MessageType.TOOL_STARTED);

            #region [CONFIGURATION_FILE]
            // Main
            if (!File.Exists(Global.ConfigFilePath)) {
                Configuration.Main.Create(this);
            } else {
                Configuration.Main.Load(this);
            }
            // XML Nodes
            Configuration.XMLNodes.LoadAll(this);
            #endregion

            // If no node exists in the list, we disable the 'START' button
            if (xmlNodesFilter_listview.Items.Count == 0)
                toolAction_btn.Enabled = false;

            Global.ToolStartedNow = false;
        }

        #region [CONTROLS]
        #region [XML_NODES]
        #region [GUI_ONLY]
        // Enables/Disables the 'Add Node' button (Manually)
        private void xmlNodeName_txtbox_TextChanged(object sender, EventArgs e) {
            if (xmlNodeName_txtbox.TextLength > 0) {
                xmlAddNode_btn.Enabled = true;

                try {
                    if (xmlNodesFilter_listview.SelectedItems[0].Text != xmlNodeName_txtbox.Text) {
                        xmlEditName_btn.Enabled = true;
                    } else {
                        xmlEditName_btn.Enabled = false;
                    }
                } catch { }
            } else {
                xmlAddNode_btn.Enabled  = false;
                xmlEditName_btn.Enabled = false;
            }
        }
        #endregion

        // Manually Add
        private void xmlAddNode_btn_Click(object sender, EventArgs e) {
            // If the written node doesn't already exists in the list
            if (xmlNodeName_txtbox.Text.IndexOfAny(Path.GetInvalidFileNameChars()) == -1 && !xmlNodeName_txtbox.Text.StartsWith(" ")) {
                if (!File.Exists(String.Format("{0}\\{1}", Global.XMLNodesDirPath, xmlNodeName_txtbox.Text))) {
                    // Add to the checkbox list the node
                    string[] _nodeValue   = new string[2];
                            _nodeValue[0] = xmlNodeName_txtbox.Text;
                    // If the alias textbox isn't empty
                    if (xmlNodeAlias_txtbox.ForeColor == Color.Black)
                        _nodeValue[1] = xmlNodeAlias_txtbox.Text;

                    ListViewItem _node = new ListViewItem(_nodeValue) { Checked = true, Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Regular) };
                    xmlNodesFilter_listview.Items.Add(_node);
                    Configuration.XMLNodes.Add(xmlNodeName_txtbox.Text, _nodeValue[1], true);
                } else {
                    MessageBox.Show("A node with the same name already exists", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } else {
                MessageBox.Show("The node name contains illegal characters or starts with a space!\n(<, >, :, \", /, \\, |, ?, *)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Automatically Add (Scans the XML nodes)
        // This button will change in an abort button after the scan phase will start
        private void xmlScanStructure_btn_Click(object sender, EventArgs e) {
            if (xmlScanStructure_btn.Text == "Select XML") {
                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    // Initialize the thread where the XML file will be scanned
                    Thread _tXMLScanning = new Thread(new ParameterizedThreadStart(XMLNodesAutoScan));

                    _tXMLScanning.Start(openFileDialog1.FileName);

                    xmlScanStructure_btn.Text        = "Abort Operation";

                    // Change the visual feedback
                    toolVisualFeedback_lbl.BackColor = Color.Gold;
                    toolVisualFeedback_lbl.Text      = "Scanning the XML nodes...";

                    // Disables the other controls to avoid interferences with the scanning
                    toolAction_btn.Enabled           = false;
                    if (xmlNodesFilter_listview.SelectedItems.Count > 0) { xmlNodesFilter_listview.SelectedItems[0].Selected = false; }
                    xmlNodesFilter_listview.Enabled  = false;
                    xmlNodeName_txtbox.Enabled       = false;
                    xmlNodeAlias_txtbox.Enabled      = false;
                    xmlEditAlias_btn.Enabled         = false;
                    xmlDeleteNode_btn.Enabled        = false;
                }
            } else {
                if (MessageBox.Show("Are you sure?", "This will abort the operation!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    // We abort the scanning process
                    Global.XMLScanningAbort          = true;
                    xmlScanStructure_btn.Enabled     = false;

                    tool_progressbar.Value           = 0;
                    xmlScanStructure_btn.Text        = "Select XML";

                    // Change the visual feedback
                    toolVisualFeedback_lbl.BackColor = Color.PowderBlue;
                    toolVisualFeedback_lbl.Text      = "Tool not running";

                    // Re-enables the controls
                    if (xmlNodesFilter_listview.CheckedItems.Count > 0 && xmlInputPath_txtbox.TextLength > 0 && csvOutputPath_txtbox.TextLength > 0)
                        toolAction_btn.Enabled       = true;

                    xmlNodesFilter_listview.Enabled  = true;
                    xmlNodeName_txtbox.Enabled       = true;
                    xmlNodeAlias_txtbox.Enabled      = true;
                    xmlEditAlias_btn.Enabled         = true;
                }
            }
        }

        // Edit Node Name
        private void xmlEditName_btn_Click(object sender, EventArgs e) {
            if (xmlNodeName_txtbox.Text.IndexOfAny(Path.GetInvalidFileNameChars()) == -1 && !xmlNodeName_txtbox.Text.StartsWith(" ")) {
                if (MessageBox.Show("Are you sure", "This will change the selected 'Node Name'", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
                    // Initialize the Node Values
                    string[] _nodeValue = Global.GetNodeValues(this);

                    Configuration.XMLNodes.Edit(xmlNodesFilter_listview.SelectedItems[0].Text, xmlNodeName_txtbox.Text, _nodeValue[1], Convert.ToBoolean(_nodeValue[2]));
                    Configuration.XMLNodes.LoadAll(this);

                    xmlEditName_btn.Enabled = false;
                }
            } else {
                MessageBox.Show("The node name contains illegal characters or starts with a space!\n(<, >, :, \", /, \\, |, ?, *)", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Edit Node Alias (for the CSV file)
        private void xmlEditAlias_btn_Click(object sender, EventArgs e) {
            if (xmlNodesFilter_listview.SelectedItems.Count == 1 && xmlNodeAlias_txtbox.ForeColor == Color.Black) {
                if (MessageBox.Show("Are you sure", "", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    // Initialize the Node Values
                    string[] _nodeValue = Global.GetNodeValues(this);

                    // If the 'Node Alias' textbox is empty, we need to save an empty line to the filter file
                    if (Global.XMLNodeAliasEmpty) {
                        _nodeValue[1]            = "";
                        Global.XMLNodeAliasEmpty = false;
                    } else {
                        _nodeValue[1]            = xmlNodeAlias_txtbox.Text;
                    }

                    Configuration.XMLNodes.Edit(xmlNodesFilter_listview.SelectedItems[0].Text, _nodeValue[0], _nodeValue[1], Convert.ToBoolean(_nodeValue[2]));
                    int _selectedNode = xmlNodesFilter_listview.SelectedIndices[0];
                    Configuration.XMLNodes.LoadAll(this);
                    xmlNodesFilter_listview.Items[_selectedNode].Selected = true;
                }
            }
        }
        // Delete a node
        private void xmlDeleteNode_btn_Click(object sender, EventArgs e) {
            if (MessageBox.Show("Are you sure?", String.Format("This will delete the '{0}' node", xmlNodesFilter_listview.SelectedItems[0].Text), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Configuration.XMLNodes.Delete(xmlNodesFilter_listview.SelectedItems[0].Text);
                xmlNodesFilter_listview.SelectedItems[0].Remove();

                // Resets the textboxes
                xmlNodeName_txtbox.Text       = "";
                xmlNodeAlias_txtbox.ForeColor = Color.Gray;
                xmlNodeAlias_txtbox.Text      = "Same as the 'Node Name'";

                if (xmlNodesFilter_listview.Items.Count == 0)
                    toolAction_btn.Enabled = false;
            }
        }
        // Update the node status (if will be displayed or not in the output CSV file)
        private void xmlNodesFilter_listview_ItemChecked(object sender, ItemCheckedEventArgs e) {
            if (Global.ToolStartedNow == false) {
                // We first need to select the checked node
                e.Item.Selected = true;

                // Initialize the Node Values
                string[] _nodeValue = Global.GetNodeValues(this);

                Configuration.XMLNodes.Edit(xmlNodesFilter_listview.SelectedItems[0].Text, _nodeValue[0], _nodeValue[1], Convert.ToBoolean(_nodeValue[2]));
            }

            if (xmlNodesFilter_listview.CheckedItems.Count == 0) {
                toolAction_btn.Enabled = false;
            } else {
                if (xmlInputPath_txtbox.TextLength > 0 && csvOutputPath_txtbox.TextLength > 0 && xmlScanStructure_btn.Text == "Select XML")
                    toolAction_btn.Enabled = true;
            }
        }

        // Update the textboxes
        private void xmlNodesFilter_listview_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            if (xmlNodesFilter_listview.SelectedItems.Count == 0)
                xmlDeleteNode_btn.Enabled = false;

            try {
                // Initialize the Node Values
                string[] _nodeValue = Global.GetNodeValues(this);

                // Update the 'Node Name' and the 'Node Alias' textboxes
                xmlNodeName_txtbox.Text           = _nodeValue[0];
                // If the 'Node Alias' is empty, we need to put the placeholder text in the textbox
                if (_nodeValue[1].Length == 0) {
                    xmlNodeAlias_txtbox.ForeColor = Color.Gray;
                    xmlNodeAlias_txtbox.Text      = xmlNodeName_txtbox.Text;
                } else {
                    xmlNodeAlias_txtbox.ForeColor = Color.Black;
                    xmlNodeAlias_txtbox.Text      = _nodeValue[1];
                }
            } catch { }

            // If no item is selected from the checkboxlist, we disable the 'Edit Name' button
            if (xmlNodesFilter_listview.SelectedItems.Count == 0) {
                xmlEditName_btn.Enabled     = false;
                xmlDeleteNode_btn.Enabled   = false;

                // Resets the textboxes
                xmlNodeName_txtbox.Text       = "";
                xmlNodeAlias_txtbox.ForeColor = Color.Gray;
                xmlNodeAlias_txtbox.Text      = "Same as the 'Node Name'";
            } else {
                xmlDeleteNode_btn.Enabled   = true;
            }
        }
        #endregion

        #region [XML_CONVERSION]
        // 'Tool Start' button
        private void toolAction_btn_Click(object sender, EventArgs e) {
            if (toolAction_btn.Text == "START") {
                toolAction_btn.Text = "STOP";

                Log._File.Write(Log._File.MessageType.MONITORING_STARTED);

                #region [SAVES_MONITORING_CONTROLS_VALUES]
                if (Global.GUI.XMLPathChanged           ||
                    Global.GUI.CSVPathChanged           ||
                    Global.GUI.CSVFileNameChanged       ||
                    Global.GUI.CSVFileNamePrefixChanged ||
                    Global.GUI.CSVFileNameSuffixChanged ||
                    Global.GUI.MonitoringHrsChanged     ||
                    Global.GUI.MonitoringMinChanged     ||
                    Global.GUI.MonitoringSecChanged     ||
                    Global.GUI.MonitoringCsvBadChanged
                ) {
                    XmlDocument _xmlDoc = new XmlDocument();
                    _xmlDoc.Load(Global.ConfigFilePath);

                    XmlNode _xmlPath                     = _xmlDoc.SelectSingleNode("Configuration_File/XML_CSV_Directory/XML_Path");
                            _xmlPath.InnerText           = xmlInputPath_txtbox.Text;
                    XmlNode _csvPath                     = _xmlDoc.SelectSingleNode("Configuration_File/XML_CSV_Directory/CSV_Path");
                            _csvPath.InnerText           = csvOutputPath_txtbox.Text;

                    XmlNode _csvFileName                 = _xmlDoc.SelectSingleNode("Configuration_File/CSV_Output_File/File_Name");
                    if (csvFileName_txtbox.ForeColor != Color.Gray) {
                        _csvFileName.InnerText           = csvFileName_txtbox.Text;
                    } else {
                        _csvFileName.InnerText           = "";
                    }
                    XmlNode _csvFilePrefix               = _xmlDoc.SelectSingleNode("Configuration_File/CSV_Output_File/File_Name_Prefix");
                    if (csvFilePrefix_txtbox.ForeColor != Color.Gray) {
                        _csvFilePrefix.InnerText = csvFilePrefix_txtbox.Text;
                    } else {
                        _csvFilePrefix.InnerText         = "";
                    }
                    XmlNode _csvFileSuffix               = _xmlDoc.SelectSingleNode("Configuration_File/CSV_Output_File/File_Name_Suffix");
                    if (csvFileSuffix_txtbox.ForeColor != Color.Gray) {
                        _csvFileSuffix.InnerText = csvFileSuffix_txtbox.Text;
                    } else {
                        _csvFileSuffix.InnerText         = "";
                    }

                    XmlNode _mIntervalHrs                = _xmlDoc.SelectSingleNode("Configuration_File/Monitoring/Interval/Hours");
                            _mIntervalHrs.InnerText      = monitoringIntervalHrs_numeric.Value.ToString();
                    XmlNode _mIntervalMin                = _xmlDoc.SelectSingleNode("Configuration_File/Monitoring/Interval/Minutes");
                            _mIntervalMin.InnerText      = monitoringIntervalMin_numeric.Value.ToString();
                    XmlNode _mIntervalSec                = _xmlDoc.SelectSingleNode("Configuration_File/Monitoring/Interval/Seconds");
                            _mIntervalSec.InnerText      = monitoringIntervalSec_numeric.Value.ToString();
                    XmlNode _mDeleteBadCsv               = _xmlDoc.SelectSingleNode("Configuration_File/CSV_Output_File/Delete_Bad_CSV");
                            _mDeleteBadCsv.InnerText     = csvBadOutputDelete_chbox.Checked.ToString();

                    // Sets back to false the triggers
                    Global.GUI.XMLPathChanged            = false;
                    Global.GUI.CSVPathChanged            = false;
                    Global.GUI.CSVFileNameChanged        = false;
                    Global.GUI.CSVFileNamePrefixChanged  = false;
                    Global.GUI.CSVFileNameSuffixChanged  = false;
                    Global.GUI.MonitoringHrsChanged      = false;
                    Global.GUI.MonitoringMinChanged      = false;
                    Global.GUI.MonitoringSecChanged      = false;
                    Global.GUI.MonitoringCsvBadChanged   = false;

                    // Saves the changes
                    _xmlDoc.Save(Global.ConfigFilePath);
                }
                #endregion

                #region [CONTROLS]
                // Disables the XML node filter controls
                xmlNodeName_txtbox.Enabled      = false;
                xmlAddNode_btn.Enabled          = false;
                xmlEditName_btn.Enabled         = false;
                xmlScanStructure_btn.Enabled    = false;
                xmlNodeAlias_txtbox.Enabled     = false;
                xmlEditAlias_btn.Enabled        = false;
                xmlDeleteNode_btn.Enabled       = false;
                xmlNodesFilter_listview.Enabled = false;
                if (xmlNodesFilter_listview.SelectedItems.Count > 0)
                    xmlNodesFilter_listview.SelectedItems[0].Selected = false;
                // Disables some monitoring controls
                xmlInputPath_btn.Enabled              = false;
                csvOutputPath_btn.Enabled             = false;
                csvFileName_txtbox.Enabled            = false;
                csvFilePrefix_txtbox.Enabled          = false;
                csvFileSuffix_txtbox.Enabled          = false;
                monitoringIntervalHrs_numeric.Enabled = false;
                monitoringIntervalMin_numeric.Enabled = false;
                monitoringIntervalSec_numeric.Enabled = false;
                csvBadOutputDelete_chbox.Enabled      = false;

                toolVisualFeedback_lbl.BackColor = Color.GreenYellow;
                toolVisualFeedback_lbl.Text      = "Tool successfully running...";
                #endregion

                // Initializes and starts the monitoring thread
                Thread _tMonitoring = new Thread(XMLMonitoring);
                       _tMonitoring.Start();
            } else {
                if (MessageBox.Show("Are you sure?", "This will stop the monitoring of the XML folder!", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                    toolAction_btn.Text    = "START";
                    Global.MonitoringAbort = true;
                    Log._File.Write(Log._File.MessageType.MONITORING_STOPPED);

                    #region [CONTROLS]
                    if (!xmlConversionAbort_btn.Enabled) {
                        toolVisualFeedback_lbl.Font      = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);
                        toolVisualFeedback_lbl.BackColor = Color.PowderBlue;
                        toolVisualFeedback_lbl.Text      = "Tool not running";


                        if (!xmlConversionAbort_btn.Enabled) {
                            // Enables the XML node filter controls
                            xmlNodeName_txtbox.Enabled            = true;
                            xmlScanStructure_btn.Enabled          = true;
                            xmlNodeAlias_txtbox.Enabled           = true;
                            xmlEditAlias_btn.Enabled              = true;
                            xmlNodesFilter_listview.Enabled       = true;
                            // Enables monitoring controls
                            xmlInputPath_btn.Enabled              = true;
                            csvOutputPath_btn.Enabled             = true;
                            csvFileName_txtbox.Enabled            = true;
                            csvFilePrefix_txtbox.Enabled          = true;
                            csvFileSuffix_txtbox.Enabled          = true;
                            monitoringIntervalHrs_numeric.Enabled = true;
                            monitoringIntervalMin_numeric.Enabled = true;
                            monitoringIntervalSec_numeric.Enabled = true;
                            csvBadOutputDelete_chbox.Enabled      = true;

                            tool_progressbar.Value       = 0;
                            toolProgressPercent_lbl.Text = "0%";
                        }
                        #endregion
                    } else {
                        toolAction_btn.Enabled = false;
                    }
                }
            }
        }
        #endregion
        #endregion

        // Dynamic GUI modifications
        #region [GUI]
        #region [XML/CSV_DIRECTORY]
        private void xmlInputPath_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.Description  = "Select the XML input directory";
            folderBrowserDialog1.SelectedPath = xmlInputPath_txtbox.Text;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                xmlInputPath_txtbox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void csvOutputPath_btn_Click(object sender, EventArgs e) {
            folderBrowserDialog1.Description  = "Select the CSV output directory";
            folderBrowserDialog1.SelectedPath = csvOutputPath_txtbox.Text;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                csvOutputPath_txtbox.Text = folderBrowserDialog1.SelectedPath;
        }
        #endregion

        #region [TEXTBOX_PLACEHOLDER]
        #region [CSV_FILENAME]
        private void csvFileName_txtbox_Enter(object sender, EventArgs e) {
            if (csvFileName_txtbox.ForeColor == Color.Gray) {
                csvFileName_txtbox.ForeColor = Color.Black;
                csvFileName_txtbox.Text      = "";
            }
        }
        private void csvFileName_txtbox_Leave(object sender, EventArgs e) {
            if (csvFileName_txtbox.TextLength == 0) {
                csvFileName_txtbox.ForeColor = Color.Gray;
                csvFileName_txtbox.Text      = "Filename";
            }
        }
        #endregion

        #region [CSV_FILE_PREFIX]
        private void csvFilePrefix_txtbox_Enter(object sender, EventArgs e) {
            if (csvFilePrefix_txtbox.ForeColor == Color.Gray) {
                csvFilePrefix_txtbox.ForeColor = Color.Black;
                csvFilePrefix_txtbox.Text      = "";
            }
        }
        private void csvFilePrefix_txtbox_Leave(object sender, EventArgs e) {
            if (csvFilePrefix_txtbox.TextLength == 0) {
                csvFilePrefix_txtbox.ForeColor = Color.Gray;
                csvFilePrefix_txtbox.Text      = "Prefix";
            }
        }
        #endregion

        #region [CSV_FILE_SUFFIX]
        private void csvFileSuffix_txtbox_Enter(object sender, EventArgs e) {
            if (csvFileSuffix_txtbox.ForeColor == Color.Gray) {
                csvFileSuffix_txtbox.ForeColor = Color.Black;
                csvFileSuffix_txtbox.Text      = "";
            }
        }
        private void csvFileSuffix_txtbox_Leave(object sender, EventArgs e) {
            if (csvFileSuffix_txtbox.TextLength == 0) {
                csvFileSuffix_txtbox.ForeColor = Color.Gray;
                csvFileSuffix_txtbox.Text      = "Suffix";
            }
        }
        #endregion

        #region [NODE_FILTER_ALIAS]
        private void xmlNodeAlias_txtbox_Enter(object sender, EventArgs e) {
            if (xmlNodeAlias_txtbox.ForeColor == Color.Gray) {
                xmlNodeAlias_txtbox.ForeColor = Color.Black;
                xmlNodeAlias_txtbox.Text      = "";
            }
        }
        private void xmlNodeAlias_txtbox_Leave(object sender, EventArgs e) {
            if (File.Exists(String.Format("{0}\\{1}", Global.XMLNodesDirPath, xmlNodeName_txtbox.Text))) {
                if (xmlNodeAlias_txtbox.TextLength == 0) {
                    string[] _nodeValue = File.ReadAllLines(String.Format("{0}\\{1}", Global.XMLNodesDirPath, xmlNodeName_txtbox.Text));

                    // If the 'Node Alias' is empty the textbox placeholder will be the 'Node Name'
                    if (_nodeValue[1].Length == 0) {
                        xmlNodeAlias_txtbox.ForeColor = Color.Gray;
                        xmlNodeAlias_txtbox.Text      = xmlNodeName_txtbox.Text;
                    } else {
                        // If not, will be the 'Node Alias' value from the filter file of the node
                        xmlNodeAlias_txtbox.ForeColor = Color.Black;
                        xmlNodeAlias_txtbox.Text      = _nodeValue[1];
                    }

                    Global.XMLNodeAliasEmpty          = true;
                } else { Global.XMLNodeAliasEmpty     = false; }
            } else {
                if (xmlNodeAlias_txtbox.TextLength == 0) {
                    xmlNodeAlias_txtbox.ForeColor = Color.Gray;
                    xmlNodeAlias_txtbox.Text      = "Same as the 'Node Name'";
                }
            }
        }
        #endregion

        #endregion

        #region [MONITORING_CONTROLS_CHANGED_OCCUR]
        private void xmlInputPath_txtbox_TextChanged(object sender, EventArgs e) {
            if (!Global.ToolStartedNow) { Global.GUI.XMLPathChanged = true; }

            if (xmlInputPath_txtbox.TextLength > 0 && csvOutputPath_txtbox.TextLength > 0)
                toolAction_btn.Enabled = true;

            if (xmlInputPath_txtbox.TextLength == 0)
                toolAction_btn.Enabled = false;
        }
        private void csvOutputPath_txtbox_TextChanged(object sender, EventArgs e) {
            if (!Global.ToolStartedNow) { Global.GUI.CSVPathChanged = true; }

            if (xmlInputPath_txtbox.TextLength > 0 && csvOutputPath_txtbox.TextLength > 0)
                toolAction_btn.Enabled = true;

            if (csvOutputPath_txtbox.TextLength == 0)
                toolAction_btn.Enabled = false;
        }
        private void csvFileName_txtbox_TextChanged(object sender, EventArgs e)             { if (!Global.ToolStartedNow) { Global.GUI.CSVFileNameChanged       = true; } }
        private void csvFilePrefix_txtbox_TextChanged(object sender, EventArgs e)           { if (!Global.ToolStartedNow) { Global.GUI.CSVFileNamePrefixChanged = true; } }
        private void csvFileSuffix_txtbox_TextChanged(object sender, EventArgs e)           { if (!Global.ToolStartedNow) { Global.GUI.CSVFileNameSuffixChanged = true; } }
        private void monitoringIntervalHrs_numeric_ValueChanged(object sender, EventArgs e) { if (!Global.ToolStartedNow) { Global.GUI.MonitoringHrsChanged     = true; } }
        private void monitoringIntervalMin_numeric_ValueChanged(object sender, EventArgs e) { if (!Global.ToolStartedNow) { Global.GUI.MonitoringMinChanged     = true; } }
        private void monitoringIntervalSec_numeric_ValueChanged(object sender, EventArgs e) { if (!Global.ToolStartedNow) { Global.GUI.MonitoringSecChanged     = true; } }
        private void csvBadOutputDelete_chbox_CheckedChanged(object sender, EventArgs e)    { if (!Global.ToolStartedNow) { Global.GUI.MonitoringCsvBadChanged  = true; } }
        #endregion

        #region [XML_CONVERSION_ABORT]
        private void xmlConversionAbort_btn_Click(object sender, EventArgs e) {
            string _msg = "Are you sure?";

            if (csvBadOutputDelete_chbox.Checked)
                _msg = "Are you sure?\n\n(The generated CSV will be deleted!)";

            if (MessageBox.Show(_msg, "A conversion is occurring right now...", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                Global.XMLConversionAbort      = true;
                xmlConversionAbort_btn.Enabled = false;
                toolAction_btn.Enabled         = true;

                toolVisualFeedback_lbl.Font = new Font(toolVisualFeedback_lbl.Font, FontStyle.Regular | FontStyle.Bold);
                if (toolAction_btn.Text == "STOP") {
                    toolVisualFeedback_lbl.BackColor = Color.GreenYellow;
                    toolVisualFeedback_lbl.Text      = "Tool successfully running...";
                } else {
                    toolVisualFeedback_lbl.BackColor = Color.PowderBlue;
                    toolVisualFeedback_lbl.Text      = "Tool not running";

                    #region [CONTROLS]
                    // Enables the XML node filter controls
                    xmlNodeName_txtbox.Enabled            = true;
                    xmlScanStructure_btn.Enabled          = true;
                    xmlNodeAlias_txtbox.Enabled           = true;
                    xmlEditAlias_btn.Enabled              = true;
                    xmlNodesFilter_listview.Enabled       = true;
                    // Enables monitoring controls
                    xmlInputPath_btn.Enabled              = true;
                    csvOutputPath_btn.Enabled             = true;
                    csvFileName_txtbox.Enabled            = true;
                    csvFilePrefix_txtbox.Enabled          = true;
                    csvFileSuffix_txtbox.Enabled          = true;
                    monitoringIntervalHrs_numeric.Enabled = true;
                    monitoringIntervalMin_numeric.Enabled = true;
                    monitoringIntervalSec_numeric.Enabled = true;
                    csvBadOutputDelete_chbox.Enabled      = true;

                    tool_progressbar.Value       = 0;
                    toolProgressPercent_lbl.Text = "0%";
                    #endregion
                }
            }
        }
        #endregion

        #region [TOOL_CLOSING]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            if (xmlScanStructure_btn.Text == "Abort Operation" || (toolAction_btn.Text == "STOP" || xmlConversionAbort_btn.Enabled)) {
                if (MessageBox.Show("Are you sure?", "An operation is being processed...", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No) {
                    e.Cancel = true;
                }
            }

            if (e.Cancel == false)
                Global.Cleanup(this);
        }
        #endregion
        #endregion
    }
}